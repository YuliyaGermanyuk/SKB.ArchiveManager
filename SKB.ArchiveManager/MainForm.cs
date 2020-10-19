using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Helpers;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Popup;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraSplashScreen;
using DocsVision.BackOffice.ObjectModel;
using DocsVision.BackOffice.ObjectModel.Services;
using DocsVision.Platform.CardHost;
using DocsVision.Platform.Cards.Constants;
using DocsVision.Platform.ObjectManager;
using DocsVision.Platform.ObjectManager.Metadata;
using DocsVision.Platform.ObjectManager.SearchModel;
using DocsVision.Platform.ObjectManager.SystemCards;
using DocsVision.Platform.ObjectModel;
using DocsVision.Platform.Security.AccessControl;
using DocsVision.TakeOffice.Cards.Constants;
using SKB.Archive;
using SKB.ArchiveManager.Properties;
using SKB.Base;
using SKB.Base.AssignRights;
using SKB.Base.Dictionary;
using SKB.Base.Enums;
using SKB.Base.Forms;
using SKB.Base.Ref;
using SKB.Base.Ref.Properties;
using AssignGroup = SKB.Base.AssignRights.Group;
using CardFile = DocsVision.TakeOffice.Cards.Constants.CardFile;
using ObjectState = DocsVision.Platform.ObjectManager.ObjectState;
using Task = System.Threading.Tasks.Task;
using VersionedFileCard = DocsVision.Platform.ObjectManager.SystemCards.VersionedFileCard;

using RKIT.MyCollectionControl.Design.Control;
using RKIT.MyCollectionControl.Design.Layout;

namespace SKB.ArchiveManager
{
    public partial class ArchiveManagerForm : RibbonForm
    {
        #region Properties
        /// <summary>
        /// Идентификатор категории исключения "БЧ – без чертежа".
        /// </summary>
        public readonly static Guid RefCategories_WD = new Guid("{0B0C907E-62CC-477E-AB8D-C9983386FA42}");
        public readonly static Guid KindOfMarketingFilesID = new Guid("{66376382-1E19-4969-BA92-8AFFD0FEFA06}");

        private UserSession Session { get; set; }
        private ObjectContext Context { get; set; }
        private FolderCard FolderCard { get; set; }
        private ICardHost Host { get; set; }

        private BindingList<TargetObject> Data_CardRights = new BindingList<TargetObject>();
        private BindingList<TargetObject> Data_FolderRights = new BindingList<TargetObject>();
        private BindingList<Unrelated> Data_Objects = new BindingList<Unrelated>();
        private BindingList<Unrelated> Data_Matches = new BindingList<Unrelated>();
        private BindingList<FoundFile> Data_FoundFiles = new BindingList<FoundFile>();
        private BindingList<ApplicableError> Data_Errors = new BindingList<ApplicableError>();

        private CheckedListBoxControl PopupListBox;
        
        /// <summary>
        /// Текущий лог-поток.
        /// </summary>
        private StreamWriter Log;
        private const String LogFormat = "{0:yyyy.MM.dd HH:mm:ss.fff tt} | {1}";
        public readonly String ArchivePath;
        public readonly String ArchiveTempPath;
        public readonly String ArchiveDeletePath;
        public readonly String CurrentTempPath;
        public readonly String MatrixPath;

        public List<MyCollectionControlType> TypeIDsValue = new List<MyCollectionControlType>() { new MyCollectionControlType() };
        #endregion

        public ArchiveManagerForm()
        {
            InitializeComponent();

            try { Log = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.Personal) + @"\RKIT\Archive Manager " + DateTime.Now.ToString("yyyy-MM-dd") + ".lg", true, Encoding.Default); }
            catch (Exception Ex)
            { MessageBox.Show(Ex.Message);}

            SessionManager Manager = SessionManager.CreateInstance();
            try
            {
                Manager.Connect("http://" + Settings.Default.ServerName + "/DocsVision/StorageServer/StorageServerService.asmx", Settings.Default.BaseName);
                Session = Manager.CreateSession();
                FolderCard = (FolderCard)Session.CardManager.GetCard(FoldersCard.ID, false);
                Context = Session.CreateContext();

                ICalendarService calendarService = Context.GetService<ICalendarService>();
                double H = 30;
                DateTime NewStartDate = DateTime.Now;

                DateTime NewEndDate = calendarService.GetEndDate(new Guid("{2DFC601B-451C-E411-A309-00155D016943}"), NewStartDate, H);

                Host = (ICardHost)CardHost.CreateInstance(Session);
                ArchivePath = Session.GetArchivePath();
                ArchiveTempPath= Session.GetArchiveTempPath();
                ArchiveDeletePath = Session.GetArchiveDeletePath();
                CurrentTempPath = Path.GetTempPath();
            }
            catch(Exception Ex)
            {
                XtraMessageBox.Show("Невозможно установить подключение к базе!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                WriteLog("Невозможно установить подключение к базе!");
                CallError(Ex);
                throw new Exception("Ошибка", Ex);
            }

            if (ArchivePath.IsNull() || ArchiveTempPath.IsNull() || ArchiveDeletePath.IsNull())
            {
                XtraMessageBox.Show("Не удалось получить доступ к архиву!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                WriteLog("Не удалось получить доступ к архиву");
                throw new Exception("Ошибка");
            }

            if (Settings.Default.AccessMatrixPath.IsNull())
                MatrixPath = Session.GetMatrixPath();
            else
                MatrixPath = Settings.Default.AccessMatrixPath;


            FileInfo AccessMatrix = new FileInfo(MatrixPath);
            if (AccessMatrix.Exists)
            {
                foreach (TargetObject Tobject in AssignHelper.LoadMatrix(MatrixPath, Settings.Default.CardRightsSheet, Settings.Default.DomainName))
                    Data_CardRights.Add(Tobject);
                foreach (TargetObject Tobject in AssignHelper.LoadMatrix(MatrixPath, Settings.Default.FolderRightsSheet, Settings.Default.DomainName))
                    Data_FolderRights.Add(Tobject);
            }
            else
            {
                XtraMessageBox.Show("Матрица доступа не найдена!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                WriteLog("Матрица доступа не найдена по пути: " + AccessMatrix.FullName);
                throw new Exception();
            }

            if(!Data_CardRights.Any() && !Data_FolderRights.Any())
                XtraMessageBox.Show("Не удалось загрузить матрицу!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            SkinHelper.InitSkinPopupMenu(Item_Theme);

            /*this.Edit_Device.ObjectContext = Context;
            this.Edit_Device.TypeIds = new List<MyCollectionControlType>()
                {
                    new MyCollectionControlType() 
                    { 
                        CardTypeId = RefUniversal.ID,
                        NodeId = MyHelper.RefItem_Devices,
                        SectionId = RefUniversal.Item.ID 
                    }
                };*/

            Control_CardRights.DataSource = Data_CardRights;
            Control_FolderRights.DataSource = Data_FolderRights;
            Control_Objects.DataSource = Data_Objects;
            Control_Matches.DataSource = Data_Matches;
            Control_FoundFiles.DataSource = Data_FoundFiles;
            Control_Errors.DataSource = Data_Errors;

            Control_Tabs.ShowTabHeader = DefaultBoolean.False;
            Control_DefaultLAF.LookAndFeel.SkinName = Settings.Default.SkinName;
            Size = Settings.Default.FormSize;
            WindowState = (FormWindowState)Enum.Parse(typeof(FormWindowState), Settings.Default.FormState, true);
        }

        #region Methods

        /// <summary>
        /// Выполняет логирование исключений.
        /// </summary>
        /// <param name="Ex"></param>
        public void CallError (Exception Ex)
        {
            Item_CurrentState.Caption = "Произошла непредвиденная ошибка.";
            WriteLog("Ошибка: непредвиденное исключение" + "\r\n" + Ex.Message + "\r\n" + Ex.StackTrace);
        }
        /// <summary>
        /// Возвращает данные карточки.
        /// </summary>
        /// <param name="CardId">Идентификатор карточки.</param>
        /// <returns></returns>
        private CardData GetCardData (Guid CardId)
        {
            switch (Session.CardManager.GetCardState(CardId))
            {
                case ObjectState.Existing: return Session.CardManager.GetCardData(CardId);
                case ObjectState.Deleted:
                    Item_CurrentState.Caption = "Указанная карточка удалена!";
                    return null;
                default:
                    Item_CurrentState.Caption = "Указанной карточки не существует!";
                    return null;
            }
        }
        /// <summary>
        /// Возвращает надстройку для карточки.
        /// </summary>
        /// <param name="Card">Данные карточки.</param>
        /// <returns></returns>
        private ExtraCard GetExtraCard (CardData Card)
        {
            ExtraCard Extra = ExtraCardCD.GetExtraCard(Card);
            if (Extra.IsNull())
                Extra = ExtraCardTD.GetExtraCard(Card);
            if (Extra.IsNull())
                Extra = ExtraCardEA.GetExtraCard(Card);
            if (Extra.IsNull())
                Extra = ExtraCardMarketingFiles.GetExtraCard(Card);
            return Extra;
        }
        /// <summary>
        /// Убирает флаг "Подсвечивать непрочитанные карточки" для коллекции папок.
        /// </summary>
        /// <param name="Folders">Колекция папок.</param>
        void SetNoUnreadCards (FolderCollection Folders)
        {
            if (!Folders.IsNull())
            {
                foreach (Folder Folder in Folders)
                {
                    Folder.Flags = Folder.Flags | FolderFlags.NoUnreadCards;
                    WriteLog(Folder.Name + " - убран флаг Подсвечивать непрочитанные карточки. (" + Folder.Id + ")");
                    SetNoUnreadCards(Folder.Folders);
                }
            }
        }
        /// <summary>
        /// Записывает указанное сообщение в лог.
        /// </summary>
        /// <param name="Message">Сообщение.</param>
        private void WriteLog (String Message)
        {
            if (Log != null)
            {
                Log.WriteLine(String.Format(LogFormat, DateTime.Now, Message));
                Log.Flush();
            }
        }
        /// <summary>
        /// Освобождает занимаемую процессом память.
        /// </summary>
        private static void Clear ()
        {
            GC.Collect(GC.MaxGeneration);
            GC.WaitForPendingFinalizers();
            Process p = Process.GetCurrentProcess();
            p.MinWorkingSet = p.MinWorkingSet;
        }
        /// <summary>
        /// Возвращает название категории по идентификатору.
        /// </summary>
        /// <param name="CategoryId"></param>
        /// <returns></returns>
        private String GetCategoryName (Guid? CategoryId)
        {
            try { return CategoryId.HasValue ? Context.GetObject<CategoriesCategory>(CategoryId).Name : String.Empty; }
            catch { return String.Empty; }
        }

        #endregion

        #region Events

        private void Button_CheckPath_Click (Object sender, EventArgs e)
        {
            WriteLog("<<< Проверить путь >>>");
            Item_CurrentState.Caption = String.Empty;

            CardData Card = GetCardData(Edit_CardId.Text.ToGuid());
            if (!Card.IsNull())
            {
                ExtraCard Extra = GetExtraCard(Card);
                if (!Extra.IsNull())
                {
                    String FolderPath = Extra.Path;

                    if (!String.IsNullOrEmpty(FolderPath))
                    {
                        if (Directory.Exists(FolderPath) && !FolderPath.Contains(@"c:"))
                        {
                            DirectoryInfo Folder = new DirectoryInfo(FolderPath);
                            if (Folder.Parent != null)
                                Edit_NewPath.Properties.Buttons[0].Tag = Folder.Parent.FullName;
                        }
                        if (Directory.Exists(FolderPath))
                            XtraMessageBox.Show("Папка существует!");
                    }
                    Edit_OldPath.Text = FolderPath;
                    Item_CurrentState.Caption = "Путь для карточки " + Card.Description + ": '" + FolderPath + "'";
                }
            }
        }

        private void Button_Replace_Click (Object sender, EventArgs e)
        {
            WriteLog("<<< Заменить >>>");
            if (String.IsNullOrWhiteSpace(Edit_IfPattern.Text))
                return;

            if (String.IsNullOrWhiteSpace(Edit_FindPattern.Text))
                return;

            if (String.IsNullOrWhiteSpace(Edit_ReplacePattern.Text))
                return;

            WriteLog("IfPattern = " + Edit_IfPattern.Text);
            WriteLog("FindPattern = " + Edit_FindPattern.Text);
            WriteLog("ReplacePattern = " + Edit_ReplacePattern.Text);

            Item_CurrentState.Caption = String.Empty;

            try
            {
                SplashScreenManager.ShowForm(this, typeof(MyWaitForm), false, false);
                SplashScreenManager.Default.SetWaitFormDescription("Идёт поиск карточек.");

                SearchQuery Query_Search = Session.CreateSearchQuery();
                CardTypeQuery Query_CardType = Query_Search.AttributiveSearch.CardTypeQueries.AddNew(CardOrd.ID);
                SectionQuery Query_Section = Query_CardType.SectionQueries.AddNew(CardOrd.MainInfo.ID);
                //Query_Search.Limit = 0;
                Query_Search.CombineResults = ConditionGroupOperation.And;

                Query_Section.Operation = SectionQueryOperation.And;
                Query_Section.ConditionGroup.Operation = ConditionGroupOperation.Or;
                Query_Section.ConditionGroup.Conditions.AddNew(CardOrd.MainInfo.Type, FieldType.RefId, ConditionOperation.Equals, MyHelper.RefType_CD);
                Query_Section.ConditionGroup.Conditions.AddNew(CardOrd.MainInfo.Type, FieldType.RefId, ConditionOperation.Equals, MyHelper.RefType_TD);
                Query_Section.ConditionGroup.Conditions.AddNew(CardOrd.MainInfo.Type, FieldType.RefId, ConditionOperation.Equals, MyHelper.RefType_EA);

                Query_Section = Query_CardType.SectionQueries.AddNew(CardOrd.Properties.ID);
                Query_Section.Operation = SectionQueryOperation.And;
                Query_Section.ConditionGroup.Operation = ConditionGroupOperation.And;
                Query_Section.ConditionGroup.Conditions.AddNew(CardOrd.Properties.Name, FieldType.String, ConditionOperation.OneOf, new String [] { "Файлы документа", "Файлы"});
                Query_Section.ConditionGroup.Conditions.AddNew(CardOrd.Properties.Value, FieldType.String, ConditionOperation.Contains, Edit_IfPattern.Text);

                Query_CardType = Query_Search.AttributiveSearch.CardTypeQueries.AddNew(RefMarketingFilesCard.ID);
                Query_Section = Query_CardType.SectionQueries.AddNew(RefMarketingFilesCard.MainInfo.ID);
                Query_Section.ConditionGroup.Conditions.AddNew(RefMarketingFilesCard.MainInfo.Folder, FieldType.Unistring, ConditionOperation.Contains, Edit_IfPattern.Text);

                Query_Search.Limit = 0;

                WriteLog("Сформирован поисковый запрос: " + Query_Search.GetXml(null, true));
                List<Guid> CardIds = Session.CardManager.FindCards(Query_Search.GetXml(null, true)).Select(card => card.Id).ToList();

                Int32 ReplaceCount = 0;
                WriteLog("Найдено карточек: " + CardIds.Count);
                Int32 Index = 0;
                foreach (Guid CardId in CardIds)
                {
                    Index++;
                    SplashScreenManager.Default.SetWaitFormDescription("Идёт обработка карточек (" + Index + " из " + CardIds.Count + ").");
                    WriteLog("Запус обработки для карточки - " + Index + " - " + CardId);
                    String LogStrings = Task.Factory.StartNew<String>(() =>
                    {
                        StringBuilder LogString = new StringBuilder();
                        try
                        {
                            CardData Card = Session.CardManager.GetCardData(CardId);
                            LogString.AppendLine("Идёт обработка карточки - " + Index + " - " + Card.Description + " - " + Card.Id);
                            ExtraCard Extra = GetExtraCard(Card);
                            if (!Extra.IsNull())
                            {
                                String OldPath = Extra.Path;

                                if (!String.IsNullOrEmpty(OldPath))
                                {
                                    if (Regex.IsMatch(OldPath, Edit_IfPattern.Text, RegexOptions.IgnoreCase))
                                    {
                                        try
                                        {
                                            String NewPath = Regex.Replace(OldPath, Edit_FindPattern.Text, Edit_ReplacePattern.Text, RegexOptions.IgnoreCase);
                                            LogString.AppendLine("Card - " + Card.Id + " - Old path - " + OldPath + " - New path - " + NewPath);
                                            Extra.Path = NewPath;
                                            LogString.AppendLine("Заменено");
                                            ReplaceCount++;
                                        }
                                        catch (Exception Ex)
                                        {
                                            LogString.AppendLine(Ex.Message);
                                            LogString.AppendLine(Ex.StackTrace);
                                        }
                                    }
                                    else
                                        LogString.AppendLine("Не найдено '" + Edit_IfPattern.Text + "' в пути '" + OldPath + "'");
                                }
                                else
                                    LogString.AppendLine("Пустая папка!");
                            }
                            else
                                LogString.AppendLine("Неверный тип карточки!");

                            Card = null;

                            Clear();
                        }
                        catch (Exception Ex)
                        {
                            LogString.AppendLine(Ex.Message);
                            LogString.AppendLine(Ex.StackTrace);
                        }
                        return LogString.ToString();
                    }).Result;

                    foreach (String LogString in LogStrings.Split('\n'))
                        WriteLog(LogString);
                }

                Item_CurrentState.Caption = String.Format("Выполнено замен {0}.", ReplaceCount);
            }
            catch (Exception Ex) { CallError(Ex); }
            SplashScreenManager.CloseForm(false);
        }

        private void Button_SavePath_Click (Object sender, EventArgs e)
        {
            WriteLog("<<< Сохранить >>>");
            Item_CurrentState.Caption = String.Empty;

            CardData Card = GetCardData(Edit_CardId.Text.ToGuid());
            if (!Card.IsNull())
            {
                ExtraCard Extra = GetExtraCard(Card);
                if (!Extra.IsNull())
                {
                    try
                    {
                        WriteLog("Карточка: " + Card.Description + " - " + Card.Id);
                        WriteLog("Старый путь: " + Extra.Path);
                        WriteLog("Новый путь: " + Edit_NewPath.Text);
                        Extra.Path = String.IsNullOrWhiteSpace(Edit_NewPath.Text) ? null : Edit_NewPath.Text;

                        Item_CurrentState.Caption = "Изменен путь для карточки: " + Card.Description;
                        Edit_CardId.EditValue = String.Empty;
                        Edit_OldPath.EditValue = String.Empty;
                        Edit_NewPath.EditValue = String.Empty;
                        Edit_NewPath.Properties.Buttons[0].Tag = String.Empty;
                    }
                    catch (Exception Ex)
                    {
                        WriteLog("Ошибочная карточка - " + Card.Description + " - " + Card.Id);
                        CallError(Ex);
                    }
                }
            }
        }

        private void Button_Selecting_Click (Object sender, EventArgs e)
        {
            SimpleButton Selecting = (SimpleButton)sender;
            Boolean Selected;
            if (Boolean.TryParse((Selecting.Tag ?? String.Empty).ToString(), out Selected))
            {
                foreach (FoundFile FFile in Data_FoundFiles)
                    FFile.Selected = Selected;
                View_FoundFiles.RefreshData();
            }
        }

        private void Control_Ribbon_SelectedPageChanged (Object sender, EventArgs e)
        {
            Control_Tabs.SelectedTabPageIndex = Convert.ToInt32((Control_Ribbon.SelectedPage.Tag ?? 0));
        }

        private void Edit_CardId_ButtonPressed (Object sender, ButtonPressedEventArgs e)
        {
            Guid CardId;
            switch (e.Button.Kind)
            {
                case ButtonPredefines.Ellipsis:
                    SearchQuery Query_Search = Session.CreateSearchQuery();
                    CardTypeQuery Query_CardType = Query_Search.AttributiveSearch.CardTypeQueries.AddNew(CardOrd.ID);
                    SectionQuery Query_Section = Query_CardType.SectionQueries.AddNew(CardOrd.MainInfo.ID);
                    Query_Section.Operation = SectionQueryOperation.And;
                    Query_Section.ConditionGroup.Operation = ConditionGroupOperation.Or;
                    Query_Section.ConditionGroup.Conditions.AddNew(CardOrd.MainInfo.Type, FieldType.RefId, ConditionOperation.Equals, MyHelper.RefType_CD);
                    Query_Section.ConditionGroup.Conditions.AddNew(CardOrd.MainInfo.Type, FieldType.RefId, ConditionOperation.Equals, MyHelper.RefType_TD);
                    Query_Section.ConditionGroup.Conditions.AddNew(CardOrd.MainInfo.Type, FieldType.RefId, ConditionOperation.Equals, MyHelper.RefType_EA);

                    Query_CardType = Query_Search.AttributiveSearch.CardTypeQueries.AddNew(RefMarketingFilesCard.ID);
                    Query_Section = Query_CardType.SectionQueries.AddNew(RefMarketingFilesCard.MainInfo.ID);
                    Query_Section.ConditionGroup.Operation = ConditionGroupOperation.And;
                    Query_Section.ConditionGroup.Conditions.AddNew(RefMarketingFilesCard.MainInfo.Folder, FieldType.Unistring, ConditionOperation.IsNotNull);
                    Query_Section.ConditionGroup.Conditions.AddNew(RefMarketingFilesCard.MainInfo.Folder, FieldType.Unistring, ConditionOperation.NotEquals, String.Empty);

                    CardId = Host.SelectCard("Выберите карточку...", Settings.Default.FolderForFixPath, Query_Search.GetXml());

                    if (!CardId.IsEmpty())
                        Edit_CardId.EditValue = CardId.ToString();
                    break;
                case ButtonPredefines.Redo:
                    CardId = Edit_CardId.EditValue.ToGuid();
                    if (!CardId.IsEmpty())
                    {
                        CardData Card = GetCardData(CardId);
                        if (!Card.IsNull())
                            if (Host.ShowCardModal(CardId, ActivateMode.Edit))
                            {
                                ExtraCard Extra = GetExtraCard(Card);
                                if (!Extra.IsNull())
                                {
                                    String FolderPath = Extra.Path;

                                    if (!String.IsNullOrEmpty(FolderPath))
                                    {
                                        if (Directory.Exists(FolderPath) && !FolderPath.Contains(@"c:"))
                                        {
                                            DirectoryInfo Folder = new DirectoryInfo(FolderPath);
                                            if (Folder.Parent != null)
                                                Edit_NewPath.Properties.Buttons[0].Tag = Folder.Parent.FullName;
                                        }
                                    }
                                    Edit_OldPath.Text = FolderPath;
                                    Item_CurrentState.Caption = "Путь для карточки " + Card.Description + ": '" + FolderPath + "'";
                                }
                            }
                    }
                    break;
            }
        }

        private void Edit_DVFolder_ButtonPressed (Object sender, ButtonPressedEventArgs e)
        {
            switch (e.Button.Kind)
            {
                case ButtonPredefines.Ellipsis:
                    Guid FolderId = Host.SelectFolder("Выберите папку...",(Int32)FolderTypes.Regular, Settings.Default.FolderForMarketingFiles); 

                    if (!FolderId.IsEmpty())
                    {
                        Folder Folder = FolderCard.GetFolder(FolderId);
                        Edit_DVFolder.EditValue =  Folder.Name;
                        Edit_DVFolder.ToolTip = Folder.GetFullFolderName();
                        Edit_DVFolder.Tag = FolderId;
                    }
                    break;
            }
        }

        private void Edit_NewPath_ButtonPressed (Object sender, ButtonPressedEventArgs e)
        {
            switch (e.Button.Kind)
            {
                case ButtonPredefines.Ellipsis:
                    Item_CurrentState.Caption = String.Empty;
                    Dialog_Folder.Description = e.Button.ToolTip;
                    Dialog_Folder.SelectedPath = e.Button.Tag as String;

                    if (Dialog_Folder.ShowDialog() == DialogResult.OK)
                    {
                        String np = String.Format("{0}\\",
                            Regex.Replace(Dialog_Folder.SelectedPath, @"c:", @"\\" + Settings.Default.ServerName, RegexOptions.IgnoreCase));
                        Edit_NewPath.Text = np;
                    }
                    break;
            }
        }

        private void Item_CheckGroups_ItemClick (Object sender, ItemClickEventArgs e)
        {
            Item_CurrentState.Caption = String.Empty;
            WriteLog("<<< Проверить группы >>>");
            Int32 ErrorCount = 0;
            FileInfo CheckFile = new FileInfo("CheckFile.txt");

            if (!CheckFile.Exists)
                CheckFile.Create();
            if (Data_CardRights.Any() && Data_FolderRights.Any())
            {
                List<String> CardGroupNames = Data_CardRights.First().Groups.Select(g => g.Name).ToList();
                List<String> FolderGroupNames = Data_FolderRights.First().Groups.Select(g => g.Name).ToList();

                foreach (String GoupName in CardGroupNames)
                {
                    FileSecurity Rights = CheckFile.GetAccessControl();

                    try { Rights.AddAccessRule(new FileSystemAccessRule(GoupName, FileSystemRights.ReadData, AccessControlType.Allow)); }
                    catch (IdentityNotMappedException)
                    {
                        ErrorCount++;
                        WriteLog("'" + GoupName + "' из " + Settings.Default.CardRightsSheet + " не найдена");
                    }

                    CheckFile.SetAccessControl(Rights);
                }
                foreach (String GoupName in FolderGroupNames)
                {
                    FileSecurity Rights = CheckFile.GetAccessControl();
                    try { Rights.AddAccessRule(new FileSystemAccessRule(GoupName, FileSystemRights.WriteData, AccessControlType.Allow)); }
                    catch (IdentityNotMappedException)
                    {
                        ErrorCount++;
                        WriteLog("'" + GoupName + "' из " + Settings.Default.FolderRightsSheet + " не найдена");
                    }
                    CheckFile.SetAccessControl(Rights);
                }

                WriteLog("Результат проверки групп: " + ErrorCount);

                if (ErrorCount != 0)
                    XtraMessageBox.Show("Несоответствий: " + ErrorCount, "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                    Item_CurrentState.Caption = "Проверка завершена успешно";
            }
        }

        private void Item_Check_ItemClick (Object sender, ItemClickEventArgs e)
        {
            GridView View = Control_Matrix.SelectedTabPageIndex == 0 ? View_CardRights : View_FolderRights;
            BindingList<TargetObject> Data = Control_Matrix.SelectedTabPageIndex == 0 ? Data_CardRights : Data_FolderRights;
            View.PostEditor();
            Boolean Flag;
            if (Boolean.TryParse((e.Item.Tag ?? false).ToString(), out Flag))
            {
                foreach (TargetObject TObject in Data)
                    TObject.NeedAssign = Flag;
                View.RefreshData();
            }
        }

        private void Item_Details_ItemClick (Object sender, ItemClickEventArgs e)
        {
            GridView View = Control_Matrix.SelectedTabPageIndex == 0 ? View_CardRights : View_FolderRights;
            View.BeginUpdate();
            Boolean Flag;
            if (Boolean.TryParse((e.Item.Tag ?? false).ToString(), out Flag))
            {
                for (Int32 i = 0, c = View.RowCount; i < c; i++)
                    View.SetMasterRowExpanded(i, Flag);
            }
            View.EndUpdate();
        }

        private void Item_Find_ItemClick (Object sender, ItemClickEventArgs e)
        {
            try
            {
                if (Edit_Action.SelectedIndex < 0)
                    throw new MyException("Для начала поиска укажите действие.");
                if (Edit_FileSize.Value <= 0)
                    throw new MyException("Для начала поиска укажите размер файла.");
                if (Edit_DVFolder.Tag.ToGuid().IsEmpty())
                    throw new MyException("Для начала поиска укажите папку.");

                WriteLog("<<< Поиск файлов >>>");
                Item_CurrentState.Caption = String.Empty;
                WriteLog("Поисков файлов, размер которых " + Edit_Action.Text + " " + Edit_FileSize.Text + ", в папке " + Edit_DVFolder.ToolTip);

                SplashScreenManager.ShowForm(this, typeof(MyWaitForm), false, false);
                SplashScreenManager.Default.SetWaitFormDescription("Идёт поиск карточек.");

                SearchQuery Query_Search = Session.CreateSearchQuery();
                CardTypeQuery Query_CardType = Query_Search.AttributiveSearch.CardTypeQueries.AddNew(CardFile.ID);
                SectionQuery Query_Section = Query_CardType.SectionQueries.AddNew(CardFile.MainInfo.ID);
                switch (Edit_Action.SelectedIndex)
                {
                    case 0: Query_Section.ConditionGroup.Conditions.AddNew(CardFile.MainInfo.FileSize, FieldType.Int, ConditionOperation.GreaterThan, (Int32)(Edit_FileSize.Value * 1024)); break;
                    case 1: Query_Section.ConditionGroup.Conditions.AddNew(CardFile.MainInfo.FileSize, FieldType.Int, ConditionOperation.LessThan, (Int32)(Edit_FileSize.Value * 1024)); break;
                    case 2: Query_Section.ConditionGroup.Conditions.AddNew(CardFile.MainInfo.FileSize, FieldType.Int, ConditionOperation.Equals, (Int32)(Edit_FileSize.Value * 1024)); break;
                }
                Query_Search.Scope.Folders.Enabled = true;
                Query_Search.Scope.Folders.AddNew(Edit_DVFolder.Tag.ToGuid()).IncludeSubfolders = true;
                Query_Search.Limit = 0;
                String Query_XML = Query_Search.GetXml();

                WriteLog("Составлен поисковый запрос: " + Query_XML);
                CardDataCollection FileCards = Session.CardManager.FindCards(Query_XML);
                WriteLog("Найдено файлов: " + FileCards.Count);
                Item_CurrentState.Caption = "Найдено файлов: " + FileCards.Count;
                Data_FoundFiles.Clear();
                Edit_TotalFileSize.Value = Decimal.Zero;

                for (Int32 i = 0; i < FileCards.Count; i++)
                {
                    SplashScreenManager.Default.SetWaitFormDescription("Идёт загрузка карточек. (" + (i + 1) + " из " + FileCards.Count + ")");
                    Data_FoundFiles.Add(new FoundFile(Context, FileCards[i]));
                }

                Edit_TotalFileSize.Value = Data_FoundFiles.Sum(file => file.Size);

                View_FoundFiles.RefreshData();

                SplashScreenManager.CloseForm();
            }
            catch (MyException Ex) { XtraMessageBox.Show(Ex.Message, "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
            catch (Exception Ex) { CallError(Ex); }
        }

        private void Item_FindUnrelatedCards_ItemClick (Object sender, ItemClickEventArgs e)
        {
            try
            {
                WriteLog("<<< Поиск карточек без папки >>>");
                Item_CurrentState.Caption = String.Empty;

                Data_Objects.Clear();

                List<Unrelated> NewRows = new List<Unrelated>();

                SplashScreenManager.ShowForm(this, typeof(MyWaitForm), false, false);

                SplashScreenManager.Default.SetWaitFormDescription("Идёт получение КД...");
                NewRows.AddRange(Task.Factory.StartNew<List<Unrelated>>(() =>
                    {
                        List<Unrelated> Rows = new List<Unrelated>();
                        Report FolderReport = Session.ReportManager.Reports[MyReports.CDFolders.ID];
                        FolderReport.Parameters["HasNull"].Value = true;

                        using (InfoRowCollection FolderReportRows = FolderReport.GetData())
                        {
                            foreach (InfoRow Row in FolderReportRows)
                                Rows.Add(new Unrelated(Row.GetString(MyReports.CDFolders.CardType),
                                    Row.GetString(MyReports.CDFolders.CardName),
                                    GetCategoryName(Row.GetGuid(MyReports.CDFolders.CardCategory)),
                                    Row.GetString(MyReports.CDFolders.CardPath),
                                    Row.GetGuid(MyReports.CDFolders.CardID)));
                        }

                        FolderReport = null;
                        return Rows;
                    }).Result);

                Clear();

                SplashScreenManager.Default.SetWaitFormDescription("Идёт получение ТД...");
                NewRows.AddRange(Task.Factory.StartNew<List<Unrelated>>(() =>
                {
                    List<Unrelated> Rows = new List<Unrelated>();
                    Report FolderReport = Session.ReportManager.Reports[MyReports.TDFolders.ID];
                    FolderReport.Parameters["HasNull"].Value = true;

                    using (InfoRowCollection FolderReportRows = FolderReport.GetData())
                    {

                        foreach (InfoRow Row in FolderReportRows)
                            Rows.Add(new Unrelated(Row.GetString(MyReports.TDFolders.CardType),
                                Row.GetString(MyReports.TDFolders.CardName),
                                GetCategoryName(Row.GetGuid(MyReports.TDFolders.CardCategory)),
                                Row.GetString(MyReports.TDFolders.CardPath),
                                Row.GetGuid(MyReports.TDFolders.CardID)));

                    }

                    FolderReport = null;
                    return Rows;
                }).Result);

                Clear();

                SplashScreenManager.Default.SetWaitFormDescription("Идёт получение УО...");
                NewRows.AddRange(Task.Factory.StartNew<List<Unrelated>>(() =>
                {
                    List<Unrelated> Rows = new List<Unrelated>();
                    Report FolderReport = Session.ReportManager.Reports[MyReports.EAFolders.ID];
                    FolderReport.Parameters["HasNull"].Value = true;

                    using (InfoRowCollection FolderReportRows = FolderReport.GetData())
                    {

                        foreach (InfoRow Row in FolderReportRows)
                            Rows.Add(new Unrelated(Row.GetString(MyReports.EAFolders.CardType),
                                Row.GetString(MyReports.EAFolders.CardName),
                                GetCategoryName(Row.GetGuid(MyReports.EAFolders.CardCategory)),
                                Row.GetString(MyReports.EAFolders.CardPath),
                                Row.GetGuid(MyReports.EAFolders.CardID)));

                    }

                    FolderReport = null;
                    return Rows;
                }).Result);

                Clear();

                SplashScreenManager.Default.SetWaitFormDescription("Идёт получение ФМ...");
                NewRows.AddRange(Task.Factory.StartNew<List<Unrelated>>(() =>
                {
                    List<Unrelated> Rows = new List<Unrelated>();
                    Report FolderReport = Session.ReportManager.Reports[MyReports.FilesFolders.ID];
                    FolderReport.Parameters["HasNull"].Value = true;

                    using (InfoRowCollection FolderReportRows = FolderReport.GetData())
                    {

                        foreach (InfoRow Row in FolderReportRows)
                            Rows.Add(new Unrelated(Row.GetString(MyReports.FilesFolders.CardType),
                                Row.GetString(MyReports.FilesFolders.CardName),
                                GetCategoryName(Row.GetGuid(MyReports.FilesFolders.CardCategory)),
                                Row.GetString(MyReports.FilesFolders.CardPath),
                                Row.GetGuid(MyReports.FilesFolders.CardID)));
                    }

                    FolderReport = null;
                    return Rows;
                }).Result);

                Clear();

                SplashScreenManager.Default.SetWaitFormDescription("Идёт анализ карточек...");
                foreach (Unrelated NewRow in NewRows.Where(row => row.Folder.IsNull() || !Directory.Exists(row.Folder)))
                    Data_Objects.Add(NewRow);

                WriteLog("Найдено карточек: " + Data_Objects.Count);
                Item_CurrentState.Caption = "Найдено карточек: " + Data_Objects.Count;

                View_FoundFiles.RefreshData();                
            }
            catch (Exception Ex) { CallError(Ex); }
            SplashScreenManager.CloseForm(false);
        }

        private void Item_FindUnrelatedFolders_ItemClick (Object sender, ItemClickEventArgs e)
        {
            try
            {
                Guid RefPreSelectedFolderForDocuments = new Guid("{361E4B91-BF31-434E-A490-B6DF6DD4453E}");
                SearchQuery Query_Search = Session.CreateSearchQuery();
                CardTypeQuery Query_CardType = Query_Search.AttributiveSearch.CardTypeQueries.AddNew(CardOrd.ID);
                SectionQuery Query_Section = Query_CardType.SectionQueries.AddNew(CardOrd.MainInfo.ID);
                Query_Section.Operation = SectionQueryOperation.And;
                Query_Section.ConditionGroup.Operation = ConditionGroupOperation.Or;
                Query_Section.ConditionGroup.Conditions.AddNew(CardOrd.MainInfo.Type, FieldType.RefId, ConditionOperation.Equals, MyHelper.RefType_CD);
                Query_Section.ConditionGroup.Conditions.AddNew(CardOrd.MainInfo.Type, FieldType.RefId, ConditionOperation.Equals, MyHelper.RefType_TD);
                Query_Section = Query_CardType.SectionQueries.AddNew(CardOrd.Properties.ID);
                Query_Section.ConditionGroup.Operation = ConditionGroupOperation.And;
                Query_Section.ConditionGroup.Conditions.AddNew(CardOrd.Properties.Name, FieldType.Unistring, ConditionOperation.Equals, "Статус");
                Query_Section.ConditionGroup.Conditions.AddNew(CardOrd.Properties.Value, FieldType.Int, ConditionOperation.Equals, DocumentState.Draft);

                Guid[] DocIds = Host.SelectCards("Выберите документ для согласования...", RefPreSelectedFolderForDocuments, Query_Search.GetXml());

                WriteLog("<<< Поиск папок без карточки >>>");
                Item_CurrentState.Caption = String.Empty;

                Data_Objects.Clear();

                List<String> CardFolders = new List<String>();

                SplashScreenManager.ShowForm(this, typeof(MyWaitForm), false, false);

                SplashScreenManager.Default.SetWaitFormDescription("Идёт получение папок КД...");
                CardFolders.AddRange(Task.Factory.StartNew<List<String>>(() =>
                {
                    List<String> Folders = new List<String>();
                    Report FolderReport = Session.ReportManager.Reports[MyReports.CDFolders.ID];
                    FolderReport.Parameters["HasNull"].Value = false;

                    using (InfoRowCollection FolderReportRows = FolderReport.GetData())
                    {
                        foreach (InfoRow Row in FolderReportRows)
                            Folders.Add(Row.GetString(MyReports.CDFolders.CardPath));
                    }

                    FolderReport = null;
                    return Folders;
                }).Result);

                Clear();

                SplashScreenManager.Default.SetWaitFormDescription("Идёт получение папок ТД...");
                CardFolders.AddRange(Task.Factory.StartNew<List<String>>(() =>
                {
                    List<String> Folders = new List<String>();
                    Report FolderReport = Session.ReportManager.Reports[MyReports.TDFolders.ID];
                    FolderReport.Parameters["HasNull"].Value = false;

                    using (InfoRowCollection FolderReportRows = FolderReport.GetData())
                    {

                        foreach (InfoRow Row in FolderReportRows)
                            Folders.Add(Row.GetString(MyReports.CDFolders.CardPath));
                    }

                    FolderReport = null;
                    return Folders;
                }).Result);

                Clear();

                SplashScreenManager.Default.SetWaitFormDescription("Идёт получение папок УО...");
                CardFolders.AddRange(Task.Factory.StartNew<List<String>>(() =>
                {
                    List<String> Folders = new List<String>();
                    Report FolderReport = Session.ReportManager.Reports[MyReports.EAFolders.ID];
                    FolderReport.Parameters["HasNull"].Value = false;

                    using (InfoRowCollection FolderReportRows = FolderReport.GetData())
                    {

                        foreach (InfoRow Row in FolderReportRows)
                            Folders.Add(Row.GetString(MyReports.CDFolders.CardPath));
                    }

                    FolderReport = null;
                    return Folders;
                }).Result);

                Clear();

                SplashScreenManager.Default.SetWaitFormDescription("Идёт получение папок ФМ...");
                CardFolders.AddRange(Task.Factory.StartNew<List<String>>(() =>
                {
                    List<String> Folders = new List<String>();
                    Report FolderReport = Session.ReportManager.Reports[MyReports.FilesFolders.ID];
                    FolderReport.Parameters["HasNull"].Value = false;

                    using (InfoRowCollection FolderReportRows = FolderReport.GetData())
                    {

                        foreach (InfoRow Row in FolderReportRows)
                            Folders.Add(Row.GetString(MyReports.CDFolders.CardPath));
                    }

                    FolderReport = null;
                    return Folders;
                }).Result);

                Clear();

                SplashScreenManager.Default.SetWaitFormDescription("Идёт проверка папок карточек...");
                CardFolders = CardFolders.Select(s => s.Last() == '\\' ? s : (s + @"\")).ToList();

                SplashScreenManager.Default.SetWaitFormDescription("Идёт получение папок архива...");
                List<String> ArchiveFolders = Directory.GetDirectories(ArchivePath).SelectMany(dir => Directory.GetDirectories(dir)).Select(s => s.Last() == '\\' ? s : (s + @"\")).ToList();

                SplashScreenManager.Default.SetWaitFormDescription("Идёт анализ папок...");

                foreach (String NewRow in ArchiveFolders.Except(CardFolders, StringComparer.OrdinalIgnoreCase))
                    Data_Objects.Add(new Unrelated(String.Empty, String.Empty, String.Empty, NewRow, null));

                WriteLog("Найдено отвязанных папок: " + Data_Objects.Count);
                Item_CurrentState.Caption = "Найдено папок: " + Data_Objects.Count;

                View_FoundFiles.RefreshData();
            }
            catch (Exception Ex) { CallError(Ex); }
            SplashScreenManager.CloseForm(false);
        }

        private void Item_FindMatchByIN_ItemClick (Object sender, ItemClickEventArgs e)
        {
            try
            {
                View_Objects.PostEditor();
                if (!Data_Objects.Any(row => row.Selected))
                    XtraMessageBox.Show("Выберите карточку/папку для проверки!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {
                    Data_Matches.Clear();
                    
                    SplashScreenManager.ShowForm(this, typeof(MyWaitForm), false, false);
                    SplashScreenManager.Default.SetWaitFormDescription("Идёт поиск соответствий...");

                    List<Unrelated> SelectedRows = Data_Objects.Where(row => row.Selected).ToList();
                    foreach (Unrelated SelectedRow in SelectedRows)
                    {
                        Boolean FindFolder;
                        switch (SelectedRow.DocType)
                        {
                            case RefMarketingFilesCard.Name: FindFolder = false; break;
                            case "Конструкторский документ": FindFolder = true; break;
                            case "Технологический документ": FindFolder = true; break;
                            case "Учет оборудования": FindFolder = true; break;
                            default:
                                MatchCollection Matches = Regex.Matches(SelectedRow.Folder, @"\[ИН \d+\]", RegexOptions.IgnoreCase);
                                if (Matches.Count > 0)
                                {
                                    Int32? Number = Matches[Matches.Count - 1].Value.ToInt32();
                                    if (Number.HasValue)
                                    {
                                        SearchQuery Query_Search = Session.CreateSearchQuery();
                                        CardTypeQuery Query_CardType = Query_Search.AttributiveSearch.CardTypeQueries.AddNew(CardOrd.ID);
                                        SectionQuery Query_Section = Query_CardType.SectionQueries.AddNew(CardOrd.MainInfo.ID);
                                        Query_Section.Operation = SectionQueryOperation.And;
                                        Query_Section.ConditionGroup.Operation = ConditionGroupOperation.Or;
                                        Query_Section.ConditionGroup.Conditions.AddNew(CardOrd.MainInfo.Type, FieldType.RefId, ConditionOperation.Equals, MyHelper.RefType_CD);
                                        Query_Section.ConditionGroup.Conditions.AddNew(CardOrd.MainInfo.Type, FieldType.RefId, ConditionOperation.Equals, MyHelper.RefType_TD);
                                        Query_Section.ConditionGroup.Conditions.AddNew(CardOrd.MainInfo.Type, FieldType.RefId, ConditionOperation.Equals, MyHelper.RefType_EA);
                                        Query_Section = Query_CardType.SectionQueries.AddNew(CardOrd.Properties.ID);
                                        Query_Section.ConditionGroup.Operation = ConditionGroupOperation.And;
                                        Query_Section.ConditionGroup.Conditions.AddNew(CardOrd.Properties.DisplayValue, FieldType.Unistring, ConditionOperation.Equals, Number.Value.ToString());
                                        ConditionGroup Query_Group = Query_Section.ConditionGroup.ConditionGroups.AddNew();
                                        Query_Group.Operation = ConditionGroupOperation.Or;
                                        Query_Group.Conditions.AddNew(CardOrd.Properties.Name, FieldType.Unistring, ConditionOperation.Equals, RefPropertiesCD.Requisities.DocumentNumber);
                                        Query_Group.Conditions.AddNew(CardOrd.Properties.Name, FieldType.Unistring, ConditionOperation.Equals, RefPropertiesEA.Requisities.Number);

                                        Query_Search.Limit = 0;
                                        WriteLog("Сформирован поисковый запрос: " + Query_Search.GetXml(null, true));
                                        List<Guid> CardIds = Session.CardManager.FindCards(Query_Search.GetXml(null, true)).Select(card => card.Id).ToList();

                                        Clear();

                                        WriteLog("Найдено карточек: " + CardIds.Count);
                                        foreach (Guid CardId in CardIds)
                                        {
                                            Unrelated NewRow = Task.Factory.StartNew<Unrelated>(() =>
                                            {
                                                Unrelated UnrelatedCard = null;
                                                try
                                                {
                                                    CardData Card = Session.CardManager.GetCardData(CardId);
                                                    ExtraCard Extra = GetExtraCard(Card);
                                                    if (!Extra.IsNull())
                                                        UnrelatedCard = new Unrelated(Extra.CardType, Card.Description, Extra.CategoryName, Extra.Path, Card.Id);

                                                    Card = null;

                                                    Clear();
                                                }
                                                catch { }
                                                return UnrelatedCard;
                                            }).Result;

                                            if (!NewRow.IsNull())
                                                Data_Matches.Add(NewRow);
                                        }
                                    }
                                }
                                FindFolder = false;
                                break;
                        }
                        if (FindFolder && SelectedRow.CardId.HasValue)
                        {
                            List<Unrelated> NewRows = Task.Factory.StartNew<List<Unrelated>>(() =>
                            {
                                List<Unrelated> UnrelatedFolders = new List<Unrelated>();
                                try
                                {

                                    CardData Card = Session.CardManager.GetCardData(SelectedRow.CardId.Value);
                                    ExtraCard Extra = GetExtraCard(Card);
                                    if (!Extra.IsNull())
                                    {
                                        UnrelatedFolders.AddRange(Directory.GetDirectories(ArchivePath).SelectMany(dir => Directory.GetDirectories(dir, "*[ИН " + Extra.Number +  "]*")).Select(dir => new Unrelated(dir)).ToList());
                                        UnrelatedFolders.AddRange(Directory.GetDirectories(ArchiveDeletePath).SelectMany(dir => Directory.GetDirectories(dir, "*[ИН " + Extra.Number + "]*")).Select(dir => new Unrelated(dir)).ToList());
                                    }

                                    Card = null;

                                    Clear();
                                }
                                catch { }
                                return UnrelatedFolders;
                            }).Result;

                            foreach (Unrelated NewRow in NewRows)
                                Data_Matches.Add(NewRow);
                        }
                    }

                    View_Matches.RefreshData();

                    Item_CurrentState.Caption = "Найдено соответствий: " + Data_Matches.Count;
                }
            }
            catch (Exception Ex) { CallError(Ex); }
            SplashScreenManager.CloseForm(false);
        }

        private void Item_ReloadMatrix_ItemClick (object sender, ItemClickEventArgs e)
        {
            try
            {
                WriteLog("<<< Перезагрузить матрицу >>>");
                Item_CurrentState.Caption = String.Empty;

                if (XtraMessageBox.Show("Все несохраненные изменения будут потеряны.\r\nПродолжить?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    SplashScreenManager.ShowForm(this, typeof(MyWaitForm), false, false);
                    SplashScreenManager.Default.SetWaitFormDescription("Идёт перезагрузка матрицы...");

                    View_CardRights.PostEditor();
                    View_FolderRights.PostEditor();

                    Data_CardRights.Clear();
                    Data_FolderRights.Clear();

                    foreach (TargetObject Tobject in AssignHelper.LoadMatrix(MatrixPath, Settings.Default.CardRightsSheet, Settings.Default.DomainName))
                        Data_CardRights.Add(Tobject);
                    foreach (TargetObject Tobject in AssignHelper.LoadMatrix(MatrixPath, Settings.Default.FolderRightsSheet, Settings.Default.DomainName))
                        Data_FolderRights.Add(Tobject);

                    View_CardRights.RefreshData();
                    View_FolderRights.RefreshData();

                    Item_CurrentState.Caption = "Матрица перезагружена.";
                }
            }
            catch (Exception Ex) { CallError(Ex); }
            SplashScreenManager.CloseForm(false);
        }

        private void Item_SaveMatrix_ItemClick (Object sender, ItemClickEventArgs e)
        {
            try
            {
                WriteLog("<<< Сохранить матрицу >>>");
                Item_CurrentState.Caption = String.Empty;

                View_CardRights.PostEditor();
                View_FolderRights.PostEditor();

                if (XtraMessageBox.Show("Вы уверены, что хотите сохранить изменения в матрице?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (AssignHelper.SaveMatrix(MatrixPath, Settings.Default.CardRightsSheet, Data_CardRights.ToList())
                        && AssignHelper.SaveMatrix(MatrixPath, Settings.Default.FolderRightsSheet, Data_FolderRights.ToList()))
                        XtraMessageBox.Show("Матрица сохранена!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        XtraMessageBox.Show("Не удалось сохранить матрицу!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception Ex) { CallError(Ex); }
        }

        private void Item_SetRightsToFolders_ItemClick (Object sender, ItemClickEventArgs e)
        {
            WriteLog("<<< Назначить на папки >>>");
            Item_CurrentState.Caption = String.Empty;

            SplashScreenManager.ShowForm(this, typeof(MyWaitForm), false, false);

            View_FolderRights.PostEditor();
            List<TargetObject> TObjects = Data_FolderRights.Where(to => to.NeedAssign).ToList();

            Int32 j = 0;

            CardData FoldersCardData = Session.CardManager.GetCardData(FoldersCard.ID, false);
            for (Int32 i = 0; i < TObjects.Count; i++)
            {
                SplashScreenManager.Default.SetWaitFormDescription("Идёт назначение прав на папки (" + (i + 1) + " из " + TObjects.Count + ").");
                Item_CurrentState.Caption = String.Format("Папка: " + TObjects[i].Name);

                SectionQuery Query_Section = Session.CreateSectionQuery();
                Query_Section.ConditionGroup.Operation = ConditionGroupOperation.Or;
                Query_Section.ConditionGroup.Conditions.AddNew(FoldersCard.Folders.Name, FieldType.Unistring, ConditionOperation.Equals, TObjects[i].Name.Split('\\').LastOrDefault());
                Query_Section.ConditionGroup.Conditions.AddNew(FoldersCard.Folders.Name, FieldType.Unistring, ConditionOperation.Equals, TObjects[i].Name);

                RowDataCollection FolderRows = FoldersCardData.Sections[FoldersCard.Folders.ID].FindRows(Query_Section.GetXml(null, true));

                if (FolderRows.Count != 0)
                {
                    RowData FolderRow = FolderRows.Count > 1 ? FolderRows.FirstOrDefault(rd => FolderCard.GetFolder(rd.Id).GetFullFolderName() == TObjects[i].Name) ?? FolderRows[0] : FolderRows[0];

                    CardDataSecurity Rights = FolderRow.GetAccessControl();
                    Rights.SetOwner(new NTAccount(Settings.Default.DomainName, Settings.Default.AdminGroup));
                    Rights = Rights.RemoveExplicitRights();

                    foreach (AssignGroup Group in TObjects[i].Groups)
                        try { Rights.SetAssignGroup(TObjects[i], Group); }
                        catch (Exception ex)
                        {
                            WriteLog("Group - " + Group.Name);
                            CallError(ex);
                        }

                    FolderRow.SetAccessControl(Rights);
                    j++;
                }
                else
                    WriteLog("Не найдена папка: " + TObjects[i].Name);
            }

            Clear();

            SplashScreenManager.CloseForm();
            Item_CurrentState.Caption = "Назначены права на папки (" + j + " из " + TObjects.Count + ").";
        }

        private void Item_SetRightsToCards_ItemClick (Object sender, ItemClickEventArgs e)
        {
            WriteLog("<<< Назначить на карточки >>>");

            SplashScreenManager.ShowForm(this, typeof(MyWaitForm), false, false);
            Item_CurrentState.Caption = String.Empty;

            View_CardRights.PostEditor();
            List<TargetObject> TObjects = Data_CardRights.Where(row => row.NeedAssign).ToList();
            if (TObjects.Count > 0)
            {
                try
                {
                    SelectHelper Helper = new SelectHelper(Context, SelectionType.Category, Guid.Empty, true);
                    List<SelectionItem> Categories = Helper.GetItems().ToList();
                    foreach (TargetObject TObject in TObjects)
                    {
                        Item_CurrentState.Caption = TObject.Name;
                        SelectionItem Category = Categories.FirstOrDefault(category => category.Name == TObject.Name);
                        if (!Category.IsNull() && !Category.Id.IsEmpty())
                        {
                            Item_CurrentState.Caption = "Назначение прав для " + TObject.Name;
                            WriteLog(TObject.Name + " - " + Category.Id);

                            SearchQuery Query_Search = Session.CreateSearchQuery();
                            Query_Search.CombineResults = ConditionGroupOperation.Or;
                            Query_Search.Limit = 0;

                            CardTypeQuery TypeQuery = Query_Search.AttributiveSearch.CardTypeQueries.AddNew(CardOrd.ID);
                            SectionQuery Query = TypeQuery.SectionQueries.AddNew(CardOrd.Categories.ID);
                            Query.ConditionGroup.Operation = ConditionGroupOperation.Or;
                            Query.ConditionGroup.Conditions.AddNew(CardOrd.Categories.CategoryID, FieldType.RefId, ConditionOperation.Equals, Category.Id);

                            TypeQuery = Query_Search.AttributiveSearch.CardTypeQueries.AddNew(CardUni.ID);
                            Query = TypeQuery.SectionQueries.AddNew(CardUni.Categories.ID);
                            Query.ConditionGroup.Operation = ConditionGroupOperation.Or;
                            Query.ConditionGroup.Conditions.AddNew(CardUni.Categories.CategoryID, FieldType.RefId, ConditionOperation.Equals, Category.Id);

                            TypeQuery = Query_Search.AttributiveSearch.CardTypeQueries.AddNew(CardFile.ID);
                            Query = TypeQuery.SectionQueries.AddNew(CardFile.Categories.ID);
                            Query.ConditionGroup.Operation = ConditionGroupOperation.Or;
                            Query.ConditionGroup.Conditions.AddNew(CardFile.Categories.CategoryID, FieldType.RefId, ConditionOperation.Equals, Category.Id);

                            TypeQuery = Query_Search.AttributiveSearch.CardTypeQueries.AddNew(CardInc.ID);
                            Query = TypeQuery.SectionQueries.AddNew(CardInc.Categories.ID);
                            Query.ConditionGroup.Operation = ConditionGroupOperation.Or;
                            Query.ConditionGroup.Conditions.AddNew(CardInc.Categories.CategoryID, FieldType.RefId, ConditionOperation.Equals, Category.Id);

                            TypeQuery = Query_Search.AttributiveSearch.CardTypeQueries.AddNew(CardOut.ID);
                            Query = TypeQuery.SectionQueries.AddNew(CardOut.Categories.ID);
                            Query.ConditionGroup.Operation = ConditionGroupOperation.Or;
                            Query.ConditionGroup.Conditions.AddNew(CardOut.Categories.CategoryID, FieldType.RefId, ConditionOperation.Equals, Category.Id);

                            TypeQuery = Query_Search.AttributiveSearch.CardTypeQueries.AddNew(RefMarketingFilesCard.ID);
                            Query = TypeQuery.SectionQueries.AddNew(RefMarketingFilesCard.Categories.ID);
                            Query.ConditionGroup.Operation = ConditionGroupOperation.Or;
                            Query.ConditionGroup.Conditions.AddNew(RefMarketingFilesCard.Categories.CategoryId, FieldType.RefId, ConditionOperation.Equals, Category.Id);

                            SplashScreenManager.Default.SetWaitFormDescription("Идёт поиск " + TObject.Name);
                            WriteLog("Сформирован поисковый запрос: " + Query_Search.GetXml(null, true));
                            List<Guid> CardIds = Session.CardManager.FindCards(Query_Search.GetXml(null, true)).Select(card => card.Id).ToList();

                            Clear();

                            WriteLog("Найдено карточек: " + CardIds.Count);
                            Int32 Index = 0;
                            foreach (Guid CardId in CardIds)
                            {
                                Index++;
                                SplashScreenManager.Default.SetWaitFormDescription("Идёт обработка карточек (" + Index + " из " + CardIds.Count + ").");
                                WriteLog("Запуск обработки для карточки - " + Index + " - " + CardId);
                                String LogStrings = Task.Factory.StartNew<String>(() =>
                                {
                                    StringBuilder LogString = new StringBuilder();
                                    try
                                    {
                                        CardData Card = Session.CardManager.GetCardData(CardId);

                                        LogString.AppendLine("Идёт обработка карточки - " + Index + " - " + Card.Description + " - " + Card.Id);
                                        CardDataSecurity Rights = Card.GetAccessControl();
                                        Rights.SetOwner(new NTAccount(Settings.Default.DomainName, Settings.Default.AdminGroup));
                                        Rights = Rights.RemoveExplicitRights();

                                        ExtraCard Extra = GetExtraCard(Card);

                                        foreach (AssignGroup Group in TObject.Groups)
                                        {
                                            try { Rights.SetAssignGroup(TObject, Group); }
                                            catch (Exception Ex)
                                            {
                                                LogString.AppendLine("Группа - " + Group.Name);
                                                LogString.AppendLine(Ex.Message);
                                                LogString.AppendLine(Ex.StackTrace);
                                            }

                                            if (Group.DirectoryRights != 0 && !Extra.IsNull())
                                            {
                                                String FolderPath = Extra.Path;
                                                if (!String.IsNullOrEmpty(FolderPath))
                                                {
                                                    DirectoryInfo Folder = new DirectoryInfo(FolderPath);
                                                    if (Folder.Exists)
                                                        try { Folder.SetAssignGroup(TObject, Group); }
                                                        catch (Exception Ex)
                                                        {
                                                            LogString.AppendLine("Группа - " + Group.Name + " - " + Folder.FullName);
                                                            LogString.AppendLine(Ex.Message);
                                                            LogString.AppendLine(Ex.StackTrace);
                                                        }
                                                    else
                                                        LogString.AppendLine("Группа - " + Group.Name + " не существует путь: " + Folder.FullName);
                                                }
                                            }
                                        }

                                        Card.SetAccessControl(Rights);

                                        if (!Extra.IsNull())
                                        {
                                            Enum CardStatus = Extra.Status;
                                            if (!CardStatus.IsNull() && CardStatus is DocumentState && (DocumentState)CardStatus != DocumentState.Draft)
                                                Card.SetAccessControl(Card.GetAccessControl().Restrict());
                                        }

                                        Card = null;

                                        Clear();
                                    }
                                    catch (Exception Ex)
                                    {
                                        LogString.AppendLine(Ex.Message);
                                        LogString.AppendLine(Ex.StackTrace);
                                    }
                                    return LogString.ToString();
                                }).Result;

                                foreach (String LogString in LogStrings.Split(new Char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries))
                                    WriteLog(LogString);
                            }
                        }
                        else
                        {
                            Item_CurrentState.Caption = "Отсутствует категория " + TObject.Name;
                            WriteLog("Отсутствует категория " + TObject.Name);
                        }
                    }

                    Item_CurrentState.Caption = "Права на карточки назначены!";
                }
                catch (Exception Ex)
                {
                    CallError(Ex);
                    Item_CurrentState.Caption = String.Empty;
                }
            }
            else
                Item_CurrentState.Caption = "Не выбраны категории для назначения прав!";
            SplashScreenManager.CloseForm();
        }

        private void Item_SetNoUnreadCards_ItemClick (Object sender, ItemClickEventArgs e)
        {
            WriteLog("<<< Обновить дерево категорий >>>");

            SplashScreenManager.ShowForm(this, typeof(MyWaitForm), false, false);
            SplashScreenManager.Default.SetWaitFormDescription("Идёт обработка папок.");

            Folder RootFolder = FolderCard.GetFolder(Context.GetObject<DocsVision.BackOffice.ObjectModel.Categories>(RefCategories.ID).Main.RootFolderRef);
            SetNoUnreadCards(RootFolder.Folders);

            SplashScreenManager.CloseForm();
        }

        private void Item_SetWDCategory_ItemClick (Object sender, ItemClickEventArgs e)
        {
            try
            {
                View_Objects.PostEditor();
                if (!Data_Objects.Any(row => row.Selected && row.CardId.HasValue))
                    XtraMessageBox.Show("Выберите карточки для назначения категории!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else if(XtraMessageBox.Show("Вы уверены, что хотите переназначить категорию?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    SplashScreenManager.ShowForm(this, typeof(MyWaitForm), false, false);
                    SplashScreenManager.Default.SetWaitFormDescription("Идёт назначение...");

                    List<Unrelated> SelectedRows = Data_Objects.Where(row => row.Selected && row.CardId.HasValue).ToList();
                    Int32 Count = 0;
                    foreach (Unrelated SelectedRow in SelectedRows)
                    {
                        if (SelectedRow.CardId.HasValue && Session.CardManager.GetCardState(SelectedRow.CardId.Value) == ObjectState.Existing)
                        {
                            if (Task.Factory.StartNew<Boolean>(() =>
                                {
                                    CardData Card = Session.CardManager.GetCardData(SelectedRow.CardId.Value);
                                    if (Card.Type.Id == CardOrd.ID)
                                    {
                                        Guid CardType = Card.Sections[CardOrd.MainInfo.ID].FirstRow.GetGuid(CardOrd.MainInfo.Type) ?? Guid.Empty;
                                        if (CardType == MyHelper.RefType_CD || CardType == MyHelper.RefType_TD)
                                        {
                                            if (Card.LockStatus != LockStatus.Free)
                                                Card.ForceUnlock();
                                            if (Card.InUpdate)
                                                Card.CancelUpdate();

                                            Card.PlaceLock();
                                            Card.BeginUpdate();

                                            ExtraCard Extra = ExtraCardCD.GetExtraCard(Card) ?? (ExtraCard)ExtraCardTD.GetExtraCard(Card);

                                            if (!Extra.IsNull())
                                            {

                                                Card.Sections[CardOrd.Categories.ID].FirstRow.SetGuid(CardOrd.Categories.CategoryID, RefCategories_WD);

                                                SectionData PropertiesSection = Card.Sections[CardOrd.Properties.ID];

                                                RowData FileTypeProperty = PropertiesSection.GetProperty(CardType == MyHelper.RefType_CD ? RefPropertiesCD.Requisities.FileType : RefPropertiesTD.Requisities.FileType);
                                                if (!FileTypeProperty.IsNull())
                                                {
                                                    String CategoryName = GetCategoryName(RefCategories_WD);
                                                    FileTypeProperty.SetString(CardOrd.Properties.Value, CategoryName);
                                                    FileTypeProperty.SetString(CardOrd.Properties.TextValue, CategoryName);
                                                    FileTypeProperty.SetString(CardOrd.Properties.DisplayValue, CategoryName);
                                                }

                                                RowData DigestProperty = PropertiesSection.GetProperty(CardType == MyHelper.RefType_CD ? RefPropertiesCD.Requisities.Digest : RefPropertiesTD.Requisities.Digest);
                                                if (!DigestProperty.IsNull())
                                                {
                                                    String Digest = Extra.ToString();
                                                    DigestProperty.SetString(CardOrd.Properties.Value, Digest);
                                                    DigestProperty.SetString(CardOrd.Properties.TextValue, Digest);
                                                    DigestProperty.SetString(CardOrd.Properties.DisplayValue, Digest);

                                                    Card.Description = Digest;
                                                }
                                            }

                                            Card.EndUpdate();
                                            Card.RemoveLock();

                                            return Card.AssignRights();
                                        }

                                    }
                                    return false;
                                }).Result)
                                Count++;
                        }
                    }

                    Item_CurrentState.Caption = "Назначена категория для карточек: " + Count;
                }
            }
            catch (Exception Ex) { CallError(Ex); }
            SplashScreenManager.CloseForm(false);
        }

        private void Item_UploadFiles_ItemClick (Object sender, ItemClickEventArgs e)
        {
            try
            {
                WriteLog("<<< Выгрузить файлы >>>");
                Item_CurrentState.Caption = String.Empty;

                View_FoundFiles.PostEditor();

                List<FoundFile> UploadFiles = Data_FoundFiles.Where(file => file.Selected && Session.CardManager.GetCardState(file.FileCardId) == ObjectState.Existing).ToList();

                if (UploadFiles.Any())
                {
                    DirectoryInfo ArchiveTempFolder = new DirectoryInfo(ArchiveTempPath);
                    DirectoryInfo CurrentTempFolder = new DirectoryInfo(CurrentTempPath);

                    if (ArchiveTempFolder.Exists)
                    {
                        SplashScreenManager.ShowForm(this, typeof(MyWaitForm), false, false);
                        List<KeyValuePair<Guid, Int32>> ErrorCards = new List<KeyValuePair<Guid, Int32>>();
                        WriteLog("Выгружается файлов: " + UploadFiles.Count);
                        Item_CurrentState.Caption = "Выгружается файлов: " + UploadFiles.Count;
                        for (Int32 i = 0; i < UploadFiles.Count; i++)
                        {
                            SplashScreenManager.Default.SetWaitFormDescription("Идёт выгрузка файлов (" + (i + 1) + " из " + UploadFiles.Count + ").");
                            try
                            {
                                String TempFolderName = null;
                                DirectoryInfo TempFolder = null;
                                String MarketingFileName = UploadFiles[i].Name;
                                List<String> MarketingFileFiles = new List<String>();
                                while (MyHelper.CheckDuplication(Session, UploadFiles[i].Category + ". " + MarketingFileName))
                                    MarketingFileName += " 1";

                                CardData FileCardData = Session.CardManager.GetCardData(UploadFiles[i].FileCardId);
                                RowData FileCardMainInfo = FileCardData.Sections[CardFile.MainInfo.ID].FirstRow;
                                Guid VersionedFileId = FileCardMainInfo.GetGuid(CardFile.MainInfo.FileID) ?? Guid.Empty;
                                if (!VersionedFileId.IsEmpty())
                                {
                                    VersionedFileCard VersionedFile = (VersionedFileCard)Session.CardManager.GetCard(VersionedFileId);
                                    if (VersionedFile.Versions.Count > 0)
                                    {
                                        TempFolderName = Path.GetRandomFileName();
                                        String TempFolderPath = Path.Combine(CurrentTempPath, TempFolderName);
                                        TempFolder = CurrentTempFolder.CreateSubdirectory(TempFolderName);

                                        if (VersionedFile.Versions.Count == 1)
                                        {
                                            MarketingFileFiles.Add(VersionedFile.CurrentVersion.Name);
                                            WriteLog("Выгрузка файла " + MarketingFileFiles[MarketingFileFiles.Count - 1] + " на компьютер.");
                                            VersionedFile.CurrentVersion.Download(Path.Combine(TempFolderPath, VersionedFile.CurrentVersion.Name));
                                            WriteLog("Файл выгружен.");
                                        }
                                        else
                                        {
                                            String Format = " (Версия " + new StringBuilder().Insert(0, "0", VersionedFile.Versions.Select(vers => vers.VersionNumber).Max().ToString().Length) + ")";

                                            foreach (FileVersion FileVers in VersionedFile.Versions)
                                            {
                                                MarketingFileFiles.Add(Path.GetFileNameWithoutExtension(FileVers.Name) + FileVers.VersionNumber.ToString(Format) + Path.GetExtension(FileVers.Name));
                                                WriteLog("Выгрузка файла " + MarketingFileFiles[MarketingFileFiles.Count - 1] + " на компьютер.");
                                                FileVers.Download(Path.Combine(TempFolderPath, MarketingFileFiles[MarketingFileFiles.Count - 1]));
                                                WriteLog("Файл выгружен.");
                                            }
                                        }
                                    }
                                }

                                if (!TempFolderName.IsNull() && !TempFolder.IsNull())
                                {
                                    DirectoryInfo ArchiveTempSubFolder = ArchiveTempFolder.CreateSubdirectory(TempFolderName);
                                    foreach (FileInfo UploadFileInfo in TempFolder.GetFiles())
                                    {
                                        WriteLog("Копирование файла " + UploadFileInfo.Name + " во временную папку.");
                                        UploadFileInfo.CopyTo(Path.Combine(ArchiveTempPath, TempFolderName, UploadFileInfo.Name), true);
                                        WriteLog("Файл скопирован.");
                                    }

                                    TempFolder.Delete(true);

                                    String ArchiveTargetPath = MyHelper.PlaceFiles(Session, TempFolderName, UploadFiles[i].Category + ". " + MarketingFileName);

                                    if (ArchiveTargetPath != Boolean.FalseString)
                                    {
                                        CardData MarketingFilesData = Context.CreateCard(RefMarketingFilesCard.ID);

                                        MarketingFilesData.PlaceLock();
                                        MarketingFilesData.BeginUpdate();
                                        
                                        RowData MarketingFilesMainInfo = MarketingFilesData.Sections[RefMarketingFilesCard.MainInfo.ID].FirstRow;
                                        RowData MarketingFilesSystemData = MarketingFilesData.Sections[MarketingFilesData.Type.Sections["System"].Id].FirstRow;
                                        RowDataCollection MarketingFilesCategoriesRows = MarketingFilesData.Sections[RefMarketingFilesCard.Categories.ID].Rows;
                                        RowDataCollection MarketingFilesPropertiesRows = MarketingFilesData.Sections[RefMarketingFilesCard.Properties.ID].Rows;
                                        

                                        MarketingFilesMainInfo.SetString(RefMarketingFilesCard.MainInfo.Name, MarketingFileName);
                                        MarketingFilesSystemData.SetGuid("Kind", KindOfMarketingFilesID);
                                        MarketingFilesMainInfo.SetDateTime(RefMarketingFilesCard.MainInfo.CreationDate, UploadFiles[i].CreationDate);
                                        MarketingFilesMainInfo.SetGuid(RefMarketingFilesCard.MainInfo.Registrar, UploadFiles[i].RegistrarId);
                                        if (MarketingFileFiles.Any())
                                            MarketingFilesMainInfo.SetString(RefMarketingFilesCard.MainInfo.Files, MarketingFileFiles.Aggregate((a, b) => a + "; " + b));
                                        MarketingFilesMainInfo.SetString(RefMarketingFilesCard.MainInfo.Folder, ArchiveTargetPath);

                                        foreach (RowData FileCardCategoryRow in FileCardData.Sections[CardFile.Categories.ID].Rows)
                                            MarketingFilesCategoriesRows.AddNew().SetGuid(RefMarketingFilesCard.Categories.CategoryId, FileCardCategoryRow.GetGuid(CardFile.Categories.CategoryID));

                                        foreach (RowData FileCardPropertyRow in FileCardData.Sections[CardFile.Properties.ID].Rows)
                                        {
                                            RowData MarketingFilesPropertiesRow = MarketingFilesPropertiesRows.AddNew();
                                            MarketingFilesPropertiesRow.SetString(RefMarketingFilesCard.Properties.Name, FileCardPropertyRow.GetString(CardFile.Properties.Name));
                                            MarketingFilesPropertiesRow.SetString(RefMarketingFilesCard.Properties.Value, FileCardPropertyRow.GetString(CardFile.Properties.DisplayValue));
                                        }

                                        MarketingFilesData.Description = UploadFiles[i].Category + ". " + MarketingFileName;

                                        MarketingFilesData.EndUpdate();
                                        MarketingFilesData.RemoveLock();

                                        try { FolderCard.CreateShortcut(Settings.Default.FolderForMarketingFiles, MarketingFilesData.Id, true); }
                                        catch { }

                                        MarketingFilesData.AssignRights();

                                        UploadFiles[i].MarketingFileId = MarketingFilesData.Id;

                                        FolderCard.DeleteCard(UploadFiles[i].FileCardId, false);
                                        UploadFiles[i].Selected = false;
                                    }
                                    else
                                    {
                                        WriteLog("Не удалось выгрузить файлы из папки " + TempFolderName + " для карточки " + UploadFiles[i].FileCardId);
                                        ErrorCards.Add(new KeyValuePair<Guid, Int32>(UploadFiles[i].FileCardId, 1));
                                        ArchiveTempSubFolder.Delete(true);
                                        DirectoryInfo ArchiveTargetFolder = new DirectoryInfo(Path.Combine(ArchivePath, RefMarketingFilesCard.Name, UploadFiles[i].Category + ". " + MarketingFileName));
                                        if (!ArchiveTargetFolder.IsNull() && ArchiveTargetFolder.Exists)
                                            ArchiveTargetFolder.Delete(true);
                                    }
                                }
                                else
                                {
                                    WriteLog("Отсутствуют файлы для выгрузки у карточки " + UploadFiles[i].FileCardId);
                                    ErrorCards.Add(new KeyValuePair<Guid, Int32>(UploadFiles[i].FileCardId, 0));
                                }
                            }
                            catch (Exception Ex)
                            {
                                CallError(Ex);
                                ErrorCards.Add(new KeyValuePair<Guid, Int32>(UploadFiles[i].FileCardId, -1));
                            }
                        }

                        View_FoundFiles.RefreshData();

                        WriteLog("Выгружено файлов " + (UploadFiles.Count - ErrorCards.Count) + " из " + UploadFiles.Count);
                        Item_CurrentState.Caption = "Выгружено файлов " + (UploadFiles.Count - ErrorCards.Count) + " из " + UploadFiles.Count;
                        SplashScreenManager.CloseForm(false);

                        if (ErrorCards.Any())
                        {
                            using (StreamWriter ErrorLog = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.Personal) + @"\RKIT\Archive Manager " + DateTime.Now.ToString("yyyy-MM-dd") + " Errors.lg", true, Encoding.Default))
                            {
                                foreach (KeyValuePair<Guid, Int32> ErrorCard in ErrorCards)
                                {
                                    CardData ErrorCardData = Session.CardManager.GetCardData(ErrorCard.Key);
                                    switch (ErrorCard.Value)
                                    {
                                        case 0: ErrorLog.WriteLine("Отсутствуют файлы для выгрузки у карточки «" + ErrorCardData.Description + "»"); break;
                                        case 1: ErrorLog.WriteLine("Не удалось выгрузить файлы из временной папки у карточки «" + ErrorCardData.Description + "»"); break;
                                        default: ErrorLog.WriteLine("Неизвестная ошибка у карточки «" + ErrorCardData.Description + "»"); break;
                                    }
                                    ErrorLog.WriteLine("Ссылка на карточку: " + ErrorCardData.GetCardUrl());
                                    ErrorLog.WriteLine();
                                    ErrorLog.Flush();
                                }
                                ErrorLog.Close();
                            }

                            XtraMessageBox.Show("Не удалось выгрузить файлов: " + ErrorCards.Count + "." + Environment.NewLine
                                + "Подробности в лог-файле Archive Manager " + DateTime.Now.ToString("yyyy-MM-dd") + " Errors.lg." + Environment.NewLine
                                + "Путь к лог-файлу: " + Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "RKIT") + @"\", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (Exception Ex) { CallError(Ex); }
            SplashScreenManager.CloseForm(false);
        }

        private void MainForm_FormClosed (Object sender, FormClosedEventArgs e)
        {
            try
            {
                Settings.Default.SkinName = Control_DefaultLAF.LookAndFeel.SkinName;
                Settings.Default.FormState = this.WindowState.ToString();
                Settings.Default.FormSize = this.Size;
                Settings.Default.Save();

                if (Session != null)
                {
                    Session.Close();
                    Session.IsNull();
                }

                /* Закрытие логирования */
                WriteLog(@"/// КОНЕЦ ///");

                Log.Close();
                Log = null;
            }
            catch (Exception Ex) { CallError(Ex); }
        }

        private void MainForm_Load (Object sender, EventArgs e)
        {
            try
            {
                /* Запись в лог о запуске */
                WriteLog(@"/// НАЧАЛО ///");
            }
            catch (Exception Ex) { CallError(Ex); }
        }

        private void PopupListBox_ItemCheck (Object sender, DevExpress.XtraEditors.Controls.ItemCheckEventArgs e)
        {
            Int32 FullIndex = PopupListBox.Items.Count - 1;
            if (e.Index == 0)
            {
                if (e.State == CheckState.Checked)
                {
                    PopupListBox.Items[1].CheckState = CheckState.Unchecked;
                    PopupListBox.Items[1].Enabled = false;
                    PopupListBox.Items[FullIndex].Enabled = false;
                }
                else
                {
                    PopupListBox.Items[1].Enabled = true;
                    Boolean Flag = false;
                    for (Int32 i = 2; i < FullIndex; i++)
                        if (PopupListBox.Items[i].CheckState == CheckState.Checked)
                            Flag = true;
                    PopupListBox.Items[FullIndex].Enabled = !Flag;
                }
            }
            else if (e.Index == 1)
            {
                if (e.State == CheckState.Checked)
                {
                    PopupListBox.Items[0].CheckState = CheckState.Unchecked;
                    PopupListBox.Items[0].Enabled = false;
                    PopupListBox.Items[FullIndex].Enabled = false;
                }
                else
                {
                    PopupListBox.Items[0].Enabled = true;
                    Boolean Flag = false;
                    for (Int32 i = 2; i < FullIndex; i++)
                        if (PopupListBox.Items[i].CheckState == CheckState.Checked)
                            Flag = true;
                    PopupListBox.Items[FullIndex].Enabled = !Flag;
                }
            }
            else if (e.Index == FullIndex)
            {
                if (e.State == CheckState.Checked)
                {
                    for (Int32 i = 0; i < e.Index; i++)
                    {
                        PopupListBox.Items[i].CheckState = CheckState.Unchecked;
                        PopupListBox.Items[i].Enabled = false;
                    }
                }
                else
                {
                    for (Int32 i = 0; i < e.Index; i++)
                        PopupListBox.Items[i].Enabled = true;
                }
            }
            else
            {
                if (e.State == CheckState.Checked)
                {
                    PopupListBox.Items[FullIndex].Enabled = false;
                }
                else
                {
                    Boolean Flag = false;
                    for (Int32 i = 0; i < FullIndex; i++)
                        if (PopupListBox.Items[i].CheckState == CheckState.Checked)
                            Flag = true;

                    PopupListBox.Items[FullIndex].Enabled = !Flag;
                }
            }
        }

        private void Repository_Rights_CloseUp (Object sender, CloseUpEventArgs e)
        {
            PopupListBox.ItemCheck -= PopupListBox_ItemCheck;
            PopupListBox = null;
        }

        private void Repository_Rights_GetItemEnabled (Object sender, GetCheckedComboBoxItemEnabledEventArgs e)
        {
            if (e.Index == 0)
            {
                if (e.ListBox.Items[1].CheckState == CheckState.Checked || e.ListBox.Items[e.ListBox.Items.Count - 1].CheckState == CheckState.Checked)
                    e.Enabled = false;
            }
            else if (e.Index == 1)
            {
                if (e.ListBox.Items[0].CheckState == CheckState.Checked || e.ListBox.Items[e.ListBox.Items.Count - 1].CheckState == CheckState.Checked)
                    e.Enabled = false;
            }
            else if (e.Index == e.ListBox.Items.Count - 1)
            {
                if (e.ListBox.Items[e.Index].CheckState != CheckState.Checked)
                    for (Int32 i = 0; i < e.ListBox.Items.Count - 1; i++)
                        if (e.ListBox.Items[i].CheckState == CheckState.Checked)
                            e.Enabled = false;
            }
            else
            {
                if (e.ListBox.Items[e.ListBox.Items.Count - 1].CheckState == CheckState.Checked)
                    e.Enabled = false;
            }
        }

        private void Repository_Rights_Popup (Object sender, EventArgs e)
        {
            PopupContainerForm PopupForm = (sender as DevExpress.Utils.Win.IPopupControl).PopupWindow as PopupContainerForm;
            PopupListBox = PopupForm.ActiveControl as CheckedListBoxControl;
            PopupListBox.ItemCheck += PopupListBox_ItemCheck;
        }

        private void View_FoundFiles_DoubleClick (Object sender, EventArgs e)
        {
            try
            {
                GridHitInfo Info = View_FoundFiles.CalcHitInfo(View_FoundFiles.GridControl.PointToClient(Control.MousePosition));
                if (Info.RowHandle >= 0)
                {
                    FoundFile FileRow = (FoundFile)View_FoundFiles.GetFocusedRow();
                    if (!FileRow.IsNull())
                    {
                        if (FileRow.MarketingFileId.IsEmpty())
                        {
                            if (!FileRow.FileCardId.IsEmpty() && Session.CardManager.GetCardState(FileRow.FileCardId) == ObjectState.Existing)
                            {
                                this.Enabled = false;
                                if (Host.ShowCardModal(FileRow.FileCardId, new Guid("A8F0DE88-D1D6-4D69-A9B7-797E27D5037F"), ActivateMode.Edit))
                                {
                                    FileRow.Refresh(Context);
                                    View_FoundFiles.RefreshData();
                                }
                                this.Enabled = true;
                                this.Focus();
                            }
                        }
                        else if (Session.CardManager.GetCardState(FileRow.MarketingFileId) == ObjectState.Existing)
                        {
                            this.Enabled = false;
                            Host.ShowCardModal(FileRow.MarketingFileId, RefMarketingFilesCard.Modes.OpenCardAndFiles, ActivateMode.Edit);
                            this.Enabled = true;
                            this.Focus();
                        }
                    }
                }
            }
            catch (Exception Ex) { CallError(Ex); }
        }

        private void View_RightGroups_RowClick (Object sender, RowClickEventArgs e)
        {
            GridView SelectedRowView = (GridView)sender;
            GridView ParenView = (GridView)SelectedRowView.ParentView;
            for (Int32 i = 0; i < ParenView.RowCount; i++)
            {
                GridView RowView = (GridView)ParenView.GetDetailView(i, 0);
                if (!RowView.IsNull() && RowView != sender)
                    RowView.FocusedRowHandle = e.RowHandle;
            }
        }

        private void View_Unrelated_DoubleClick (Object sender, EventArgs e)
        {
            try
            {
                if (sender is GridView)
                {
                    GridView View = sender as GridView;
                    GridHitInfo Info = View.CalcHitInfo(View.GridControl.PointToClient(Control.MousePosition));
                    if (Info.RowHandle >= 0)
                    {
                        Unrelated Row = (Unrelated)View.GetFocusedRow();
                        if (!Row.IsNull())
                        {
                            if (Row.CardId.HasValue)
                            {
                                if (!Row.CardId.Value.IsEmpty() && Session.CardManager.GetCardState(Row.CardId.Value) == ObjectState.Existing)
                                    Process.Start(Task.Factory.StartNew<Uri>(() => { return Session.CardManager.GetCardData(Row.CardId.Value).GetCardUrl(); }).Result.ToString());
                            }
                            else if (!Row.Folder.IsNull() && Directory.Exists(Row.Folder))
                                Process.Start("explorer", "\"" + Row.Folder + "\"");
                        }
                    }
                }
            }
            catch (Exception Ex) { CallError(Ex); }
        }

        #endregion

        /*private void Item_CheckApplicability_ItemClick(object sender, ItemClickEventArgs e)
        {
            WriteLog("Проверка применяемости КД.");
            if (this.Edit_Device.SelectedItems.Count == 0)
            {
                XtraMessageBox.Show("Укажите приборы для проверки!");
            }
            else
            {
                CardData UniversalCard = Session.CardManager.GetDictionaryData(RefUniversal.ID);
                MyMultiChooseBoxItemCollection Devices = this.Edit_Device.SelectedItems;
                BindingList<ApplicableError> NewErrors = new BindingList<ApplicableError>();
                Data_Errors.Clear();

                foreach(MyMultiChooseBoxItem DeviceItem in Devices)
                {
                    SplashScreenManager.ShowForm(this, typeof(MyWaitForm), false, false);
                    Guid DeviceID = DeviceItem.ObjectId;
                    string DeviceName = DeviceItem.DisplayValue;
                    SplashScreenManager.Default.SetWaitFormDescription("Идёт анализ документов " + DeviceName);
                    WriteLog("Обработка прибора: " + DeviceName);

                    if (UniversalCard.GetItemPropertyValue(DeviceID, "Код СКБ") != null)
                    {
                        Guid ParentCodeID = UniversalCard.GetItemPropertyValue(DeviceID, "Код СКБ").ToGuid();
                        WriteLog("Корневой Код СКБ: " + UniversalCard.GetItemPropertyDisplayValue(DeviceID, "Код СКБ"));

                        // Поиск действующих КД, входящих в текущий прибор
                        SearchQuery Query = Session.CreateSearchQuery();
                        CardTypeQuery CardType = Query.AttributiveSearch.CardTypeQueries.AddNew(CardOrd.ID);
                        SectionQuery Section = CardType.SectionQueries.AddNew(CardOrd.MainInfo.ID);               
                        Section.Operation = SectionQueryOperation.And;
                        Section.ConditionGroup.Operation = ConditionGroupOperation.And;
                        Section.ConditionGroup.Conditions.AddNew(CardOrd.MainInfo.Type, FieldType.RefId, ConditionOperation.Equals, MyHelper.RefType_CD);

                        Section = CardType.SectionQueries.AddNew(CardOrd.Properties.ID);
                        Section.Operation = SectionQueryOperation.And;
                        Section.ConditionGroup.Operation = ConditionGroupOperation.And;
                        Section.ConditionGroup.Conditions.AddNew(CardOrd.Properties.Value, FieldType.Int, ConditionOperation.Equals, 2);
                        Section.ConditionGroup.Conditions.AddNew(CardOrd.Properties.Name, FieldType.Unistring, ConditionOperation.Equals, RefPropertiesCD.Requisities.State);

                        Section = CardType.SectionQueries.AddNew(CardOrd.SelectedValues.ID);
                        Section.Operation = SectionQueryOperation.And;
                        Section.ConditionGroup.Operation = ConditionGroupOperation.And;
                        Section.ConditionGroup.Conditions.AddNew(CardOrd.SelectedValues.SelectedValue, FieldType.RefId, ConditionOperation.Equals, DeviceID);

                        Query.Limit = 0;

                        WriteLog("Сформирован поисковый запрос: " + Query.GetXml(null, true));
                        CardDataCollection FindCards = Session.CardManager.FindCards(Query.GetXml(null, true));
                        Clear();
                        WriteLog("Найдено карточек: " + FindCards.Count);
                        int i = 1;
                        foreach (CardData Card in FindCards)
                        {
                            SplashScreenManager.Default.SetWaitFormDescription("Идёт анализ документов " + DeviceName + ": " + i + " из " + FindCards.Count);
                            SectionData Properties = Card.Sections[CardOrd.Properties.ID];
                            string Category = Properties.FindRow("@Name = '" + RefPropertiesCD.Requisities.FileType + "'").GetString("Value");
                            RowData Applicable = Properties.FindRow("@Name = '" + RefPropertiesCD.Requisities.Applicable + "'");
                            RowData DevicesList = Properties.FindRow("@Name = '" + RefPropertiesCD.Requisities.Device + "'");
                            RowData Code = Properties.FindRow("@Name = '" + RefPropertiesCD.Requisities.Code + "'");
                            RowDataCollection SelectedApplicable = Applicable.ChildSections[CardOrd.SelectedValues.ID].Rows;
                            RowDataCollection SelectedDevices = DevicesList.ChildSections[CardOrd.SelectedValues.ID].Rows;

                            switch (Category)
                            {
                                case "СД - Спецификация (не платы)":
                                case "СП - Спецификация платы":

                                    if (SelectedApplicable.Any(row => row.GetGuid("SelectedValue") == Code.GetGuid("Value")) && (Code.GetGuid("Value") != ParentCodeID))
                                    {
                                        NewErrors.Add(new ApplicableError(DeviceName, Card.Id.ToString(), Card.Description, Applicable.GetString("DisplayValue"),
                                            "Спецификация не может входить сама в себя!"));
                                        WriteLog("Обнаружена ошибка: " + Card.Description + "(" + Card.Id.ToString() + ")" + " - Спецификация не может входить сама в себя!");
                                    }
                                    break;
                                case "Э2 - Схема электрическая функциональная":
                                case "Э3 - Схема электрическая принципиальная":
                                case "Э4 - Схема электрическая соединений":
                                case "ПЭ - Перечень элементов (платы)":
                                case "ПЭ - Перечень элементов":
                                case "СЧ - Сборочный чертеж платы":
                                case "СБ - Сборочный чертеж":
                                case "ЭМ - Схема электрическая монтажная":
                                case "МЭ - Электромонтажный чертеж":
                                case "Ф1 - Файлы послойные, защитной маски, сверловки, маркировки наносимой краской (герберы)":
                                case "БЗ - Бланк заказа":
                                    if ((SelectedApplicable.Count != 1) || (SelectedApplicable[0].GetGuid("SelectedValue") != Code.GetGuid("Value")))
                                    {
                                        NewErrors.Add(new ApplicableError(DeviceName, Card.Id.ToString(), Card.Description, Applicable.GetString("DisplayValue"),
                                            "Документ должен входить в одноименную спецификацию!"));
                                        WriteLog("Обнаружена ошибка: " + Card.Description + "(" + Card.Id.ToString() + ")" + " - Документ должен входить в одноименную спецификацию!");
                                    }
                                    break;
                                default :
                                    if (SelectedApplicable.Any(row => row.GetGuid("SelectedValue") == Code.GetGuid("Value")) && (Code.GetGuid("Value") != ParentCodeID))
                                    {
                                        NewErrors.Add(new ApplicableError(DeviceName, Card.Id.ToString(), Card.Description, Applicable.GetString("DisplayValue"),
                                            "Спецификация не может входить сама в себя!"));
                                        WriteLog("Обнаружена ошибка: " + Card.Description + "(" + Card.Id.ToString() + ")" + " - Документ не может входить сам в себя!");
                                    }
                                    break;
                            }
                            
                            List<Guid> ApplicableIds = SelectedApplicable.Select(row => row.GetGuid("SelectedValue").ToGuid()).ToList();
                            List<Guid> DeviceIds = SelectedDevices.Select(row => row.GetGuid("SelectedValue").ToGuid()).ToList();

                            // Поиск родительских спецификаций
                            foreach (Guid ApplicableRow in ApplicableIds)
                            {
                                // Поиск действующей родительской спецификации КД
                                Query = Session.CreateSearchQuery();
                                CardType = Query.AttributiveSearch.CardTypeQueries.AddNew(CardOrd.ID);
                                Section = CardType.SectionQueries.AddNew(CardOrd.MainInfo.ID);
                                Section.Operation = SectionQueryOperation.And;
                                Section.ConditionGroup.Operation = ConditionGroupOperation.And;
                                Section.ConditionGroup.Conditions.AddNew(CardOrd.MainInfo.Type, FieldType.RefId, ConditionOperation.Equals, MyHelper.RefType_CD);

                                Section = CardType.SectionQueries.AddNew(CardOrd.Properties.ID);
                                Section.Operation = SectionQueryOperation.And;
                                Section.ConditionGroup.Operation = ConditionGroupOperation.And;
                                Section.ConditionGroup.Conditions.AddNew(CardOrd.Properties.Value, FieldType.Int, ConditionOperation.Equals, 2);
                                Section.ConditionGroup.Conditions.AddNew(CardOrd.Properties.Name, FieldType.Unistring, ConditionOperation.Equals, RefPropertiesCD.Requisities.State);

                                Section = CardType.SectionQueries.AddNew(CardOrd.Properties.ID);
                                Section.Operation = SectionQueryOperation.And;
                                Section.ConditionGroup.Operation = ConditionGroupOperation.And;
                                Section.ConditionGroup.Conditions.AddNew(CardOrd.Properties.Value, FieldType.RefId, ConditionOperation.Equals, ApplicableRow);
                                Section.ConditionGroup.Conditions.AddNew(CardOrd.Properties.Name, FieldType.Unistring, ConditionOperation.Equals, RefPropertiesCD.Requisities.Code);

                                Section = CardType.SectionQueries.AddNew(CardOrd.Properties.ID);
                                Section.Operation = SectionQueryOperation.And;
                                Section.ConditionGroup.Operation = ConditionGroupOperation.And;
                                Section.ConditionGroup.Conditions.AddNew(CardOrd.Properties.Name, FieldType.Unistring, ConditionOperation.Equals, RefPropertiesCD.Requisities.FileType);

                                ConditionGroup Group = Section.ConditionGroup.ConditionGroups.AddNew();
                                Group.Operation = ConditionGroupOperation.Or;
                                switch (Category)
                                {
                                    case "Ф1 - Файлы послойные, защитной маски, сверловки, маркировки наносимой краской (герберы)":
                                    case "БЗ - Бланк заказа":
                                        Group.Conditions.AddNew(CardOrd.Properties.Value, FieldType.Unistring, ConditionOperation.Equals, "ЧП - Чертеж детали - платы");
                                        break;
                                    default:
                                        Group.Conditions.AddNew(CardOrd.Properties.Value, FieldType.Unistring, ConditionOperation.Equals, "СД - Спецификация (не платы)");
                                        Group.Conditions.AddNew(CardOrd.Properties.Value, FieldType.Unistring, ConditionOperation.Equals, "СП - Спецификация платы");
                                        break;
                                }

                                Query.Limit = 0;

                                WriteLog("Сформирован поисковый запрос: " + Query.GetXml(null, true));
                                CardDataCollection ParentCards = Session.CardManager.FindCards(Query.GetXml(null, true));
                                Clear();
                                WriteLog("Найдено карточек: " + ParentCards.Count);

                                // Проверяем количество найденных спецификаций
                                switch (ParentCards.Count)
                                {
                                    case 0:
                                        NewErrors.Add(new ApplicableError(DeviceName, Card.Id.ToString(), Card.Description, Applicable.GetString("DisplayValue"), "Не найден родительский документ " + 
                                            UniversalCard.GetItemName(ApplicableRow) + "!"));
                                        WriteLog("Обнаружена ошибка: " + Card.Description + "(" + Card.Id.ToString() + ")" + " - Не найден родительский документ " + 
                                            UniversalCard.GetItemName(ApplicableRow) + "!");
                                        break;
                                    case 1:
                                        break;
                                    default:
                                        NewErrors.Add(new ApplicableError(DeviceName, Card.Id.ToString(), Card.Description, Applicable.GetString("DisplayValue"), 
                                            "Количество найденных родительских документов " + UniversalCard.GetItemName(ApplicableRow) + ": " + ParentCards.Count + "!"));
                                        WriteLog("Обнаружена ошибка: " + Card.Description + "(" + Card.Id.ToString() + ")" + " - Количество найденных родительских документов " +
                                            UniversalCard.GetItemName(ApplicableRow) + ": " + ParentCards.Count + "!");
                                        break;
                                }

                                // Проверяем соответствие приборов у найденных спецификаций
                                foreach (CardData ParentCard in ParentCards)
                                {
                                    SectionData ParentCardProperties = ParentCard.Sections[CardOrd.Properties.ID];
                                    RowData ParentCardDevicesList = ParentCardProperties.FindRow("@Name = '" + RefPropertiesCD.Requisities.Device + "'");
                                    RowDataCollection ParentCardSelectedDevices = ParentCardDevicesList.ChildSections[CardOrd.SelectedValues.ID].Rows;
                                    List<Guid> ParentCardDeviceIds = ParentCardSelectedDevices.Select(row => row.GetGuid("SelectedValue").ToGuid()).ToList();

                                    if (ParentCardDeviceIds.Except(DeviceIds.Intersect(ParentCardDeviceIds)).Any())
                                    {
                                        string ErrorDevices = String.Join("; ", ParentCardDeviceIds.Except(DeviceIds.Intersect(ParentCardDeviceIds)).Select(row => UniversalCard.GetItemName(row.ToGuid())));
                                        
                                        NewErrors.Add(new ApplicableError(DeviceName, Card.Id.ToString(), Card.Description, Applicable.GetString("DisplayValue"),
                                            "Перечень приборов не соответствует родительскому документу " + UniversalCard.GetItemName(ApplicableRow) + "! Расхождение: " + ErrorDevices));
                                        WriteLog("Обнаружена ошибка: " + Card.Description + "(" + Card.Id.ToString() + ")" + " - Перечень приборов не соответствует родительскому документу " + 
                                            UniversalCard.GetItemName(ApplicableRow) + "!");
                                    }
                                }
                            }
                            i++;
                        }
                    }
                }
                foreach(ApplicableError NewError in NewErrors)
                    Data_Errors.Add(NewError);
                Item_CurrentState.Caption = "Найдено ошибок: " + Data_Errors.Count;
                ViewErrors.RefreshData();
                SplashScreenManager.CloseForm();
            }
        }*/

        private void ViewErrors_DoubleClick(Object sender, EventArgs e)
        {
            try
            {
                if (sender is GridView)
                {
                    GridView View = sender as GridView;
                    GridHitInfo Info = View.CalcHitInfo(View.GridControl.PointToClient(Control.MousePosition));
                    if (Info.RowHandle >= 0)
                    {
                        ApplicableError Row = (ApplicableError)View.GetFocusedRow();
                        if (!Row.IsNull())
                        {
                            if (Row.DocumentId != null && Session.CardManager.GetCardState(new Guid (Row.DocumentId)) == ObjectState.Existing)
                                Process.Start(Task.Factory.StartNew<Uri>(() => { return Session.CardManager.GetCardData(new Guid(Row.DocumentId)).GetCardUrl(); }).Result.ToString());
                        }
                    }
                }
            }
            catch (Exception Ex) { CallError(Ex); }
        }

        private void collectionControlView1_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void collectionControlView1_EditValueChanged_1(object sender, EventArgs e)
        {

        }

        /*private void Item_CreateHierarchyOfApplicability_ItemClick(object sender, ItemClickEventArgs e)
        {
            WriteLog("Построение дерева применяемости КД.");
            if (this.Edit_Device.SelectedItems.Count == 0)
            {
                XtraMessageBox.Show("Укажите приборы!");
            }
            else
            {
                MyMultiChooseBoxItemCollection Devices = this.Edit_Device.SelectedItems;
                string DevicesList = String.Join(", ", Devices.Select(row => row.DisplayValue));
                string MessageText = Devices.Count == 1 ? "Текущее дерево документации прибора " + DevicesList + " будет удалено без возможности восстановления. Продолжить?" :
                    "Текущее дерево документации приборов " + DevicesList + " будет удалено без возможности восстановления. Продолжить?";

                DialogResult result = XtraMessageBox.Show(MessageText, "Внимание!", MessageBoxButtons.YesNo);
                if (result == DialogResult.No)
                    return;

                SplashScreenManager.ShowForm(this, typeof(MyWaitForm), false, false);

                CardData UniversalCard = Session.CardManager.GetDictionaryData(RefUniversal.ID);
                BindingList<DocumentsFolder> NewFolders = new BindingList<DocumentsFolder>();
                SearchCard MySearchCard = (SearchCard)Session.CardManager.GetCard(SavedSearchCard.ID);
                ViewCard MyViewCard = (ViewCard)Session.CardManager.GetCard(SavedViewCard.ID);
                //SavedSearchGroup Serches = MySearchCard.Groups.Any(row => row.Name == "Запросы") ? MySearchCard.Groups.First(row => row.Name == "Запросы") : MySearchCard.Groups.AddNew("Запросы");
                //SavedSearchGroup ArhiveGroup = Serches.Groups.Any(row => row.Name == "Архив") ? Serches.Groups.First(row => row.Name == "Архив") : Serches.Groups.AddNew("Архив");
                SavedSearchGroup HierarchyGroup = MySearchCard.Groups.Any(row => row.Name == "Дерево КД") ? MySearchCard.Groups.First(row => row.Name == "Дерево КД") : MySearchCard.Groups.AddNew("Дерево КД");
                SavedView View = MyViewCard.Views.First(row => row.Name == "Дерево КД");

                foreach(MyMultiChooseBoxItem DeviceItem in Devices)
                {
                    Guid DeviceID = DeviceItem.ObjectId;
                    string DeviceName = DeviceItem.DisplayValue;
                    SplashScreenManager.Default.SetWaitFormDescription("Идёт удаление дерева документов " + DeviceName);
                    WriteLog("Обработка прибора: " + DeviceName);

                    if ((UniversalCard.GetItemPropertyValue(DeviceID, "Код СКБ") != null) && (UniversalCard.GetItemPropertyValue(DeviceID, "Папка в дереве DV") != null))
                    {
                        Folder ParentFolder = FolderCard.GetFolder(UniversalCard.GetItemPropertyValue(DeviceID, "Папка в дереве DV").ToGuid());
                        Guid ParentCodeID = UniversalCard.GetItemPropertyValue(DeviceID, "Код СКБ").ToGuid();
                        WriteLog("Корневой Код СКБ: " + UniversalCard.GetItemPropertyDisplayValue(DeviceID, "Код СКБ"));
                        WriteLog("Корневая папка: " + UniversalCard.GetItemPropertyDisplayValue(DeviceID, "Папка в дереве DV"));

                        // Удаляем старое дерево документов
                        if (ParentFolder.Folders.Count > 0)
                            ParentFolder.Folders.Clear();

                        // Удаляем старые поисковые запросы дерева документов
                        SavedSearchGroup DeviceGroup = HierarchyGroup.Groups.Any(row => row.Name == DeviceName) ? HierarchyGroup.Groups.First(row => row.Name == DeviceName) : HierarchyGroup.Groups.AddNew(DeviceName);
                        DeviceGroup.Queries.Clear();
                        WriteLog("Дерево документов " + DeviceName + " удалено.");

                        SplashScreenManager.Default.SetWaitFormDescription("Идёт поиск корневого документа " + DeviceName);
                        // Поиск действующей спецификации с корневым номером
                        SearchQuery Query = Session.CreateSearchQuery();
                        CardTypeQuery CardType = Query.AttributiveSearch.CardTypeQueries.AddNew(CardOrd.ID);
                        SectionQuery Section = CardType.SectionQueries.AddNew(CardOrd.MainInfo.ID);
                        Section.Operation = SectionQueryOperation.And;
                        Section.ConditionGroup.Operation = ConditionGroupOperation.And;
                        Section.ConditionGroup.Conditions.AddNew(CardOrd.MainInfo.Type, FieldType.RefId, ConditionOperation.Equals, MyHelper.RefType_CD);
                        // Статус = "Действует"
                        Section = CardType.SectionQueries.AddNew(CardOrd.Properties.ID);
                        Section.Operation = SectionQueryOperation.And;
                        Section.ConditionGroup.Operation = ConditionGroupOperation.And;
                        ConditionGroup Group = Section.ConditionGroup.ConditionGroups.AddNew();
                        Group.Operation = ConditionGroupOperation.Or;
                        Group.Conditions.AddNew(CardOrd.Properties.Value, FieldType.Int, ConditionOperation.Equals, 11);
                        Group.Conditions.AddNew(CardOrd.Properties.Value, FieldType.Int, ConditionOperation.Equals, 2);
                        //Section.ConditionGroup.Conditions.AddNew(CardOrd.Properties.Value, FieldType.Int, ConditionOperation.Equals, 11);
                        Section.ConditionGroup.Conditions.AddNew(CardOrd.Properties.Name, FieldType.Unistring, ConditionOperation.Equals, RefPropertiesCD.Requisities.State);
                        // Категория = "СД - Спецификация (не платы)"
                        Section = CardType.SectionQueries.AddNew(CardOrd.Properties.ID);
                        Section.Operation = SectionQueryOperation.And;
                        Section.ConditionGroup.Operation = ConditionGroupOperation.And;
                        Section.ConditionGroup.Conditions.AddNew(CardOrd.Properties.Value, FieldType.Unistring, ConditionOperation.Equals, "СД - Спецификация (не платы)");
                        Section.ConditionGroup.Conditions.AddNew(CardOrd.Properties.Name, FieldType.Unistring, ConditionOperation.Equals, RefPropertiesCD.Requisities.FileType);
                        // Код СКБ = корневой код СКБ
                        Section = CardType.SectionQueries.AddNew(CardOrd.Properties.ID);
                        Section.Operation = SectionQueryOperation.And;
                        Section.ConditionGroup.Operation = ConditionGroupOperation.And;
                        Section.ConditionGroup.Conditions.AddNew(CardOrd.Properties.Value, FieldType.RefId, ConditionOperation.Equals, ParentCodeID);
                        Section.ConditionGroup.Conditions.AddNew(CardOrd.Properties.Name, FieldType.Unistring, ConditionOperation.Equals, RefPropertiesCD.Requisities.Code);
                        Query.Limit = 0;

                        WriteLog("Сформирован поисковый запрос: " + Query.GetXml(null, true));
                        CardDataCollection FindCards = Session.CardManager.FindCards(Query.GetXml(null, true));
                        Clear();

                        if (FindCards.Count == 1)
                        {
                            WriteLog("Найдена одна действующая корневая спецификация для прибора " + DeviceName + ".");
                            CardData Card = FindCards[0];
                            DocumentsFolder NewFolder = new DocumentsFolder(ParentFolder, Card, DeviceGroup, View, FolderCard);
                            NewFolders.Add(NewFolder);

                            while (NewFolders.Count > 0)
                            {
                                SplashScreenManager.Default.SetWaitFormDescription("Идёт построение. Документов к обработке: " + NewFolders.Count);
                                DocumentsFolder CurrentFolder = NewFolders[0];

                                // Поиск дочерних документов
                                Query = Session.CreateSearchQuery();
                                CardType = Query.AttributiveSearch.CardTypeQueries.AddNew(CardOrd.ID);
                                Section = CardType.SectionQueries.AddNew(CardOrd.MainInfo.ID);
                                Section.Operation = SectionQueryOperation.And;
                                Section.ConditionGroup.Operation = ConditionGroupOperation.And;
                                Section.ConditionGroup.Conditions.AddNew(CardOrd.MainInfo.Type, FieldType.RefId, ConditionOperation.Equals, MyHelper.RefType_CD);
                                // Статус = "Действует"
                                Section = CardType.SectionQueries.AddNew(CardOrd.Properties.ID);
                                Section.Operation = SectionQueryOperation.And;
                                Section.ConditionGroup.Operation = ConditionGroupOperation.And;
                                Group = Section.ConditionGroup.ConditionGroups.AddNew();
                                Group.Operation = ConditionGroupOperation.Or;
                                Group.Conditions.AddNew(CardOrd.Properties.Value, FieldType.Int, ConditionOperation.Equals, 11);
                                Group.Conditions.AddNew(CardOrd.Properties.Value, FieldType.Int, ConditionOperation.Equals, 2);
                                //Section.ConditionGroup.Conditions.AddNew(CardOrd.Properties.Value, FieldType.Int, ConditionOperation.Equals, 2);
                                Section.ConditionGroup.Conditions.AddNew(CardOrd.Properties.Name, FieldType.Unistring, ConditionOperation.Equals, RefPropertiesCD.Requisities.State);
                                // Код СКБ = родительский код СКБ
                                Section = CardType.SectionQueries.AddNew(CardOrd.SelectedValues.ID);
                                Section.Operation = SectionQueryOperation.And;
                                Section.ConditionGroup.Operation = ConditionGroupOperation.And;
                                Section.ConditionGroup.Conditions.AddNew(CardOrd.SelectedValues.SelectedValue, FieldType.RefId, ConditionOperation.Equals, CurrentFolder.CodeID);
                                Query.Limit = 0;

                                WriteLog("Сформирован поисковый запрос для дочерних документов спецификации " + CurrentFolder.CodeName + ": " + Query.GetXml(null, true));
                                CardDataCollection FindСhildCards = Session.CardManager.FindCards(Query.GetXml(null, true));
                                Clear();
                                WriteLog("Найдено дочерних карточек: " + FindСhildCards.Count);

                                foreach (CardData СhildCard in FindСhildCards)
                                {
                                    if (СhildCard.Id != CurrentFolder.DocumentID)
                                    {
                                        NewFolder = new DocumentsFolder(CurrentFolder.Folder, СhildCard, DeviceGroup, View, FolderCard);
                                        if ((NewFolder.DocumentType == "СД - Спецификация (не платы)") || 
                                            (NewFolder.DocumentType == "СП - Спецификация платы") ||
                                            (NewFolder.DocumentType == "ЧП - Чертеж детали - платы") || 
                                            (NewFolder.DocumentType == "ЧД - Чертеж детали"))
                                            NewFolders.Add(NewFolder);
                                    }
                                }
                                NewFolders.RemoveAt(0);
                            }
                        }
                        else
                        {
                            switch (FindCards.Count)
                            {
                                case 0:
                                    WriteLog("Ошибка! Не найдено ни одной действующей корневой спецификации для прибора " + DeviceName + ".");
                                    break;
                                default:
                                    WriteLog("Ошибка! Найдено действующих корневых спецификаций: " + FindCards.Count + ".");
                                    break;
                            }
                        }
                    }
                    else
                    {
                        WriteLog("Ошибка! Для прибора " + DeviceName + " не указан код СКБ или папка в справочнике приборов и комплектующих.");
                    }
                }
                SplashScreenManager.CloseForm();
                Item_CurrentState.Caption = "Обработка завершена.";
            }                           
        }*/
    }
}