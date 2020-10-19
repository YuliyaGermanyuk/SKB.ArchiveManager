using System.Collections;

namespace SKB.ArchiveManager
{
    partial class ArchiveManagerForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            DevExpress.XtraSplashScreen.SplashScreenManager Manager_SplashScreen = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::SKB.Base.Forms.MySplashScreen), true, true);
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            DevExpress.XtraGrid.GridLevelNode gridLevelNode2 = new DevExpress.XtraGrid.GridLevelNode();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ArchiveManagerForm));
            this.View_CardRightGroups = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Column_Name_CardGroup = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Column_Rights_CardGroup = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Repository_CardRights = new DevExpress.XtraEditors.Repository.RepositoryItemCheckedComboBoxEdit();
            this.Control_CardRights = new DevExpress.XtraGrid.GridControl();
            this.BindingSource_TargetObject = new System.Windows.Forms.BindingSource(this.components);
            this.View_CardRights = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Column_Name_Card = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Column_NeedAssign_Card = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Column_NeedInherit_Card = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Control_Ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.Item_CurrentState = new DevExpress.XtraBars.BarStaticItem();
            this.Item_Theme = new DevExpress.XtraBars.BarSubItem();
            this.Item_CheckGroups = new DevExpress.XtraBars.BarButtonItem();
            this.Item_SetRightsToFolders = new DevExpress.XtraBars.BarButtonItem();
            this.Item_SetRightsToCards = new DevExpress.XtraBars.BarButtonItem();
            this.Item_Find = new DevExpress.XtraBars.BarButtonItem();
            this.Item_UploadFiles = new DevExpress.XtraBars.BarButtonItem();
            this.Item_SetNoUnreadCards = new DevExpress.XtraBars.BarButtonItem();
            this.Item_FindUnrelatedCards = new DevExpress.XtraBars.BarButtonItem();
            this.Item_FindUnrelatedFolders = new DevExpress.XtraBars.BarButtonItem();
            this.Item_FindMatchByIN = new DevExpress.XtraBars.BarButtonItem();
            this.Item_SetWDCategory = new DevExpress.XtraBars.BarButtonItem();
            this.Item_CheckAll = new DevExpress.XtraBars.BarButtonItem();
            this.Item_UncheckAll = new DevExpress.XtraBars.BarButtonItem();
            this.Item_ShowDetails = new DevExpress.XtraBars.BarButtonItem();
            this.Item_HideDetails = new DevExpress.XtraBars.BarButtonItem();
            this.Item_SaveMatrix = new DevExpress.XtraBars.BarButtonItem();
            this.Item_ReloadMatrix = new DevExpress.XtraBars.BarButtonItem();
            this.Item_CheckApplicability = new DevExpress.XtraBars.BarButtonItem();
            this.Item_CreateHierarchyOfApplicability = new DevExpress.XtraBars.BarButtonItem();
            this.Page_AssignRights = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.PageGroup_Expand = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.PageGroup_EditMatrix = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.PageGroup_Matrix = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.PageGroup_AssignRights = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.Page_Correction = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.PageGroup_Categories = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.Page_ArchiveAnalyzing = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.PageGroup_ArchiveSearch = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.PageGroup_ArchiveFix = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.Page_UploadFilesToServer = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.PageGroup_UploadFilesToServer = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.Page_ControlOfApplicability = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.PageGroup_ControlOfApplicability = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.StatusBar_StateBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.View_FolderGroupRights = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Column_Name_FolderGroup = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Column_Rights_FolderGroup = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Repository_FolderRigths = new DevExpress.XtraEditors.Repository.RepositoryItemCheckedComboBoxEdit();
            this.Control_FolderRights = new DevExpress.XtraGrid.GridControl();
            this.View_FolderRights = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Column_Name_Folder = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Column_NeedInherit_Folder = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Column_NeedAssign_Folder = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Edit_IfPattern = new DevExpress.XtraEditors.TextEdit();
            this.Control_Layout = new DevExpress.XtraLayout.LayoutControl();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.Control_Errors = new DevExpress.XtraGrid.GridControl();
            this.ViewErrors = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Column_Device = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Column_Document_Id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Column_Document_Description = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Column_Applicability = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Column_Error_Text = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lcg_Bugs = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.Control_Matches = new DevExpress.XtraGrid.GridControl();
            this.BindingSource_Unrelated = new System.Windows.Forms.BindingSource(this.components);
            this.View_Matches = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Column_Selected_Match = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Column_DocType_Match = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Column_DocName_Match = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Сolumn_Category_Match = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Column_Folder_Match = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Column_CardId_Match = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Repository_Matches_Guid = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.Button_Replace = new DevExpress.XtraEditors.SimpleButton();
            this.Button_SavePath = new DevExpress.XtraEditors.SimpleButton();
            this.Button_CheckPath = new DevExpress.XtraEditors.SimpleButton();
            this.Edit_TotalFileSize = new DevExpress.XtraEditors.SpinEdit();
            this.Button_UnselectAll = new DevExpress.XtraEditors.SimpleButton();
            this.Button_SelectAll = new DevExpress.XtraEditors.SimpleButton();
            this.Control_FoundFiles = new DevExpress.XtraGrid.GridControl();
            this.BindingSource_FoundFile = new System.Windows.Forms.BindingSource(this.components);
            this.View_FoundFiles = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Column_Selected_File = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Column_Name_File = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Column_Size_File = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Repository_FileSize = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.Column_Category_File = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Column_Registrar_File = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Column_CreationDate_File = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Repository_DateEdit = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.Edit_DVFolder = new DevExpress.XtraEditors.ButtonEdit();
            this.Edit_FileSize = new DevExpress.XtraEditors.SpinEdit();
            this.Edit_Action = new DevExpress.XtraEditors.ComboBoxEdit();
            this.Control_Objects = new DevExpress.XtraGrid.GridControl();
            this.View_Objects = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Column_Selected_Object = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Column_DocType_Object = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Column_DocName_Object = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Column_Category_Object = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Column_Folder_Object = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Column_CardId_Object = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Repository_Guid = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.Edit_FindPattern = new DevExpress.XtraEditors.TextEdit();
            this.Edit_ReplacePattern = new DevExpress.XtraEditors.TextEdit();
            this.Edit_NewPath = new DevExpress.XtraEditors.ButtonEdit();
            this.Edit_OldPath = new DevExpress.XtraEditors.ButtonEdit();
            this.Edit_CardId = new DevExpress.XtraEditors.ButtonEdit();
            this.lcg = new DevExpress.XtraLayout.LayoutControlGroup();
            this.Control_Tabs = new DevExpress.XtraLayout.TabbedControlGroup();
            this.lcg_AssignRights = new DevExpress.XtraLayout.LayoutControlGroup();
            this.Control_Matrix = new DevExpress.XtraLayout.TabbedControlGroup();
            this.lcg_FolderRirhtsMatrix = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lci_Control_FolderRights = new DevExpress.XtraLayout.LayoutControlItem();
            this.lcg_CardRightsMatrix = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lci_Control_CardRights = new DevExpress.XtraLayout.LayoutControlItem();
            this.lcg_PathCorrection = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lcg_PathCorrection_Cards = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lci_Edit_IfPattern = new DevExpress.XtraLayout.LayoutControlItem();
            this.lci_Edit_FindPattern = new DevExpress.XtraLayout.LayoutControlItem();
            this.lci_Edit_ReplacePattern = new DevExpress.XtraLayout.LayoutControlItem();
            this.lci_Button_Replace = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem12 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.lcg_PathCorrection_Card = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lci_Edit_CardId = new DevExpress.XtraLayout.LayoutControlItem();
            this.lci_Edit_OldPath = new DevExpress.XtraLayout.LayoutControlItem();
            this.lci_Edit_NewPath = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem10 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem11 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.lcg_ArchiveAnalyzing = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lcg_UnrelatedObjects = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lci_Control_UnrelatedDirs = new DevExpress.XtraLayout.LayoutControlItem();
            this.lcg_Matches = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lci_Control_Matches = new DevExpress.XtraLayout.LayoutControlItem();
            this.splitterItem1 = new DevExpress.XtraLayout.SplitterItem();
            this.lcg_UploadFilesToServer = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lci_Action = new DevExpress.XtraLayout.LayoutControlItem();
            this.lci_Edit_FileSize = new DevExpress.XtraLayout.LayoutControlItem();
            this.lci_Edit_DVFolder = new DevExpress.XtraLayout.LayoutControlItem();
            this.lci_Control_FoundFiles = new DevExpress.XtraLayout.LayoutControlItem();
            this.lci_Button_SelectAll = new DevExpress.XtraLayout.LayoutControlItem();
            this.lci_Button_UnselectAll = new DevExpress.XtraLayout.LayoutControlItem();
            this.lci_Edit_TotalFileSize = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem3 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem4 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem5 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem6 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem7 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem8 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem9 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.Ing_ControlOfApplicability = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.lcg_Devices = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.Control_DefaultLAF = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            this.Dialog_Folder = new System.Windows.Forms.FolderBrowserDialog();
            this.colName1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNeedInherit1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNeedAssign1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInheritance1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPropagation1 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.View_CardRightGroups)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Repository_CardRights)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Control_CardRights)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSource_TargetObject)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.View_CardRights)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Control_Ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.View_FolderGroupRights)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Repository_FolderRigths)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Control_FolderRights)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.View_FolderRights)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Edit_IfPattern.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Control_Layout)).BeginInit();
            this.Control_Layout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Control_Errors)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ViewErrors)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcg_Bugs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Control_Matches)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSource_Unrelated)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.View_Matches)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Repository_Matches_Guid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Edit_TotalFileSize.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Control_FoundFiles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSource_FoundFile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.View_FoundFiles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Repository_FileSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Repository_DateEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Repository_DateEdit.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Edit_DVFolder.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Edit_FileSize.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Edit_Action.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Control_Objects)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.View_Objects)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Repository_Guid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Edit_FindPattern.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Edit_ReplacePattern.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Edit_NewPath.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Edit_OldPath.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Edit_CardId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Control_Tabs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcg_AssignRights)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Control_Matrix)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcg_FolderRirhtsMatrix)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lci_Control_FolderRights)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcg_CardRightsMatrix)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lci_Control_CardRights)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcg_PathCorrection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcg_PathCorrection_Cards)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lci_Edit_IfPattern)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lci_Edit_FindPattern)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lci_Edit_ReplacePattern)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lci_Button_Replace)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcg_PathCorrection_Card)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lci_Edit_CardId)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lci_Edit_OldPath)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lci_Edit_NewPath)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcg_ArchiveAnalyzing)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcg_UnrelatedObjects)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lci_Control_UnrelatedDirs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcg_Matches)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lci_Control_Matches)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitterItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcg_UploadFilesToServer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lci_Action)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lci_Edit_FileSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lci_Edit_DVFolder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lci_Control_FoundFiles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lci_Button_SelectAll)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lci_Button_UnselectAll)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lci_Edit_TotalFileSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ing_ControlOfApplicability)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcg_Devices)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            this.SuspendLayout();
            // 
            // View_CardRightGroups
            // 
            this.View_CardRightGroups.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.Column_Name_CardGroup,
            this.Column_Rights_CardGroup});
            this.View_CardRightGroups.GridControl = this.Control_CardRights;
            this.View_CardRightGroups.Name = "View_CardRightGroups";
            this.View_CardRightGroups.OptionsView.ShowGroupPanel = false;
            this.View_CardRightGroups.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.View_RightGroups_RowClick);
            // 
            // Column_Name_CardGroup
            // 
            this.Column_Name_CardGroup.AppearanceHeader.Options.UseTextOptions = true;
            this.Column_Name_CardGroup.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Column_Name_CardGroup.Caption = "Группа безопасности";
            this.Column_Name_CardGroup.FieldName = "Name";
            this.Column_Name_CardGroup.Name = "Column_Name_CardGroup";
            this.Column_Name_CardGroup.Visible = true;
            this.Column_Name_CardGroup.VisibleIndex = 0;
            this.Column_Name_CardGroup.Width = 315;
            // 
            // Column_Rights_CardGroup
            // 
            this.Column_Rights_CardGroup.AppearanceCell.Options.UseTextOptions = true;
            this.Column_Rights_CardGroup.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Column_Rights_CardGroup.AppearanceHeader.Options.UseTextOptions = true;
            this.Column_Rights_CardGroup.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Column_Rights_CardGroup.Caption = "Права на карточку";
            this.Column_Rights_CardGroup.ColumnEdit = this.Repository_CardRights;
            this.Column_Rights_CardGroup.FieldName = "Rights";
            this.Column_Rights_CardGroup.Name = "Column_Rights_CardGroup";
            this.Column_Rights_CardGroup.Visible = true;
            this.Column_Rights_CardGroup.VisibleIndex = 1;
            this.Column_Rights_CardGroup.Width = 350;
            // 
            // Repository_CardRights
            // 
            this.Repository_CardRights.AutoHeight = false;
            this.Repository_CardRights.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.Repository_CardRights.Items.AddRange(new DevExpress.XtraEditors.Controls.CheckedListBoxItem[] {
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("Ч", "Ч"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("Ч+", "Ч+"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("ИС", "ИС"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("У", "У"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("К", "К"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("ПП", "ПП")});
            this.Repository_CardRights.Name = "Repository_CardRights";
            this.Repository_CardRights.SelectAllItemVisible = false;
            this.Repository_CardRights.SeparatorChar = ';';
            this.Repository_CardRights.GetItemEnabled += new DevExpress.XtraEditors.Controls.GetCheckedComboBoxItemEnabledEventHandler(this.Repository_Rights_GetItemEnabled);
            this.Repository_CardRights.CloseUp += new DevExpress.XtraEditors.Controls.CloseUpEventHandler(this.Repository_Rights_CloseUp);
            this.Repository_CardRights.Popup += new System.EventHandler(this.Repository_Rights_Popup);
            // 
            // Control_CardRights
            // 
            this.Control_CardRights.DataSource = this.BindingSource_TargetObject;
            gridLevelNode1.LevelTemplate = this.View_CardRightGroups;
            gridLevelNode1.RelationName = "Groups";
            this.Control_CardRights.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.Control_CardRights.Location = new System.Drawing.Point(25, 69);
            this.Control_CardRights.MainView = this.View_CardRights;
            this.Control_CardRights.MenuManager = this.Control_Ribbon;
            this.Control_CardRights.Name = "Control_CardRights";
            this.Control_CardRights.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.Repository_CardRights});
            this.Control_CardRights.Size = new System.Drawing.Size(701, 332);
            this.Control_CardRights.TabIndex = 23;
            this.Control_CardRights.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.View_CardRights,
            this.View_CardRightGroups});
            // 
            // BindingSource_TargetObject
            // 
            this.BindingSource_TargetObject.DataSource = typeof(SKB.Base.AssignRights.TargetObject);
            // 
            // View_CardRights
            // 
            this.View_CardRights.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.Column_Name_Card,
            this.Column_NeedAssign_Card,
            this.Column_NeedInherit_Card});
            this.View_CardRights.GridControl = this.Control_CardRights;
            this.View_CardRights.Name = "View_CardRights";
            this.View_CardRights.OptionsDetail.ShowDetailTabs = false;
            this.View_CardRights.OptionsView.ShowGroupPanel = false;
            // 
            // Column_Name_Card
            // 
            this.Column_Name_Card.AppearanceHeader.Options.UseTextOptions = true;
            this.Column_Name_Card.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Column_Name_Card.Caption = "Категория документов";
            this.Column_Name_Card.FieldName = "Name";
            this.Column_Name_Card.Name = "Column_Name_Card";
            this.Column_Name_Card.OptionsColumn.ReadOnly = true;
            this.Column_Name_Card.Visible = true;
            this.Column_Name_Card.VisibleIndex = 0;
            this.Column_Name_Card.Width = 486;
            // 
            // Column_NeedAssign_Card
            // 
            this.Column_NeedAssign_Card.AppearanceHeader.Options.UseTextOptions = true;
            this.Column_NeedAssign_Card.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Column_NeedAssign_Card.Caption = "Переназначить";
            this.Column_NeedAssign_Card.FieldName = "NeedAssign";
            this.Column_NeedAssign_Card.MaxWidth = 150;
            this.Column_NeedAssign_Card.Name = "Column_NeedAssign_Card";
            this.Column_NeedAssign_Card.Visible = true;
            this.Column_NeedAssign_Card.VisibleIndex = 2;
            this.Column_NeedAssign_Card.Width = 102;
            // 
            // Column_NeedInherit_Card
            // 
            this.Column_NeedInherit_Card.AppearanceHeader.Options.UseTextOptions = true;
            this.Column_NeedInherit_Card.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Column_NeedInherit_Card.Caption = "Наследование";
            this.Column_NeedInherit_Card.FieldName = "NeedInherit";
            this.Column_NeedInherit_Card.MaxWidth = 150;
            this.Column_NeedInherit_Card.Name = "Column_NeedInherit_Card";
            this.Column_NeedInherit_Card.Visible = true;
            this.Column_NeedInherit_Card.VisibleIndex = 1;
            this.Column_NeedInherit_Card.Width = 95;
            // 
            // Control_Ribbon
            // 
            this.Control_Ribbon.AllowDrop = true;
            this.Control_Ribbon.AllowTrimPageText = false;
            this.Control_Ribbon.ApplicationCaption = "Утилита Архивариуса";
            this.Control_Ribbon.ExpandCollapseItem.Id = 0;
            this.Control_Ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.Control_Ribbon.ExpandCollapseItem,
            this.Item_CurrentState,
            this.Item_Theme,
            this.Item_CheckGroups,
            this.Item_SetRightsToFolders,
            this.Item_SetRightsToCards,
            this.Item_Find,
            this.Item_UploadFiles,
            this.Item_SetNoUnreadCards,
            this.Item_FindUnrelatedCards,
            this.Item_FindUnrelatedFolders,
            this.Item_FindMatchByIN,
            this.Item_SetWDCategory,
            this.Item_CheckAll,
            this.Item_UncheckAll,
            this.Item_ShowDetails,
            this.Item_HideDetails,
            this.Item_SaveMatrix,
            this.Item_ReloadMatrix,
            this.Item_CheckApplicability,
            this.Item_CreateHierarchyOfApplicability});
            this.Control_Ribbon.Location = new System.Drawing.Point(0, 0);
            this.Control_Ribbon.MaxItemId = 25;
            this.Control_Ribbon.Name = "Control_Ribbon";
            this.Control_Ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.Page_AssignRights,
            this.Page_Correction,
            this.Page_ArchiveAnalyzing,
            this.Page_UploadFilesToServer,
            this.Page_ControlOfApplicability});
            this.Control_Ribbon.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2010;
            this.Control_Ribbon.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            this.Control_Ribbon.ShowExpandCollapseButton = DevExpress.Utils.DefaultBoolean.True;
            this.Control_Ribbon.ShowPageHeadersMode = DevExpress.XtraBars.Ribbon.ShowPageHeadersMode.Show;
            this.Control_Ribbon.ShowToolbarCustomizeItem = false;
            this.Control_Ribbon.Size = new System.Drawing.Size(751, 144);
            this.Control_Ribbon.StatusBar = this.StatusBar_StateBar;
            this.Control_Ribbon.Toolbar.ShowCustomizeItem = false;
            this.Control_Ribbon.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden;
            this.Control_Ribbon.SelectedPageChanged += new System.EventHandler(this.Control_Ribbon_SelectedPageChanged);
            // 
            // Item_CurrentState
            // 
            this.Item_CurrentState.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Left;
            this.Item_CurrentState.Id = 1;
            this.Item_CurrentState.Name = "Item_CurrentState";
            this.Item_CurrentState.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // Item_Theme
            // 
            this.Item_Theme.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Left;
            this.Item_Theme.Caption = "Тема";
            this.Item_Theme.Id = 2;
            this.Item_Theme.Name = "Item_Theme";
            // 
            // Item_CheckGroups
            // 
            this.Item_CheckGroups.Caption = "Проверить группы";
            this.Item_CheckGroups.Glyph = global::SKB.ArchiveManager.Properties.Resources.CheckGoups;
            this.Item_CheckGroups.Id = 1;
            this.Item_CheckGroups.ItemShortcut = new DevExpress.XtraBars.BarShortcut(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
                | System.Windows.Forms.Keys.G));
            this.Item_CheckGroups.LargeGlyph = global::SKB.ArchiveManager.Properties.Resources.CheckGoups;
            this.Item_CheckGroups.Name = "Item_CheckGroups";
            this.Item_CheckGroups.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Item_CheckGroups_ItemClick);
            // 
            // Item_SetRightsToFolders
            // 
            this.Item_SetRightsToFolders.Caption = "Назначить на папки";
            this.Item_SetRightsToFolders.Glyph = global::SKB.ArchiveManager.Properties.Resources.SetRightsToFolders;
            this.Item_SetRightsToFolders.Id = 2;
            this.Item_SetRightsToFolders.ItemShortcut = new DevExpress.XtraBars.BarShortcut(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
                | System.Windows.Forms.Keys.F));
            this.Item_SetRightsToFolders.LargeGlyph = global::SKB.ArchiveManager.Properties.Resources.SetRightsToFolders;
            this.Item_SetRightsToFolders.Name = "Item_SetRightsToFolders";
            this.Item_SetRightsToFolders.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Item_SetRightsToFolders_ItemClick);
            // 
            // Item_SetRightsToCards
            // 
            this.Item_SetRightsToCards.Caption = "Назначить на карточки";
            this.Item_SetRightsToCards.Glyph = global::SKB.ArchiveManager.Properties.Resources.SetRightsToCards;
            this.Item_SetRightsToCards.Id = 3;
            this.Item_SetRightsToCards.ItemShortcut = new DevExpress.XtraBars.BarShortcut(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
                | System.Windows.Forms.Keys.C));
            this.Item_SetRightsToCards.LargeGlyph = global::SKB.ArchiveManager.Properties.Resources.SetRightsToCards;
            this.Item_SetRightsToCards.Name = "Item_SetRightsToCards";
            this.Item_SetRightsToCards.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Item_SetRightsToCards_ItemClick);
            // 
            // Item_Find
            // 
            this.Item_Find.Caption = "Поиск файлов";
            this.Item_Find.Glyph = global::SKB.ArchiveManager.Properties.Resources.Check;
            this.Item_Find.Id = 10;
            this.Item_Find.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F));
            this.Item_Find.LargeGlyph = global::SKB.ArchiveManager.Properties.Resources.Check;
            this.Item_Find.Name = "Item_Find";
            this.Item_Find.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Item_Find_ItemClick);
            // 
            // Item_UploadFiles
            // 
            this.Item_UploadFiles.Caption = "Выгрузить файлы";
            this.Item_UploadFiles.Glyph = global::SKB.ArchiveManager.Properties.Resources.UploadFiles;
            this.Item_UploadFiles.Id = 11;
            this.Item_UploadFiles.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.U));
            this.Item_UploadFiles.LargeGlyph = global::SKB.ArchiveManager.Properties.Resources.UploadFiles;
            this.Item_UploadFiles.Name = "Item_UploadFiles";
            this.Item_UploadFiles.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Item_UploadFiles_ItemClick);
            // 
            // Item_SetNoUnreadCards
            // 
            this.Item_SetNoUnreadCards.Caption = "Обновить дерево категорий";
            this.Item_SetNoUnreadCards.Description = "Убирает флаг \"Подсвечивать непрочитанные картчоки\".";
            this.Item_SetNoUnreadCards.Glyph = global::SKB.ArchiveManager.Properties.Resources.SetNoUnreadCards;
            this.Item_SetNoUnreadCards.Id = 12;
            this.Item_SetNoUnreadCards.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N));
            this.Item_SetNoUnreadCards.LargeGlyph = global::SKB.ArchiveManager.Properties.Resources.SetNoUnreadCards;
            this.Item_SetNoUnreadCards.Name = "Item_SetNoUnreadCards";
            this.Item_SetNoUnreadCards.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Item_SetNoUnreadCards_ItemClick);
            // 
            // Item_FindUnrelatedCards
            // 
            this.Item_FindUnrelatedCards.Caption = "Поиск карточек без папки";
            this.Item_FindUnrelatedCards.Glyph = global::SKB.ArchiveManager.Properties.Resources.FindDoc;
            this.Item_FindUnrelatedCards.Id = 13;
            this.Item_FindUnrelatedCards.LargeGlyph = global::SKB.ArchiveManager.Properties.Resources.FindDoc;
            this.Item_FindUnrelatedCards.Name = "Item_FindUnrelatedCards";
            this.Item_FindUnrelatedCards.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Item_FindUnrelatedCards_ItemClick);
            // 
            // Item_FindUnrelatedFolders
            // 
            this.Item_FindUnrelatedFolders.Caption = "Поиск папок без карточки";
            this.Item_FindUnrelatedFolders.Glyph = global::SKB.ArchiveManager.Properties.Resources.FindFolder;
            this.Item_FindUnrelatedFolders.Id = 14;
            this.Item_FindUnrelatedFolders.LargeGlyph = global::SKB.ArchiveManager.Properties.Resources.FindFolder;
            this.Item_FindUnrelatedFolders.Name = "Item_FindUnrelatedFolders";
            this.Item_FindUnrelatedFolders.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Item_FindUnrelatedFolders_ItemClick);
            // 
            // Item_FindMatchByIN
            // 
            this.Item_FindMatchByIN.Caption = "Найти соответствие по ИН";
            this.Item_FindMatchByIN.Glyph = global::SKB.ArchiveManager.Properties.Resources.FindMatch;
            this.Item_FindMatchByIN.Id = 15;
            this.Item_FindMatchByIN.LargeGlyph = global::SKB.ArchiveManager.Properties.Resources.FindMatch;
            this.Item_FindMatchByIN.Name = "Item_FindMatchByIN";
            this.Item_FindMatchByIN.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Item_FindMatchByIN_ItemClick);
            // 
            // Item_SetWDCategory
            // 
            this.Item_SetWDCategory.Caption = "Назначить категорию БЧ";
            this.Item_SetWDCategory.Glyph = global::SKB.ArchiveManager.Properties.Resources.SetCategory;
            this.Item_SetWDCategory.Id = 16;
            this.Item_SetWDCategory.LargeGlyph = global::SKB.ArchiveManager.Properties.Resources.SetCategory;
            this.Item_SetWDCategory.Name = "Item_SetWDCategory";
            this.Item_SetWDCategory.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Item_SetWDCategory_ItemClick);
            // 
            // Item_CheckAll
            // 
            this.Item_CheckAll.Caption = "Выбрать все";
            this.Item_CheckAll.Glyph = global::SKB.ArchiveManager.Properties.Resources.CheckAll;
            this.Item_CheckAll.Id = 17;
            this.Item_CheckAll.LargeGlyph = global::SKB.ArchiveManager.Properties.Resources.CheckAll;
            this.Item_CheckAll.Name = "Item_CheckAll";
            this.Item_CheckAll.Tag = true;
            this.Item_CheckAll.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Item_Check_ItemClick);
            // 
            // Item_UncheckAll
            // 
            this.Item_UncheckAll.Caption = "Очистить все";
            this.Item_UncheckAll.Glyph = global::SKB.ArchiveManager.Properties.Resources.UncheckAll;
            this.Item_UncheckAll.Id = 18;
            this.Item_UncheckAll.LargeGlyph = global::SKB.ArchiveManager.Properties.Resources.UncheckAll;
            this.Item_UncheckAll.Name = "Item_UncheckAll";
            this.Item_UncheckAll.Tag = false;
            this.Item_UncheckAll.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Item_Check_ItemClick);
            // 
            // Item_ShowDetails
            // 
            this.Item_ShowDetails.Caption = "Развернуть все";
            this.Item_ShowDetails.Glyph = global::SKB.ArchiveManager.Properties.Resources.ExpandAll;
            this.Item_ShowDetails.Id = 19;
            this.Item_ShowDetails.LargeGlyph = global::SKB.ArchiveManager.Properties.Resources.ExpandAll;
            this.Item_ShowDetails.Name = "Item_ShowDetails";
            this.Item_ShowDetails.Tag = true;
            this.Item_ShowDetails.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Item_Details_ItemClick);
            // 
            // Item_HideDetails
            // 
            this.Item_HideDetails.Caption = "Свернуть все";
            this.Item_HideDetails.Glyph = global::SKB.ArchiveManager.Properties.Resources.UnexpandAll;
            this.Item_HideDetails.Id = 20;
            this.Item_HideDetails.LargeGlyph = global::SKB.ArchiveManager.Properties.Resources.UnexpandAll;
            this.Item_HideDetails.Name = "Item_HideDetails";
            this.Item_HideDetails.Tag = false;
            this.Item_HideDetails.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Item_Details_ItemClick);
            // 
            // Item_SaveMatrix
            // 
            this.Item_SaveMatrix.Caption = "Сохранить матрицу";
            this.Item_SaveMatrix.Glyph = global::SKB.ArchiveManager.Properties.Resources.Save;
            this.Item_SaveMatrix.Id = 21;
            this.Item_SaveMatrix.ItemShortcut = new DevExpress.XtraBars.BarShortcut(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
                | System.Windows.Forms.Keys.S));
            this.Item_SaveMatrix.LargeGlyph = global::SKB.ArchiveManager.Properties.Resources.Save;
            this.Item_SaveMatrix.Name = "Item_SaveMatrix";
            this.Item_SaveMatrix.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Item_SaveMatrix_ItemClick);
            // 
            // Item_ReloadMatrix
            // 
            this.Item_ReloadMatrix.Caption = "Перезагрузка матрицы";
            this.Item_ReloadMatrix.Glyph = global::SKB.ArchiveManager.Properties.Resources.RefreshMatrix;
            this.Item_ReloadMatrix.Id = 22;
            this.Item_ReloadMatrix.LargeGlyph = global::SKB.ArchiveManager.Properties.Resources.RefreshMatrix;
            this.Item_ReloadMatrix.Name = "Item_ReloadMatrix";
            this.Item_ReloadMatrix.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Item_ReloadMatrix_ItemClick);
            // 
            // Item_CheckApplicability
            // 
            this.Item_CheckApplicability.Caption = "Проверить применяемость";
            this.Item_CheckApplicability.Glyph = global::SKB.ArchiveManager.Properties.Resources.Analize;
            this.Item_CheckApplicability.GlyphDisabled = global::SKB.ArchiveManager.Properties.Resources.Analize;
            this.Item_CheckApplicability.Id = 23;
            this.Item_CheckApplicability.LargeGlyph = global::SKB.ArchiveManager.Properties.Resources.Analize;
            this.Item_CheckApplicability.Name = "Item_CheckApplicability";
            // 
            // Item_CreateHierarchyOfApplicability
            // 
            this.Item_CreateHierarchyOfApplicability.Caption = "Создать дерево документации";
            this.Item_CreateHierarchyOfApplicability.Glyph = global::SKB.ArchiveManager.Properties.Resources.Hierarchy;
            this.Item_CreateHierarchyOfApplicability.GlyphDisabled = global::SKB.ArchiveManager.Properties.Resources.Hierarchy;
            this.Item_CreateHierarchyOfApplicability.Id = 24;
            this.Item_CreateHierarchyOfApplicability.LargeGlyph = global::SKB.ArchiveManager.Properties.Resources.Hierarchy;
            this.Item_CreateHierarchyOfApplicability.Name = "Item_CreateHierarchyOfApplicability";
            // 
            // Page_AssignRights
            // 
            this.Page_AssignRights.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.PageGroup_Expand,
            this.PageGroup_EditMatrix,
            this.PageGroup_Matrix,
            this.PageGroup_AssignRights});
            this.Page_AssignRights.Name = "Page_AssignRights";
            this.Page_AssignRights.Tag = 0;
            this.Page_AssignRights.Text = "Назначение прав";
            // 
            // PageGroup_Expand
            // 
            this.PageGroup_Expand.ItemLinks.Add(this.Item_ShowDetails);
            this.PageGroup_Expand.ItemLinks.Add(this.Item_HideDetails);
            this.PageGroup_Expand.Name = "PageGroup_Expand";
            this.PageGroup_Expand.ShowCaptionButton = false;
            // 
            // PageGroup_EditMatrix
            // 
            this.PageGroup_EditMatrix.ItemLinks.Add(this.Item_CheckAll);
            this.PageGroup_EditMatrix.ItemLinks.Add(this.Item_UncheckAll);
            this.PageGroup_EditMatrix.Name = "PageGroup_EditMatrix";
            this.PageGroup_EditMatrix.ShowCaptionButton = false;
            // 
            // PageGroup_Matrix
            // 
            this.PageGroup_Matrix.ItemLinks.Add(this.Item_ReloadMatrix);
            this.PageGroup_Matrix.ItemLinks.Add(this.Item_SaveMatrix);
            this.PageGroup_Matrix.Name = "PageGroup_Matrix";
            this.PageGroup_Matrix.ShowCaptionButton = false;
            // 
            // PageGroup_AssignRights
            // 
            this.PageGroup_AssignRights.ItemLinks.Add(this.Item_CheckGroups);
            this.PageGroup_AssignRights.ItemLinks.Add(this.Item_SetRightsToCards, true);
            this.PageGroup_AssignRights.ItemLinks.Add(this.Item_SetRightsToFolders);
            this.PageGroup_AssignRights.Name = "PageGroup_AssignRights";
            this.PageGroup_AssignRights.ShowCaptionButton = false;
            // 
            // Page_Correction
            // 
            this.Page_Correction.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.PageGroup_Categories});
            this.Page_Correction.Name = "Page_Correction";
            this.Page_Correction.Tag = 1;
            this.Page_Correction.Text = "Корректировки";
            // 
            // PageGroup_Categories
            // 
            this.PageGroup_Categories.ItemLinks.Add(this.Item_SetNoUnreadCards);
            this.PageGroup_Categories.Name = "PageGroup_Categories";
            this.PageGroup_Categories.ShowCaptionButton = false;
            // 
            // Page_ArchiveAnalyzing
            // 
            this.Page_ArchiveAnalyzing.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.PageGroup_ArchiveSearch,
            this.PageGroup_ArchiveFix});
            this.Page_ArchiveAnalyzing.Name = "Page_ArchiveAnalyzing";
            this.Page_ArchiveAnalyzing.Tag = 2;
            this.Page_ArchiveAnalyzing.Text = "Анализ архива";
            // 
            // PageGroup_ArchiveSearch
            // 
            this.PageGroup_ArchiveSearch.AllowTextClipping = false;
            this.PageGroup_ArchiveSearch.ItemLinks.Add(this.Item_FindUnrelatedCards);
            this.PageGroup_ArchiveSearch.ItemLinks.Add(this.Item_FindUnrelatedFolders);
            this.PageGroup_ArchiveSearch.ItemLinks.Add(this.Item_FindMatchByIN);
            this.PageGroup_ArchiveSearch.Name = "PageGroup_ArchiveSearch";
            this.PageGroup_ArchiveSearch.ShowCaptionButton = false;
            this.PageGroup_ArchiveSearch.Text = "Поиск по архиву";
            // 
            // PageGroup_ArchiveFix
            // 
            this.PageGroup_ArchiveFix.ItemLinks.Add(this.Item_SetWDCategory);
            this.PageGroup_ArchiveFix.Name = "PageGroup_ArchiveFix";
            this.PageGroup_ArchiveFix.ShowCaptionButton = false;
            this.PageGroup_ArchiveFix.Text = "Исправления";
            // 
            // Page_UploadFilesToServer
            // 
            this.Page_UploadFilesToServer.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.PageGroup_UploadFilesToServer});
            this.Page_UploadFilesToServer.Name = "Page_UploadFilesToServer";
            this.Page_UploadFilesToServer.Tag = 3;
            this.Page_UploadFilesToServer.Text = "Выгрузка файлов на сервер";
            // 
            // PageGroup_UploadFilesToServer
            // 
            this.PageGroup_UploadFilesToServer.ItemLinks.Add(this.Item_Find);
            this.PageGroup_UploadFilesToServer.ItemLinks.Add(this.Item_UploadFiles);
            this.PageGroup_UploadFilesToServer.Name = "PageGroup_UploadFilesToServer";
            this.PageGroup_UploadFilesToServer.ShowCaptionButton = false;
            // 
            // Page_ControlOfApplicability
            // 
            this.Page_ControlOfApplicability.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.PageGroup_ControlOfApplicability});
            this.Page_ControlOfApplicability.Name = "Page_ControlOfApplicability";
            this.Page_ControlOfApplicability.Tag = "4";
            this.Page_ControlOfApplicability.Text = "Контроль применяемости";
            // 
            // PageGroup_ControlOfApplicability
            // 
            this.PageGroup_ControlOfApplicability.ItemLinks.Add(this.Item_CheckApplicability);
            this.PageGroup_ControlOfApplicability.ItemLinks.Add(this.Item_CreateHierarchyOfApplicability);
            this.PageGroup_ControlOfApplicability.Name = "PageGroup_ControlOfApplicability";
            // 
            // StatusBar_StateBar
            // 
            this.StatusBar_StateBar.AutoHeight = true;
            this.StatusBar_StateBar.ItemLinks.Add(this.Item_Theme);
            this.StatusBar_StateBar.ItemLinks.Add(this.Item_CurrentState);
            this.StatusBar_StateBar.Location = new System.Drawing.Point(0, 570);
            this.StatusBar_StateBar.Name = "StatusBar_StateBar";
            this.StatusBar_StateBar.Ribbon = this.Control_Ribbon;
            this.StatusBar_StateBar.Size = new System.Drawing.Size(751, 31);
            // 
            // View_FolderGroupRights
            // 
            this.View_FolderGroupRights.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.Column_Name_FolderGroup,
            this.Column_Rights_FolderGroup});
            this.View_FolderGroupRights.GridControl = this.Control_FolderRights;
            this.View_FolderGroupRights.Name = "View_FolderGroupRights";
            this.View_FolderGroupRights.OptionsView.ShowGroupPanel = false;
            this.View_FolderGroupRights.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.View_RightGroups_RowClick);
            // 
            // Column_Name_FolderGroup
            // 
            this.Column_Name_FolderGroup.AppearanceHeader.Options.UseTextOptions = true;
            this.Column_Name_FolderGroup.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Column_Name_FolderGroup.Caption = "Группа безопасности";
            this.Column_Name_FolderGroup.FieldName = "Name";
            this.Column_Name_FolderGroup.Name = "Column_Name_FolderGroup";
            this.Column_Name_FolderGroup.Visible = true;
            this.Column_Name_FolderGroup.VisibleIndex = 0;
            this.Column_Name_FolderGroup.Width = 322;
            // 
            // Column_Rights_FolderGroup
            // 
            this.Column_Rights_FolderGroup.AppearanceCell.Options.UseTextOptions = true;
            this.Column_Rights_FolderGroup.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Column_Rights_FolderGroup.AppearanceHeader.Options.UseTextOptions = true;
            this.Column_Rights_FolderGroup.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Column_Rights_FolderGroup.Caption = "Права на папку";
            this.Column_Rights_FolderGroup.ColumnEdit = this.Repository_FolderRigths;
            this.Column_Rights_FolderGroup.FieldName = "Rights";
            this.Column_Rights_FolderGroup.Name = "Column_Rights_FolderGroup";
            this.Column_Rights_FolderGroup.Visible = true;
            this.Column_Rights_FolderGroup.VisibleIndex = 1;
            this.Column_Rights_FolderGroup.Width = 361;
            // 
            // Repository_FolderRigths
            // 
            this.Repository_FolderRigths.AutoHeight = false;
            this.Repository_FolderRigths.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.Repository_FolderRigths.Items.AddRange(new DevExpress.XtraEditors.Controls.CheckedListBoxItem[] {
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("Ч", "Ч"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("Ч+", "Ч+"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("ИС", "ИС"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("У", "У"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("К", "К"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("ПП", "ПП")});
            this.Repository_FolderRigths.Name = "Repository_FolderRigths";
            this.Repository_FolderRigths.SelectAllItemVisible = false;
            this.Repository_FolderRigths.SeparatorChar = ';';
            this.Repository_FolderRigths.GetItemEnabled += new DevExpress.XtraEditors.Controls.GetCheckedComboBoxItemEnabledEventHandler(this.Repository_Rights_GetItemEnabled);
            this.Repository_FolderRigths.CloseUp += new DevExpress.XtraEditors.Controls.CloseUpEventHandler(this.Repository_Rights_CloseUp);
            this.Repository_FolderRigths.Popup += new System.EventHandler(this.Repository_Rights_Popup);
            // 
            // Control_FolderRights
            // 
            this.Control_FolderRights.DataSource = this.BindingSource_TargetObject;
            gridLevelNode2.LevelTemplate = this.View_FolderGroupRights;
            gridLevelNode2.RelationName = "Groups";
            this.Control_FolderRights.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode2});
            this.Control_FolderRights.Location = new System.Drawing.Point(25, 69);
            this.Control_FolderRights.MainView = this.View_FolderRights;
            this.Control_FolderRights.MenuManager = this.Control_Ribbon;
            this.Control_FolderRights.Name = "Control_FolderRights";
            this.Control_FolderRights.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.Repository_FolderRigths});
            this.Control_FolderRights.Size = new System.Drawing.Size(701, 332);
            this.Control_FolderRights.TabIndex = 24;
            this.Control_FolderRights.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.View_FolderRights,
            this.View_FolderGroupRights});
            // 
            // View_FolderRights
            // 
            this.View_FolderRights.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.Column_Name_Folder,
            this.Column_NeedInherit_Folder,
            this.Column_NeedAssign_Folder});
            this.View_FolderRights.GridControl = this.Control_FolderRights;
            this.View_FolderRights.Name = "View_FolderRights";
            this.View_FolderRights.OptionsDetail.ShowDetailTabs = false;
            this.View_FolderRights.OptionsView.ShowGroupPanel = false;
            // 
            // Column_Name_Folder
            // 
            this.Column_Name_Folder.AppearanceHeader.Options.UseTextOptions = true;
            this.Column_Name_Folder.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Column_Name_Folder.Caption = "Папки DV";
            this.Column_Name_Folder.FieldName = "Name";
            this.Column_Name_Folder.Name = "Column_Name_Folder";
            this.Column_Name_Folder.OptionsColumn.ReadOnly = true;
            this.Column_Name_Folder.Visible = true;
            this.Column_Name_Folder.VisibleIndex = 0;
            this.Column_Name_Folder.Width = 483;
            // 
            // Column_NeedInherit_Folder
            // 
            this.Column_NeedInherit_Folder.AppearanceHeader.Options.UseTextOptions = true;
            this.Column_NeedInherit_Folder.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Column_NeedInherit_Folder.Caption = "Наследование";
            this.Column_NeedInherit_Folder.FieldName = "NeedInherit";
            this.Column_NeedInherit_Folder.MaxWidth = 150;
            this.Column_NeedInherit_Folder.Name = "Column_NeedInherit_Folder";
            this.Column_NeedInherit_Folder.Visible = true;
            this.Column_NeedInherit_Folder.VisibleIndex = 1;
            this.Column_NeedInherit_Folder.Width = 96;
            // 
            // Column_NeedAssign_Folder
            // 
            this.Column_NeedAssign_Folder.AppearanceHeader.Options.UseTextOptions = true;
            this.Column_NeedAssign_Folder.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Column_NeedAssign_Folder.Caption = "Переназначить";
            this.Column_NeedAssign_Folder.FieldName = "NeedAssign";
            this.Column_NeedAssign_Folder.MaxWidth = 150;
            this.Column_NeedAssign_Folder.Name = "Column_NeedAssign_Folder";
            this.Column_NeedAssign_Folder.Visible = true;
            this.Column_NeedAssign_Folder.VisibleIndex = 2;
            this.Column_NeedAssign_Folder.Width = 104;
            // 
            // Edit_IfPattern
            // 
            this.Edit_IfPattern.Location = new System.Drawing.Point(25, 207);
            this.Edit_IfPattern.Name = "Edit_IfPattern";
            this.Edit_IfPattern.Size = new System.Drawing.Size(701, 20);
            this.Edit_IfPattern.StyleController = this.Control_Layout;
            this.Edit_IfPattern.TabIndex = 9;
            // 
            // Control_Layout
            // 
            this.Control_Layout.AllowCustomizationMenu = false;
            this.Control_Layout.Controls.Add(this.layoutControl1);
            this.Control_Layout.Controls.Add(this.Control_FolderRights);
            this.Control_Layout.Controls.Add(this.Control_CardRights);
            this.Control_Layout.Controls.Add(this.Control_Matches);
            this.Control_Layout.Controls.Add(this.Button_Replace);
            this.Control_Layout.Controls.Add(this.Button_SavePath);
            this.Control_Layout.Controls.Add(this.Button_CheckPath);
            this.Control_Layout.Controls.Add(this.Edit_TotalFileSize);
            this.Control_Layout.Controls.Add(this.Button_UnselectAll);
            this.Control_Layout.Controls.Add(this.Button_SelectAll);
            this.Control_Layout.Controls.Add(this.Control_FoundFiles);
            this.Control_Layout.Controls.Add(this.Edit_DVFolder);
            this.Control_Layout.Controls.Add(this.Edit_FileSize);
            this.Control_Layout.Controls.Add(this.Edit_Action);
            this.Control_Layout.Controls.Add(this.Control_Objects);
            this.Control_Layout.Controls.Add(this.Edit_IfPattern);
            this.Control_Layout.Controls.Add(this.Edit_FindPattern);
            this.Control_Layout.Controls.Add(this.Edit_ReplacePattern);
            this.Control_Layout.Controls.Add(this.Edit_NewPath);
            this.Control_Layout.Controls.Add(this.Edit_OldPath);
            this.Control_Layout.Controls.Add(this.Edit_CardId);
            this.Control_Layout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Control_Layout.Location = new System.Drawing.Point(0, 144);
            this.Control_Layout.Name = "Control_Layout";
            this.Control_Layout.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(814, 143, 609, 550);
            this.Control_Layout.OptionsView.UseDefaultDragAndDropRendering = false;
            this.Control_Layout.Root = this.lcg;
            this.Control_Layout.Size = new System.Drawing.Size(751, 426);
            this.Control_Layout.TabIndex = 3;
            this.Control_Layout.Text = "layoutControl1";
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.Control_Errors);
            this.layoutControl1.Location = new System.Drawing.Point(13, 35);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.lcg_Bugs;
            this.layoutControl1.Size = new System.Drawing.Size(725, 378);
            this.layoutControl1.TabIndex = 27;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // Control_Errors
            // 
            this.Control_Errors.Location = new System.Drawing.Point(12, 31);
            this.Control_Errors.MainView = this.ViewErrors;
            this.Control_Errors.MenuManager = this.Control_Ribbon;
            this.Control_Errors.Name = "Control_Errors";
            this.Control_Errors.Size = new System.Drawing.Size(701, 335);
            this.Control_Errors.TabIndex = 4;
            this.Control_Errors.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.ViewErrors});
            // 
            // ViewErrors
            // 
            this.ViewErrors.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.Column_Device,
            this.Column_Document_Id,
            this.Column_Document_Description,
            this.Column_Applicability,
            this.Column_Error_Text});
            this.ViewErrors.GridControl = this.Control_Errors;
            this.ViewErrors.Name = "ViewErrors";
            this.ViewErrors.OptionsView.ShowGroupPanel = false;
            this.ViewErrors.DoubleClick += new System.EventHandler(this.ViewErrors_DoubleClick);
            // 
            // Column_Device
            // 
            this.Column_Device.Caption = "Прибор";
            this.Column_Device.FieldName = "Device";
            this.Column_Device.Name = "Column_Device";
            this.Column_Device.OptionsColumn.ReadOnly = true;
            this.Column_Device.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.Column_Device.Visible = true;
            this.Column_Device.VisibleIndex = 0;
            // 
            // Column_Document_Id
            // 
            this.Column_Document_Id.Caption = "ID документа";
            this.Column_Document_Id.FieldName = "DocumentId";
            this.Column_Document_Id.Name = "Column_Document_Id";
            this.Column_Document_Id.OptionsColumn.ReadOnly = true;
            this.Column_Document_Id.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.Column_Document_Id.Visible = true;
            this.Column_Document_Id.VisibleIndex = 1;
            // 
            // Column_Document_Description
            // 
            this.Column_Document_Description.Caption = "Ссылка на документ";
            this.Column_Document_Description.FieldName = "DocumentName";
            this.Column_Document_Description.Name = "Column_Document_Description";
            this.Column_Document_Description.OptionsColumn.ReadOnly = true;
            this.Column_Document_Description.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.Column_Document_Description.Visible = true;
            this.Column_Document_Description.VisibleIndex = 2;
            // 
            // Column_Applicability
            // 
            this.Column_Applicability.Caption = "Применяемость";
            this.Column_Applicability.FieldName = "Applicability";
            this.Column_Applicability.Name = "Column_Applicability";
            this.Column_Applicability.OptionsColumn.ReadOnly = true;
            this.Column_Applicability.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.Column_Applicability.Visible = true;
            this.Column_Applicability.VisibleIndex = 3;
            // 
            // Column_Error_Text
            // 
            this.Column_Error_Text.Caption = "Текст ошибки";
            this.Column_Error_Text.FieldName = "TextError";
            this.Column_Error_Text.Name = "Column_Error_Text";
            this.Column_Error_Text.OptionsColumn.ReadOnly = true;
            this.Column_Error_Text.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.Column_Error_Text.Visible = true;
            this.Column_Error_Text.VisibleIndex = 4;
            // 
            // lcg_Bugs
            // 
            this.lcg_Bugs.CustomizationFormText = "Найденные ошибки:";
            this.lcg_Bugs.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.lcg_Bugs.ExpandButtonLocation = DevExpress.Utils.GroupElementLocation.AfterText;
            this.lcg_Bugs.ExpandButtonVisible = true;
            this.lcg_Bugs.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem5});
            this.lcg_Bugs.Location = new System.Drawing.Point(0, 0);
            this.lcg_Bugs.Name = "lcg_Bugs";
            this.lcg_Bugs.Size = new System.Drawing.Size(725, 378);
            this.lcg_Bugs.Text = "Найденные ошибки:";
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.Control_Errors;
            this.layoutControlItem5.CustomizationFormText = "layoutControlItem5";
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(705, 339);
            this.layoutControlItem5.Text = "layoutControlItem5";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextToControlDistance = 0;
            this.layoutControlItem5.TextVisible = false;
            // 
            // Control_Matches
            // 
            this.Control_Matches.DataSource = this.BindingSource_Unrelated;
            this.Control_Matches.Location = new System.Drawing.Point(25, 299);
            this.Control_Matches.MainView = this.View_Matches;
            this.Control_Matches.MenuManager = this.Control_Ribbon;
            this.Control_Matches.Name = "Control_Matches";
            this.Control_Matches.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.Repository_Matches_Guid});
            this.Control_Matches.Size = new System.Drawing.Size(701, 102);
            this.Control_Matches.TabIndex = 22;
            this.Control_Matches.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.View_Matches});
            // 
            // BindingSource_Unrelated
            // 
            this.BindingSource_Unrelated.DataSource = typeof(SKB.ArchiveManager.Unrelated);
            // 
            // View_Matches
            // 
            this.View_Matches.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.Column_Selected_Match,
            this.Column_DocType_Match,
            this.Column_DocName_Match,
            this.Сolumn_Category_Match,
            this.Column_Folder_Match,
            this.Column_CardId_Match});
            this.View_Matches.GridControl = this.Control_Matches;
            this.View_Matches.Name = "View_Matches";
            this.View_Matches.OptionsView.ShowGroupPanel = false;
            this.View_Matches.DoubleClick += new System.EventHandler(this.View_Unrelated_DoubleClick);
            // 
            // Column_Selected_Match
            // 
            this.Column_Selected_Match.AppearanceHeader.Options.UseTextOptions = true;
            this.Column_Selected_Match.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Column_Selected_Match.Caption = "...";
            this.Column_Selected_Match.FieldName = "Selected";
            this.Column_Selected_Match.MaxWidth = 25;
            this.Column_Selected_Match.MinWidth = 25;
            this.Column_Selected_Match.Name = "Column_Selected_Match";
            this.Column_Selected_Match.Visible = true;
            this.Column_Selected_Match.VisibleIndex = 0;
            this.Column_Selected_Match.Width = 25;
            // 
            // Column_DocType_Match
            // 
            this.Column_DocType_Match.AppearanceHeader.Options.UseTextOptions = true;
            this.Column_DocType_Match.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Column_DocType_Match.Caption = "Тип документа";
            this.Column_DocType_Match.FieldName = "DocType";
            this.Column_DocType_Match.Name = "Column_DocType_Match";
            this.Column_DocType_Match.OptionsColumn.ReadOnly = true;
            this.Column_DocType_Match.Visible = true;
            this.Column_DocType_Match.VisibleIndex = 1;
            this.Column_DocType_Match.Width = 137;
            // 
            // Column_DocName_Match
            // 
            this.Column_DocName_Match.AppearanceHeader.Options.UseTextOptions = true;
            this.Column_DocName_Match.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Column_DocName_Match.Caption = "Название документа";
            this.Column_DocName_Match.FieldName = "DocName";
            this.Column_DocName_Match.Name = "Column_DocName_Match";
            this.Column_DocName_Match.OptionsColumn.ReadOnly = true;
            this.Column_DocName_Match.Visible = true;
            this.Column_DocName_Match.VisibleIndex = 2;
            this.Column_DocName_Match.Width = 137;
            // 
            // Сolumn_Category_Match
            // 
            this.Сolumn_Category_Match.AppearanceHeader.Options.UseTextOptions = true;
            this.Сolumn_Category_Match.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Сolumn_Category_Match.Caption = "Категория";
            this.Сolumn_Category_Match.FieldName = "Category";
            this.Сolumn_Category_Match.Name = "Сolumn_Category_Match";
            this.Сolumn_Category_Match.Visible = true;
            this.Сolumn_Category_Match.VisibleIndex = 3;
            this.Сolumn_Category_Match.Width = 92;
            // 
            // Column_Folder_Match
            // 
            this.Column_Folder_Match.AppearanceHeader.Options.UseTextOptions = true;
            this.Column_Folder_Match.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Column_Folder_Match.Caption = "Папка";
            this.Column_Folder_Match.FieldName = "Folder";
            this.Column_Folder_Match.Name = "Column_Folder_Match";
            this.Column_Folder_Match.OptionsColumn.ReadOnly = true;
            this.Column_Folder_Match.Visible = true;
            this.Column_Folder_Match.VisibleIndex = 4;
            this.Column_Folder_Match.Width = 130;
            // 
            // Column_CardId_Match
            // 
            this.Column_CardId_Match.AppearanceHeader.Options.UseTextOptions = true;
            this.Column_CardId_Match.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Column_CardId_Match.Caption = "ИД карточки";
            this.Column_CardId_Match.ColumnEdit = this.Repository_Matches_Guid;
            this.Column_CardId_Match.FieldName = "CardId";
            this.Column_CardId_Match.Name = "Column_CardId_Match";
            this.Column_CardId_Match.OptionsColumn.ReadOnly = true;
            this.Column_CardId_Match.Visible = true;
            this.Column_CardId_Match.VisibleIndex = 5;
            this.Column_CardId_Match.Width = 144;
            // 
            // Repository_Matches_Guid
            // 
            this.Repository_Matches_Guid.AutoHeight = false;
            this.Repository_Matches_Guid.Mask.EditMask = "[0-9A-F]{8}(-[0-9A-F]{4}){3}-[0-9A-F]{12}";
            this.Repository_Matches_Guid.Mask.IgnoreMaskBlank = false;
            this.Repository_Matches_Guid.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.Repository_Matches_Guid.Mask.UseMaskAsDisplayFormat = true;
            this.Repository_Matches_Guid.Name = "Repository_Matches_Guid";
            // 
            // Button_Replace
            // 
            this.Button_Replace.Location = new System.Drawing.Point(25, 321);
            this.Button_Replace.Name = "Button_Replace";
            this.Button_Replace.Size = new System.Drawing.Size(701, 22);
            this.Button_Replace.StyleController = this.Control_Layout;
            this.Button_Replace.TabIndex = 21;
            this.Button_Replace.Text = "Поиск и замена";
            this.Button_Replace.Click += new System.EventHandler(this.Button_Replace_Click);
            // 
            // Button_SavePath
            // 
            this.Button_SavePath.Location = new System.Drawing.Point(580, 112);
            this.Button_SavePath.Name = "Button_SavePath";
            this.Button_SavePath.Size = new System.Drawing.Size(146, 22);
            this.Button_SavePath.StyleController = this.Control_Layout;
            this.Button_SavePath.TabIndex = 20;
            this.Button_SavePath.Text = "Сохранить путь";
            this.Button_SavePath.Click += new System.EventHandler(this.Button_SavePath_Click);
            // 
            // Button_CheckPath
            // 
            this.Button_CheckPath.Location = new System.Drawing.Point(580, 66);
            this.Button_CheckPath.Name = "Button_CheckPath";
            this.Button_CheckPath.Size = new System.Drawing.Size(146, 22);
            this.Button_CheckPath.StyleController = this.Control_Layout;
            this.Button_CheckPath.TabIndex = 19;
            this.Button_CheckPath.Text = "Проверить путь";
            this.Button_CheckPath.Click += new System.EventHandler(this.Button_CheckPath_Click);
            // 
            // Edit_TotalFileSize
            // 
            this.Edit_TotalFileSize.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.Edit_TotalFileSize.Location = new System.Drawing.Point(643, 391);
            this.Edit_TotalFileSize.MenuManager = this.Control_Ribbon;
            this.Edit_TotalFileSize.Name = "Edit_TotalFileSize";
            this.Edit_TotalFileSize.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, false, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.Edit_TotalFileSize.Properties.Mask.EditMask = "### ##0.###";
            this.Edit_TotalFileSize.Properties.Mask.ShowPlaceHolders = false;
            this.Edit_TotalFileSize.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.Edit_TotalFileSize.Properties.ReadOnly = true;
            this.Edit_TotalFileSize.Size = new System.Drawing.Size(95, 20);
            this.Edit_TotalFileSize.StyleController = this.Control_Layout;
            this.Edit_TotalFileSize.TabIndex = 18;
            // 
            // Button_UnselectAll
            // 
            this.Button_UnselectAll.Location = new System.Drawing.Point(151, 391);
            this.Button_UnselectAll.Name = "Button_UnselectAll";
            this.Button_UnselectAll.Size = new System.Drawing.Size(124, 22);
            this.Button_UnselectAll.StyleController = this.Control_Layout;
            this.Button_UnselectAll.TabIndex = 17;
            this.Button_UnselectAll.Tag = "False";
            this.Button_UnselectAll.Text = "Очистить все";
            this.Button_UnselectAll.Click += new System.EventHandler(this.Button_Selecting_Click);
            // 
            // Button_SelectAll
            // 
            this.Button_SelectAll.Location = new System.Drawing.Point(13, 391);
            this.Button_SelectAll.Name = "Button_SelectAll";
            this.Button_SelectAll.Size = new System.Drawing.Size(124, 22);
            this.Button_SelectAll.StyleController = this.Control_Layout;
            this.Button_SelectAll.TabIndex = 16;
            this.Button_SelectAll.Tag = "True";
            this.Button_SelectAll.Text = "Выбрать все";
            this.Button_SelectAll.Click += new System.EventHandler(this.Button_Selecting_Click);
            // 
            // Control_FoundFiles
            // 
            this.Control_FoundFiles.DataSource = this.BindingSource_FoundFile;
            this.Control_FoundFiles.Location = new System.Drawing.Point(13, 85);
            this.Control_FoundFiles.MainView = this.View_FoundFiles;
            this.Control_FoundFiles.MenuManager = this.Control_Ribbon;
            this.Control_FoundFiles.Name = "Control_FoundFiles";
            this.Control_FoundFiles.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.Repository_FileSize,
            this.Repository_DateEdit});
            this.Control_FoundFiles.Size = new System.Drawing.Size(725, 292);
            this.Control_FoundFiles.TabIndex = 15;
            this.Control_FoundFiles.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.View_FoundFiles});
            // 
            // BindingSource_FoundFile
            // 
            this.BindingSource_FoundFile.DataSource = typeof(SKB.ArchiveManager.FoundFile);
            // 
            // View_FoundFiles
            // 
            this.View_FoundFiles.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.Column_Selected_File,
            this.Column_Name_File,
            this.Column_Size_File,
            this.Column_Category_File,
            this.Column_Registrar_File,
            this.Column_CreationDate_File});
            this.View_FoundFiles.GridControl = this.Control_FoundFiles;
            this.View_FoundFiles.Name = "View_FoundFiles";
            this.View_FoundFiles.OptionsBehavior.AutoSelectAllInEditor = false;
            this.View_FoundFiles.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.View_FoundFiles.OptionsView.ShowGroupPanel = false;
            this.View_FoundFiles.DoubleClick += new System.EventHandler(this.View_FoundFiles_DoubleClick);
            // 
            // Column_Selected_File
            // 
            this.Column_Selected_File.AppearanceHeader.Options.UseTextOptions = true;
            this.Column_Selected_File.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Column_Selected_File.Caption = "...";
            this.Column_Selected_File.FieldName = "Selected";
            this.Column_Selected_File.MaxWidth = 25;
            this.Column_Selected_File.MinWidth = 25;
            this.Column_Selected_File.Name = "Column_Selected_File";
            this.Column_Selected_File.Visible = true;
            this.Column_Selected_File.VisibleIndex = 0;
            this.Column_Selected_File.Width = 25;
            // 
            // Column_Name_File
            // 
            this.Column_Name_File.AppearanceHeader.Options.UseTextOptions = true;
            this.Column_Name_File.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Column_Name_File.Caption = "Название";
            this.Column_Name_File.FieldName = "Name";
            this.Column_Name_File.Name = "Column_Name_File";
            this.Column_Name_File.OptionsColumn.ReadOnly = true;
            this.Column_Name_File.Visible = true;
            this.Column_Name_File.VisibleIndex = 1;
            this.Column_Name_File.Width = 247;
            // 
            // Column_Size_File
            // 
            this.Column_Size_File.AppearanceHeader.Options.UseTextOptions = true;
            this.Column_Size_File.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Column_Size_File.Caption = "Размер (Мб)";
            this.Column_Size_File.ColumnEdit = this.Repository_FileSize;
            this.Column_Size_File.FieldName = "Size";
            this.Column_Size_File.Name = "Column_Size_File";
            this.Column_Size_File.OptionsColumn.ReadOnly = true;
            this.Column_Size_File.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.Column_Size_File.Visible = true;
            this.Column_Size_File.VisibleIndex = 2;
            this.Column_Size_File.Width = 76;
            // 
            // Repository_FileSize
            // 
            this.Repository_FileSize.AutoHeight = false;
            this.Repository_FileSize.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, false, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "", null, null, true)});
            this.Repository_FileSize.Mask.EditMask = "### ##0.###";
            this.Repository_FileSize.Mask.ShowPlaceHolders = false;
            this.Repository_FileSize.Mask.UseMaskAsDisplayFormat = true;
            this.Repository_FileSize.Name = "Repository_FileSize";
            // 
            // Column_Category_File
            // 
            this.Column_Category_File.AppearanceHeader.Options.UseTextOptions = true;
            this.Column_Category_File.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Column_Category_File.Caption = "Категория";
            this.Column_Category_File.FieldName = "Category";
            this.Column_Category_File.Name = "Column_Category_File";
            this.Column_Category_File.OptionsColumn.ReadOnly = true;
            this.Column_Category_File.Visible = true;
            this.Column_Category_File.VisibleIndex = 3;
            this.Column_Category_File.Width = 149;
            // 
            // Column_Registrar_File
            // 
            this.Column_Registrar_File.AppearanceHeader.Options.UseTextOptions = true;
            this.Column_Registrar_File.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Column_Registrar_File.Caption = "Автор";
            this.Column_Registrar_File.FieldName = "Registrar";
            this.Column_Registrar_File.Name = "Column_Registrar_File";
            this.Column_Registrar_File.OptionsColumn.ReadOnly = true;
            this.Column_Registrar_File.Visible = true;
            this.Column_Registrar_File.VisibleIndex = 4;
            this.Column_Registrar_File.Width = 90;
            // 
            // Column_CreationDate_File
            // 
            this.Column_CreationDate_File.AppearanceCell.Options.UseTextOptions = true;
            this.Column_CreationDate_File.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Column_CreationDate_File.AppearanceHeader.Options.UseTextOptions = true;
            this.Column_CreationDate_File.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Column_CreationDate_File.Caption = "Дата создания";
            this.Column_CreationDate_File.ColumnEdit = this.Repository_DateEdit;
            this.Column_CreationDate_File.FieldName = "CreationDate";
            this.Column_CreationDate_File.Name = "Column_CreationDate_File";
            this.Column_CreationDate_File.OptionsColumn.ReadOnly = true;
            this.Column_CreationDate_File.Visible = true;
            this.Column_CreationDate_File.VisibleIndex = 5;
            this.Column_CreationDate_File.Width = 105;
            // 
            // Repository_DateEdit
            // 
            this.Repository_DateEdit.AutoHeight = false;
            this.Repository_DateEdit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, false, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3, "", null, null, true)});
            this.Repository_DateEdit.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.Repository_DateEdit.Mask.EditMask = "D";
            this.Repository_DateEdit.Mask.UseMaskAsDisplayFormat = true;
            this.Repository_DateEdit.Name = "Repository_DateEdit";
            this.Repository_DateEdit.ReadOnly = true;
            // 
            // Edit_DVFolder
            // 
            this.Edit_DVFolder.Location = new System.Drawing.Point(271, 51);
            this.Edit_DVFolder.MenuManager = this.Control_Ribbon;
            this.Edit_DVFolder.Name = "Edit_DVFolder";
            this.Edit_DVFolder.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.Edit_DVFolder.Size = new System.Drawing.Size(467, 20);
            this.Edit_DVFolder.StyleController = this.Control_Layout;
            this.Edit_DVFolder.TabIndex = 14;
            this.Edit_DVFolder.ButtonPressed += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.Edit_DVFolder_ButtonPressed);
            // 
            // Edit_FileSize
            // 
            this.Edit_FileSize.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.Edit_FileSize.Location = new System.Drawing.Point(79, 51);
            this.Edit_FileSize.MenuManager = this.Control_Ribbon;
            this.Edit_FileSize.Name = "Edit_FileSize";
            this.Edit_FileSize.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.Edit_FileSize.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.Edit_FileSize.Properties.Mask.EditMask = "### ##0.###";
            this.Edit_FileSize.Properties.Mask.ShowPlaceHolders = false;
            this.Edit_FileSize.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.Edit_FileSize.Properties.MaxValue = new decimal(new int[] {
            1048576,
            0,
            0,
            0});
            this.Edit_FileSize.Size = new System.Drawing.Size(178, 20);
            this.Edit_FileSize.StyleController = this.Control_Layout;
            this.Edit_FileSize.TabIndex = 13;
            // 
            // Edit_Action
            // 
            this.Edit_Action.EditValue = ">";
            this.Edit_Action.Location = new System.Drawing.Point(13, 51);
            this.Edit_Action.MenuManager = this.Control_Ribbon;
            this.Edit_Action.Name = "Edit_Action";
            this.Edit_Action.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.Edit_Action.Properties.Appearance.Options.UseTextOptions = true;
            this.Edit_Action.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Edit_Action.Properties.AppearanceDisabled.Options.UseTextOptions = true;
            this.Edit_Action.Properties.AppearanceDisabled.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Edit_Action.Properties.AppearanceDropDown.Options.UseTextOptions = true;
            this.Edit_Action.Properties.AppearanceDropDown.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Edit_Action.Properties.AppearanceFocused.Options.UseTextOptions = true;
            this.Edit_Action.Properties.AppearanceFocused.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Edit_Action.Properties.AppearanceReadOnly.Options.UseTextOptions = true;
            this.Edit_Action.Properties.AppearanceReadOnly.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Edit_Action.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.Edit_Action.Properties.Items.AddRange(new object[] {
            ">",
            "<",
            "="});
            this.Edit_Action.Size = new System.Drawing.Size(52, 20);
            this.Edit_Action.StyleController = this.Control_Layout;
            this.Edit_Action.TabIndex = 12;
            // 
            // Control_Objects
            // 
            this.Control_Objects.DataSource = this.BindingSource_Unrelated;
            this.Control_Objects.Location = new System.Drawing.Point(25, 66);
            this.Control_Objects.MainView = this.View_Objects;
            this.Control_Objects.Name = "Control_Objects";
            this.Control_Objects.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.Repository_Guid});
            this.Control_Objects.Size = new System.Drawing.Size(701, 181);
            this.Control_Objects.TabIndex = 0;
            this.Control_Objects.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.View_Objects});
            // 
            // View_Objects
            // 
            this.View_Objects.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.Column_Selected_Object,
            this.Column_DocType_Object,
            this.Column_DocName_Object,
            this.Column_Category_Object,
            this.Column_Folder_Object,
            this.Column_CardId_Object});
            this.View_Objects.GridControl = this.Control_Objects;
            this.View_Objects.Name = "View_Objects";
            this.View_Objects.OptionsView.ShowGroupPanel = false;
            this.View_Objects.DoubleClick += new System.EventHandler(this.View_Unrelated_DoubleClick);
            // 
            // Column_Selected_Object
            // 
            this.Column_Selected_Object.AppearanceHeader.Options.UseTextOptions = true;
            this.Column_Selected_Object.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Column_Selected_Object.Caption = "...";
            this.Column_Selected_Object.FieldName = "Selected";
            this.Column_Selected_Object.MaxWidth = 25;
            this.Column_Selected_Object.MinWidth = 25;
            this.Column_Selected_Object.Name = "Column_Selected_Object";
            this.Column_Selected_Object.Visible = true;
            this.Column_Selected_Object.VisibleIndex = 0;
            this.Column_Selected_Object.Width = 25;
            // 
            // Column_DocType_Object
            // 
            this.Column_DocType_Object.AppearanceHeader.Options.UseTextOptions = true;
            this.Column_DocType_Object.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Column_DocType_Object.Caption = "Тип документа";
            this.Column_DocType_Object.FieldName = "DocType";
            this.Column_DocType_Object.Name = "Column_DocType_Object";
            this.Column_DocType_Object.OptionsColumn.ReadOnly = true;
            this.Column_DocType_Object.Visible = true;
            this.Column_DocType_Object.VisibleIndex = 1;
            this.Column_DocType_Object.Width = 138;
            // 
            // Column_DocName_Object
            // 
            this.Column_DocName_Object.AppearanceHeader.Options.UseTextOptions = true;
            this.Column_DocName_Object.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Column_DocName_Object.Caption = "Название документа";
            this.Column_DocName_Object.FieldName = "DocName";
            this.Column_DocName_Object.Name = "Column_DocName_Object";
            this.Column_DocName_Object.OptionsColumn.ReadOnly = true;
            this.Column_DocName_Object.Visible = true;
            this.Column_DocName_Object.VisibleIndex = 2;
            this.Column_DocName_Object.Width = 136;
            // 
            // Column_Category_Object
            // 
            this.Column_Category_Object.AppearanceHeader.Options.UseTextOptions = true;
            this.Column_Category_Object.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Column_Category_Object.Caption = "Категория";
            this.Column_Category_Object.FieldName = "Category";
            this.Column_Category_Object.Name = "Column_Category_Object";
            this.Column_Category_Object.Visible = true;
            this.Column_Category_Object.VisibleIndex = 3;
            this.Column_Category_Object.Width = 88;
            // 
            // Column_Folder_Object
            // 
            this.Column_Folder_Object.AppearanceHeader.Options.UseTextOptions = true;
            this.Column_Folder_Object.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Column_Folder_Object.Caption = "Папка";
            this.Column_Folder_Object.FieldName = "Folder";
            this.Column_Folder_Object.Name = "Column_Folder_Object";
            this.Column_Folder_Object.OptionsColumn.ReadOnly = true;
            this.Column_Folder_Object.Visible = true;
            this.Column_Folder_Object.VisibleIndex = 4;
            this.Column_Folder_Object.Width = 132;
            // 
            // Column_CardId_Object
            // 
            this.Column_CardId_Object.AppearanceHeader.Options.UseTextOptions = true;
            this.Column_CardId_Object.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Column_CardId_Object.Caption = "ИД карточки";
            this.Column_CardId_Object.ColumnEdit = this.Repository_Guid;
            this.Column_CardId_Object.FieldName = "CardId";
            this.Column_CardId_Object.Name = "Column_CardId_Object";
            this.Column_CardId_Object.OptionsColumn.ReadOnly = true;
            this.Column_CardId_Object.Visible = true;
            this.Column_CardId_Object.VisibleIndex = 5;
            this.Column_CardId_Object.Width = 146;
            // 
            // Repository_Guid
            // 
            this.Repository_Guid.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.Repository_Guid.AutoHeight = false;
            this.Repository_Guid.Mask.EditMask = "[0-9A-F]{8}(-[0-9A-F]{4}){3}-[0-9A-F]{12}";
            this.Repository_Guid.Mask.IgnoreMaskBlank = false;
            this.Repository_Guid.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.Repository_Guid.Mask.UseMaskAsDisplayFormat = true;
            this.Repository_Guid.Name = "Repository_Guid";
            // 
            // Edit_FindPattern
            // 
            this.Edit_FindPattern.Location = new System.Drawing.Point(25, 247);
            this.Edit_FindPattern.Name = "Edit_FindPattern";
            this.Edit_FindPattern.Size = new System.Drawing.Size(701, 20);
            this.Edit_FindPattern.StyleController = this.Control_Layout;
            this.Edit_FindPattern.TabIndex = 10;
            // 
            // Edit_ReplacePattern
            // 
            this.Edit_ReplacePattern.Location = new System.Drawing.Point(25, 287);
            this.Edit_ReplacePattern.Name = "Edit_ReplacePattern";
            this.Edit_ReplacePattern.Size = new System.Drawing.Size(701, 20);
            this.Edit_ReplacePattern.StyleController = this.Control_Layout;
            this.Edit_ReplacePattern.TabIndex = 11;
            // 
            // Edit_NewPath
            // 
            this.Edit_NewPath.Location = new System.Drawing.Point(165, 114);
            this.Edit_NewPath.Name = "Edit_NewPath";
            this.Edit_NewPath.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4, "Выбрать папку...", null, null, true)});
            this.Edit_NewPath.Size = new System.Drawing.Size(401, 20);
            this.Edit_NewPath.StyleController = this.Control_Layout;
            this.Edit_NewPath.TabIndex = 7;
            this.Edit_NewPath.ButtonPressed += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.Edit_NewPath_ButtonPressed);
            // 
            // Edit_OldPath
            // 
            this.Edit_OldPath.Location = new System.Drawing.Point(165, 90);
            this.Edit_OldPath.Name = "Edit_OldPath";
            this.Edit_OldPath.Size = new System.Drawing.Size(401, 20);
            this.Edit_OldPath.StyleController = this.Control_Layout;
            this.Edit_OldPath.TabIndex = 5;
            // 
            // Edit_CardId
            // 
            this.Edit_CardId.EditValue = "";
            this.Edit_CardId.Location = new System.Drawing.Point(165, 66);
            this.Edit_CardId.Name = "Edit_CardId";
            this.Edit_CardId.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5, "Выбрать карточку...", null, null, true),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Redo, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject6, "Открыть карточку...", null, null, true)});
            this.Edit_CardId.Properties.Mask.EditMask = "[0-9A-F]{8}(-[0-9A-F]{4}){3}-[0-9A-F]{12}";
            this.Edit_CardId.Properties.Mask.IgnoreMaskBlank = false;
            this.Edit_CardId.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.Edit_CardId.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.Edit_CardId.Size = new System.Drawing.Size(401, 20);
            this.Edit_CardId.StyleController = this.Control_Layout;
            this.Edit_CardId.TabIndex = 3;
            this.Edit_CardId.ButtonPressed += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.Edit_CardId_ButtonPressed);
            // 
            // lcg
            // 
            this.lcg.CustomizationFormText = "Root";
            this.lcg.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.lcg.GroupBordersVisible = false;
            this.lcg.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.Control_Tabs});
            this.lcg.Location = new System.Drawing.Point(0, 0);
            this.lcg.Name = "Root";
            this.lcg.Padding = new DevExpress.XtraLayout.Utils.Padding(8, 8, 8, 8);
            this.lcg.Size = new System.Drawing.Size(751, 426);
            this.lcg.Text = "Root";
            this.lcg.TextVisible = false;
            // 
            // Control_Tabs
            // 
            this.Control_Tabs.CustomizationFormText = "Control_Tabs";
            this.Control_Tabs.Location = new System.Drawing.Point(0, 0);
            this.Control_Tabs.Name = "Control_Tabs";
            this.Control_Tabs.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.Control_Tabs.SelectedTabPage = this.lcg_AssignRights;
            this.Control_Tabs.SelectedTabPageIndex = 0;
            this.Control_Tabs.Size = new System.Drawing.Size(735, 410);
            this.Control_Tabs.TabPages.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcg_AssignRights,
            this.lcg_PathCorrection,
            this.lcg_ArchiveAnalyzing,
            this.lcg_UploadFilesToServer,
            this.Ing_ControlOfApplicability});
            this.Control_Tabs.Text = "Control_Tabs";
            // 
            // lcg_AssignRights
            // 
            this.lcg_AssignRights.CustomizationFormText = "Назначение прав";
            this.lcg_AssignRights.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.Control_Matrix});
            this.lcg_AssignRights.Location = new System.Drawing.Point(0, 0);
            this.lcg_AssignRights.Name = "lcg_AssignRights";
            this.lcg_AssignRights.Size = new System.Drawing.Size(729, 382);
            this.lcg_AssignRights.Text = "Назначение прав";
            // 
            // Control_Matrix
            // 
            this.Control_Matrix.CustomizationFormText = "tabbedControlGroup1";
            this.Control_Matrix.HeaderOrientation = DevExpress.XtraTab.TabOrientation.Horizontal;
            this.Control_Matrix.Location = new System.Drawing.Point(0, 0);
            this.Control_Matrix.Name = "Control_Matrix";
            this.Control_Matrix.SelectedTabPage = this.lcg_CardRightsMatrix;
            this.Control_Matrix.SelectedTabPageIndex = 0;
            this.Control_Matrix.Size = new System.Drawing.Size(729, 382);
            this.Control_Matrix.TabPages.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcg_CardRightsMatrix,
            this.lcg_FolderRirhtsMatrix});
            this.Control_Matrix.Text = "Control_Matrix";
            // 
            // lcg_FolderRirhtsMatrix
            // 
            this.lcg_FolderRirhtsMatrix.CustomizationFormText = "Права на папки";
            this.lcg_FolderRirhtsMatrix.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lci_Control_FolderRights});
            this.lcg_FolderRirhtsMatrix.Location = new System.Drawing.Point(0, 0);
            this.lcg_FolderRirhtsMatrix.Name = "lcg_FolderRirhtsMatrix";
            this.lcg_FolderRirhtsMatrix.Size = new System.Drawing.Size(705, 336);
            this.lcg_FolderRirhtsMatrix.Text = "Права на папки";
            // 
            // lci_Control_FolderRights
            // 
            this.lci_Control_FolderRights.Control = this.Control_FolderRights;
            this.lci_Control_FolderRights.CustomizationFormText = "lci_Control_FolderRights";
            this.lci_Control_FolderRights.Location = new System.Drawing.Point(0, 0);
            this.lci_Control_FolderRights.Name = "lci_Control_FolderRights";
            this.lci_Control_FolderRights.Size = new System.Drawing.Size(705, 336);
            this.lci_Control_FolderRights.Text = "lci_Control_FolderRights";
            this.lci_Control_FolderRights.TextSize = new System.Drawing.Size(0, 0);
            this.lci_Control_FolderRights.TextToControlDistance = 0;
            this.lci_Control_FolderRights.TextVisible = false;
            // 
            // lcg_CardRightsMatrix
            // 
            this.lcg_CardRightsMatrix.CustomizationFormText = "Права на карточки";
            this.lcg_CardRightsMatrix.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lci_Control_CardRights});
            this.lcg_CardRightsMatrix.Location = new System.Drawing.Point(0, 0);
            this.lcg_CardRightsMatrix.Name = "lcg_CardRightsMatrix";
            this.lcg_CardRightsMatrix.Size = new System.Drawing.Size(705, 336);
            this.lcg_CardRightsMatrix.Text = "Права на карточки";
            // 
            // lci_Control_CardRights
            // 
            this.lci_Control_CardRights.Control = this.Control_CardRights;
            this.lci_Control_CardRights.CustomizationFormText = "lci_Control_CardRights";
            this.lci_Control_CardRights.Location = new System.Drawing.Point(0, 0);
            this.lci_Control_CardRights.Name = "lci_Control_CardRights";
            this.lci_Control_CardRights.Size = new System.Drawing.Size(705, 336);
            this.lci_Control_CardRights.Text = "lci_Control_CardRights";
            this.lci_Control_CardRights.TextSize = new System.Drawing.Size(0, 0);
            this.lci_Control_CardRights.TextToControlDistance = 0;
            this.lci_Control_CardRights.TextVisible = false;
            // 
            // lcg_PathCorrection
            // 
            this.lcg_PathCorrection.CustomizationFormText = "Корректировка пути";
            this.lcg_PathCorrection.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcg_PathCorrection_Cards,
            this.lcg_PathCorrection_Card,
            this.emptySpaceItem2,
            this.emptySpaceItem1});
            this.lcg_PathCorrection.Location = new System.Drawing.Point(0, 0);
            this.lcg_PathCorrection.Name = "lcg_PathCorrection";
            this.lcg_PathCorrection.Size = new System.Drawing.Size(729, 382);
            this.lcg_PathCorrection.Text = "Корректировки";
            // 
            // lcg_PathCorrection_Cards
            // 
            this.lcg_PathCorrection_Cards.CustomizationFormText = "Поиск и замена";
            this.lcg_PathCorrection_Cards.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lci_Edit_IfPattern,
            this.lci_Edit_FindPattern,
            this.lci_Edit_ReplacePattern,
            this.lci_Button_Replace,
            this.emptySpaceItem12});
            this.lcg_PathCorrection_Cards.Location = new System.Drawing.Point(0, 125);
            this.lcg_PathCorrection_Cards.Name = "lcg_PathCorrection_Cards";
            this.lcg_PathCorrection_Cards.Size = new System.Drawing.Size(729, 199);
            this.lcg_PathCorrection_Cards.Text = "Поиск и замена";
            // 
            // lci_Edit_IfPattern
            // 
            this.lci_Edit_IfPattern.Control = this.Edit_IfPattern;
            this.lci_Edit_IfPattern.CustomizationFormText = "Если путь содержит:";
            this.lci_Edit_IfPattern.Location = new System.Drawing.Point(0, 0);
            this.lci_Edit_IfPattern.Name = "lci_Edit_IfPattern";
            this.lci_Edit_IfPattern.Size = new System.Drawing.Size(705, 40);
            this.lci_Edit_IfPattern.Text = "Если путь содержит:";
            this.lci_Edit_IfPattern.TextLocation = DevExpress.Utils.Locations.Top;
            this.lci_Edit_IfPattern.TextSize = new System.Drawing.Size(137, 13);
            // 
            // lci_Edit_FindPattern
            // 
            this.lci_Edit_FindPattern.Control = this.Edit_FindPattern;
            this.lci_Edit_FindPattern.CustomizationFormText = "То найти:";
            this.lci_Edit_FindPattern.Location = new System.Drawing.Point(0, 40);
            this.lci_Edit_FindPattern.Name = "lci_Edit_FindPattern";
            this.lci_Edit_FindPattern.Size = new System.Drawing.Size(705, 40);
            this.lci_Edit_FindPattern.Text = "То найти:";
            this.lci_Edit_FindPattern.TextLocation = DevExpress.Utils.Locations.Top;
            this.lci_Edit_FindPattern.TextSize = new System.Drawing.Size(137, 13);
            // 
            // lci_Edit_ReplacePattern
            // 
            this.lci_Edit_ReplacePattern.Control = this.Edit_ReplacePattern;
            this.lci_Edit_ReplacePattern.CustomizationFormText = "И заменить на:";
            this.lci_Edit_ReplacePattern.Location = new System.Drawing.Point(0, 80);
            this.lci_Edit_ReplacePattern.Name = "lci_Edit_ReplacePattern";
            this.lci_Edit_ReplacePattern.Size = new System.Drawing.Size(705, 40);
            this.lci_Edit_ReplacePattern.Text = "И заменить на:";
            this.lci_Edit_ReplacePattern.TextLocation = DevExpress.Utils.Locations.Top;
            this.lci_Edit_ReplacePattern.TextSize = new System.Drawing.Size(137, 13);
            // 
            // lci_Button_Replace
            // 
            this.lci_Button_Replace.Control = this.Button_Replace;
            this.lci_Button_Replace.CustomizationFormText = "layoutControlItem3";
            this.lci_Button_Replace.Location = new System.Drawing.Point(0, 130);
            this.lci_Button_Replace.Name = "lci_Button_Replace";
            this.lci_Button_Replace.Size = new System.Drawing.Size(705, 26);
            this.lci_Button_Replace.Text = "lci_Button_Replace";
            this.lci_Button_Replace.TextSize = new System.Drawing.Size(0, 0);
            this.lci_Button_Replace.TextToControlDistance = 0;
            this.lci_Button_Replace.TextVisible = false;
            // 
            // emptySpaceItem12
            // 
            this.emptySpaceItem12.AllowHotTrack = false;
            this.emptySpaceItem12.CustomizationFormText = "emptySpaceItem12";
            this.emptySpaceItem12.Location = new System.Drawing.Point(0, 120);
            this.emptySpaceItem12.MaxSize = new System.Drawing.Size(0, 10);
            this.emptySpaceItem12.MinSize = new System.Drawing.Size(10, 10);
            this.emptySpaceItem12.Name = "emptySpaceItem12";
            this.emptySpaceItem12.Size = new System.Drawing.Size(705, 10);
            this.emptySpaceItem12.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.emptySpaceItem12.Text = "emptySpaceItem12";
            this.emptySpaceItem12.TextSize = new System.Drawing.Size(0, 0);
            // 
            // lcg_PathCorrection_Card
            // 
            this.lcg_PathCorrection_Card.CustomizationFormText = "Корректировка пути";
            this.lcg_PathCorrection_Card.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lci_Edit_CardId,
            this.lci_Edit_OldPath,
            this.lci_Edit_NewPath,
            this.layoutControlItem1,
            this.emptySpaceItem10,
            this.emptySpaceItem11,
            this.layoutControlItem2});
            this.lcg_PathCorrection_Card.Location = new System.Drawing.Point(0, 0);
            this.lcg_PathCorrection_Card.Name = "lcg_PathCorrection_Card";
            this.lcg_PathCorrection_Card.Size = new System.Drawing.Size(729, 115);
            this.lcg_PathCorrection_Card.Text = "Корректировка пути";
            // 
            // lci_Edit_CardId
            // 
            this.lci_Edit_CardId.Control = this.Edit_CardId;
            this.lci_Edit_CardId.CustomizationFormText = "Идентификатор карточки:";
            this.lci_Edit_CardId.Location = new System.Drawing.Point(0, 0);
            this.lci_Edit_CardId.Name = "lci_Edit_CardId";
            this.lci_Edit_CardId.Size = new System.Drawing.Size(545, 24);
            this.lci_Edit_CardId.Text = "Идентификатор карточки:";
            this.lci_Edit_CardId.TextSize = new System.Drawing.Size(137, 13);
            // 
            // lci_Edit_OldPath
            // 
            this.lci_Edit_OldPath.Control = this.Edit_OldPath;
            this.lci_Edit_OldPath.CustomizationFormText = "Старый путь:";
            this.lci_Edit_OldPath.Location = new System.Drawing.Point(0, 24);
            this.lci_Edit_OldPath.Name = "lci_Edit_OldPath";
            this.lci_Edit_OldPath.Size = new System.Drawing.Size(545, 24);
            this.lci_Edit_OldPath.Text = "Старый путь:";
            this.lci_Edit_OldPath.TextSize = new System.Drawing.Size(137, 13);
            // 
            // lci_Edit_NewPath
            // 
            this.lci_Edit_NewPath.Control = this.Edit_NewPath;
            this.lci_Edit_NewPath.CustomizationFormText = "Новый путь:";
            this.lci_Edit_NewPath.Location = new System.Drawing.Point(0, 48);
            this.lci_Edit_NewPath.Name = "lci_Edit_NewPath";
            this.lci_Edit_NewPath.Size = new System.Drawing.Size(545, 24);
            this.lci_Edit_NewPath.Text = "Новый путь:";
            this.lci_Edit_NewPath.TextSize = new System.Drawing.Size(137, 13);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.Button_CheckPath;
            this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem1.Location = new System.Drawing.Point(555, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(150, 26);
            this.layoutControlItem1.Text = "layoutControlItem1";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextToControlDistance = 0;
            this.layoutControlItem1.TextVisible = false;
            // 
            // emptySpaceItem10
            // 
            this.emptySpaceItem10.AllowHotTrack = false;
            this.emptySpaceItem10.CustomizationFormText = "emptySpaceItem10";
            this.emptySpaceItem10.Location = new System.Drawing.Point(555, 26);
            this.emptySpaceItem10.Name = "emptySpaceItem10";
            this.emptySpaceItem10.Size = new System.Drawing.Size(150, 20);
            this.emptySpaceItem10.Text = "emptySpaceItem10";
            this.emptySpaceItem10.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem11
            // 
            this.emptySpaceItem11.AllowHotTrack = false;
            this.emptySpaceItem11.CustomizationFormText = "emptySpaceItem11";
            this.emptySpaceItem11.Location = new System.Drawing.Point(545, 0);
            this.emptySpaceItem11.MaxSize = new System.Drawing.Size(10, 0);
            this.emptySpaceItem11.MinSize = new System.Drawing.Size(10, 10);
            this.emptySpaceItem11.Name = "emptySpaceItem11";
            this.emptySpaceItem11.Size = new System.Drawing.Size(10, 72);
            this.emptySpaceItem11.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.emptySpaceItem11.Text = "emptySpaceItem11";
            this.emptySpaceItem11.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.Button_SavePath;
            this.layoutControlItem2.CustomizationFormText = "layoutControlItem2";
            this.layoutControlItem2.Location = new System.Drawing.Point(555, 46);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(150, 26);
            this.layoutControlItem2.Text = "layoutControlItem2";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextToControlDistance = 0;
            this.layoutControlItem2.TextVisible = false;
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.CustomizationFormText = "emptySpaceItem2";
            this.emptySpaceItem2.Location = new System.Drawing.Point(0, 115);
            this.emptySpaceItem2.MaxSize = new System.Drawing.Size(0, 10);
            this.emptySpaceItem2.MinSize = new System.Drawing.Size(10, 10);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(729, 10);
            this.emptySpaceItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.emptySpaceItem2.Text = "emptySpaceItem2";
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 324);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(729, 58);
            this.emptySpaceItem1.Text = "emptySpaceItem1";
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // lcg_ArchiveAnalyzing
            // 
            this.lcg_ArchiveAnalyzing.CustomizationFormText = "Анализ архива";
            this.lcg_ArchiveAnalyzing.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcg_UnrelatedObjects,
            this.lcg_Matches,
            this.splitterItem1});
            this.lcg_ArchiveAnalyzing.Location = new System.Drawing.Point(0, 0);
            this.lcg_ArchiveAnalyzing.Name = "lcg_ArchiveAnalyzing";
            this.lcg_ArchiveAnalyzing.Size = new System.Drawing.Size(729, 382);
            this.lcg_ArchiveAnalyzing.Text = "Анализ архива";
            // 
            // lcg_UnrelatedObjects
            // 
            this.lcg_UnrelatedObjects.CustomizationFormText = "Найденные карточки/папки:";
            this.lcg_UnrelatedObjects.ExpandButtonLocation = DevExpress.Utils.GroupElementLocation.AfterText;
            this.lcg_UnrelatedObjects.ExpandButtonVisible = true;
            this.lcg_UnrelatedObjects.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lci_Control_UnrelatedDirs});
            this.lcg_UnrelatedObjects.Location = new System.Drawing.Point(0, 0);
            this.lcg_UnrelatedObjects.Name = "lcg_UnrelatedObjects";
            this.lcg_UnrelatedObjects.Size = new System.Drawing.Size(729, 228);
            this.lcg_UnrelatedObjects.Text = "Найденные карточки/папки:";
            // 
            // lci_Control_UnrelatedDirs
            // 
            this.lci_Control_UnrelatedDirs.Control = this.Control_Objects;
            this.lci_Control_UnrelatedDirs.CustomizationFormText = "lci_Control_UnrelatedDirs";
            this.lci_Control_UnrelatedDirs.Location = new System.Drawing.Point(0, 0);
            this.lci_Control_UnrelatedDirs.Name = "lci_Control_UnrelatedDirs";
            this.lci_Control_UnrelatedDirs.Size = new System.Drawing.Size(705, 185);
            this.lci_Control_UnrelatedDirs.Text = "lci_Control_UnrelatedDirs";
            this.lci_Control_UnrelatedDirs.TextSize = new System.Drawing.Size(0, 0);
            this.lci_Control_UnrelatedDirs.TextToControlDistance = 0;
            this.lci_Control_UnrelatedDirs.TextVisible = false;
            // 
            // lcg_Matches
            // 
            this.lcg_Matches.CustomizationFormText = "Соответствия по ИН:";
            this.lcg_Matches.ExpandButtonLocation = DevExpress.Utils.GroupElementLocation.AfterText;
            this.lcg_Matches.ExpandButtonVisible = true;
            this.lcg_Matches.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lci_Control_Matches});
            this.lcg_Matches.Location = new System.Drawing.Point(0, 233);
            this.lcg_Matches.Name = "lcg_Matches";
            this.lcg_Matches.Size = new System.Drawing.Size(729, 149);
            this.lcg_Matches.Text = "Соответствия по ИН:";
            // 
            // lci_Control_Matches
            // 
            this.lci_Control_Matches.Control = this.Control_Matches;
            this.lci_Control_Matches.CustomizationFormText = "lci_Control_Matches";
            this.lci_Control_Matches.Location = new System.Drawing.Point(0, 0);
            this.lci_Control_Matches.Name = "lci_Control_Matches";
            this.lci_Control_Matches.Size = new System.Drawing.Size(705, 106);
            this.lci_Control_Matches.Text = "lci_Control_Matches";
            this.lci_Control_Matches.TextSize = new System.Drawing.Size(0, 0);
            this.lci_Control_Matches.TextToControlDistance = 0;
            this.lci_Control_Matches.TextVisible = false;
            // 
            // splitterItem1
            // 
            this.splitterItem1.AllowHotTrack = true;
            this.splitterItem1.CustomizationFormText = "splitterItem1";
            this.splitterItem1.Location = new System.Drawing.Point(0, 228);
            this.splitterItem1.Name = "splitterItem1";
            this.splitterItem1.Size = new System.Drawing.Size(729, 5);
            // 
            // lcg_UploadFilesToServer
            // 
            this.lcg_UploadFilesToServer.CustomizationFormText = "Выгрузка файлов на сервер";
            this.lcg_UploadFilesToServer.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lci_Action,
            this.lci_Edit_FileSize,
            this.lci_Edit_DVFolder,
            this.lci_Control_FoundFiles,
            this.lci_Button_SelectAll,
            this.lci_Button_UnselectAll,
            this.lci_Edit_TotalFileSize,
            this.emptySpaceItem3,
            this.emptySpaceItem4,
            this.emptySpaceItem5,
            this.emptySpaceItem6,
            this.emptySpaceItem7,
            this.emptySpaceItem8,
            this.emptySpaceItem9});
            this.lcg_UploadFilesToServer.Location = new System.Drawing.Point(0, 0);
            this.lcg_UploadFilesToServer.Name = "lcg_UploadFilesToServer";
            this.lcg_UploadFilesToServer.Size = new System.Drawing.Size(729, 382);
            this.lcg_UploadFilesToServer.Text = "Выгрузка файлов на сервер";
            // 
            // lci_Action
            // 
            this.lci_Action.Control = this.Edit_Action;
            this.lci_Action.CustomizationFormText = "Действие";
            this.lci_Action.Location = new System.Drawing.Point(0, 16);
            this.lci_Action.Name = "lci_Action";
            this.lci_Action.Size = new System.Drawing.Size(56, 24);
            this.lci_Action.Text = "Действие";
            this.lci_Action.TextLocation = DevExpress.Utils.Locations.Top;
            this.lci_Action.TextSize = new System.Drawing.Size(0, 0);
            this.lci_Action.TextToControlDistance = 0;
            this.lci_Action.TextVisible = false;
            // 
            // lci_Edit_FileSize
            // 
            this.lci_Edit_FileSize.Control = this.Edit_FileSize;
            this.lci_Edit_FileSize.CustomizationFormText = "Размер файла:";
            this.lci_Edit_FileSize.Location = new System.Drawing.Point(66, 0);
            this.lci_Edit_FileSize.Name = "lci_Edit_FileSize";
            this.lci_Edit_FileSize.Size = new System.Drawing.Size(182, 40);
            this.lci_Edit_FileSize.Text = "Размер файла (Мб):";
            this.lci_Edit_FileSize.TextLocation = DevExpress.Utils.Locations.Top;
            this.lci_Edit_FileSize.TextSize = new System.Drawing.Size(137, 13);
            // 
            // lci_Edit_DVFolder
            // 
            this.lci_Edit_DVFolder.Control = this.Edit_DVFolder;
            this.lci_Edit_DVFolder.CustomizationFormText = "Папка:";
            this.lci_Edit_DVFolder.Location = new System.Drawing.Point(258, 0);
            this.lci_Edit_DVFolder.Name = "lci_Edit_DVFolder";
            this.lci_Edit_DVFolder.Size = new System.Drawing.Size(471, 40);
            this.lci_Edit_DVFolder.Text = "Папка:";
            this.lci_Edit_DVFolder.TextLocation = DevExpress.Utils.Locations.Top;
            this.lci_Edit_DVFolder.TextSize = new System.Drawing.Size(137, 13);
            // 
            // lci_Control_FoundFiles
            // 
            this.lci_Control_FoundFiles.Control = this.Control_FoundFiles;
            this.lci_Control_FoundFiles.CustomizationFormText = "Найденные файлы:";
            this.lci_Control_FoundFiles.Location = new System.Drawing.Point(0, 50);
            this.lci_Control_FoundFiles.Name = "lci_Control_FoundFiles";
            this.lci_Control_FoundFiles.Size = new System.Drawing.Size(729, 296);
            this.lci_Control_FoundFiles.Text = "Найденные файлы:";
            this.lci_Control_FoundFiles.TextLocation = DevExpress.Utils.Locations.Top;
            this.lci_Control_FoundFiles.TextSize = new System.Drawing.Size(0, 0);
            this.lci_Control_FoundFiles.TextToControlDistance = 0;
            this.lci_Control_FoundFiles.TextVisible = false;
            // 
            // lci_Button_SelectAll
            // 
            this.lci_Button_SelectAll.Control = this.Button_SelectAll;
            this.lci_Button_SelectAll.CustomizationFormText = "lci_Button_SelectAll";
            this.lci_Button_SelectAll.Location = new System.Drawing.Point(0, 356);
            this.lci_Button_SelectAll.MaxSize = new System.Drawing.Size(128, 26);
            this.lci_Button_SelectAll.MinSize = new System.Drawing.Size(128, 26);
            this.lci_Button_SelectAll.Name = "lci_Button_SelectAll";
            this.lci_Button_SelectAll.Size = new System.Drawing.Size(128, 26);
            this.lci_Button_SelectAll.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.lci_Button_SelectAll.Text = "lci_Button_SelectAll";
            this.lci_Button_SelectAll.TextSize = new System.Drawing.Size(0, 0);
            this.lci_Button_SelectAll.TextToControlDistance = 0;
            this.lci_Button_SelectAll.TextVisible = false;
            // 
            // lci_Button_UnselectAll
            // 
            this.lci_Button_UnselectAll.Control = this.Button_UnselectAll;
            this.lci_Button_UnselectAll.CustomizationFormText = "lci_Button_UnselectAll";
            this.lci_Button_UnselectAll.Location = new System.Drawing.Point(138, 356);
            this.lci_Button_UnselectAll.MaxSize = new System.Drawing.Size(128, 26);
            this.lci_Button_UnselectAll.MinSize = new System.Drawing.Size(128, 26);
            this.lci_Button_UnselectAll.Name = "lci_Button_UnselectAll";
            this.lci_Button_UnselectAll.Size = new System.Drawing.Size(128, 26);
            this.lci_Button_UnselectAll.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.lci_Button_UnselectAll.Text = "lci_Button_UnselectAll";
            this.lci_Button_UnselectAll.TextSize = new System.Drawing.Size(0, 0);
            this.lci_Button_UnselectAll.TextToControlDistance = 0;
            this.lci_Button_UnselectAll.TextVisible = false;
            // 
            // lci_Edit_TotalFileSize
            // 
            this.lci_Edit_TotalFileSize.Control = this.Edit_TotalFileSize;
            this.lci_Edit_TotalFileSize.CustomizationFormText = "Общий размер файлов:";
            this.lci_Edit_TotalFileSize.Location = new System.Drawing.Point(482, 356);
            this.lci_Edit_TotalFileSize.MaxSize = new System.Drawing.Size(247, 24);
            this.lci_Edit_TotalFileSize.MinSize = new System.Drawing.Size(247, 24);
            this.lci_Edit_TotalFileSize.Name = "lci_Edit_TotalFileSize";
            this.lci_Edit_TotalFileSize.Size = new System.Drawing.Size(247, 26);
            this.lci_Edit_TotalFileSize.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.lci_Edit_TotalFileSize.Text = "Общий размер файлов (Мб):";
            this.lci_Edit_TotalFileSize.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.lci_Edit_TotalFileSize.TextSize = new System.Drawing.Size(143, 13);
            this.lci_Edit_TotalFileSize.TextToControlDistance = 5;
            // 
            // emptySpaceItem3
            // 
            this.emptySpaceItem3.AllowHotTrack = false;
            this.emptySpaceItem3.CustomizationFormText = "emptySpaceItem3";
            this.emptySpaceItem3.Location = new System.Drawing.Point(0, 0);
            this.emptySpaceItem3.Name = "emptySpaceItem3";
            this.emptySpaceItem3.Size = new System.Drawing.Size(56, 16);
            this.emptySpaceItem3.Text = "emptySpaceItem3";
            this.emptySpaceItem3.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem4
            // 
            this.emptySpaceItem4.AllowHotTrack = false;
            this.emptySpaceItem4.CustomizationFormText = "emptySpaceItem4";
            this.emptySpaceItem4.Location = new System.Drawing.Point(56, 0);
            this.emptySpaceItem4.MaxSize = new System.Drawing.Size(10, 0);
            this.emptySpaceItem4.MinSize = new System.Drawing.Size(10, 10);
            this.emptySpaceItem4.Name = "emptySpaceItem4";
            this.emptySpaceItem4.Size = new System.Drawing.Size(10, 40);
            this.emptySpaceItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.emptySpaceItem4.Text = "emptySpaceItem4";
            this.emptySpaceItem4.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem5
            // 
            this.emptySpaceItem5.AllowHotTrack = false;
            this.emptySpaceItem5.CustomizationFormText = "emptySpaceItem5";
            this.emptySpaceItem5.Location = new System.Drawing.Point(128, 356);
            this.emptySpaceItem5.MaxSize = new System.Drawing.Size(10, 0);
            this.emptySpaceItem5.MinSize = new System.Drawing.Size(10, 10);
            this.emptySpaceItem5.Name = "emptySpaceItem5";
            this.emptySpaceItem5.Size = new System.Drawing.Size(10, 26);
            this.emptySpaceItem5.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.emptySpaceItem5.Text = "emptySpaceItem5";
            this.emptySpaceItem5.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem6
            // 
            this.emptySpaceItem6.AllowHotTrack = false;
            this.emptySpaceItem6.CustomizationFormText = "emptySpaceItem6";
            this.emptySpaceItem6.Location = new System.Drawing.Point(266, 356);
            this.emptySpaceItem6.Name = "emptySpaceItem6";
            this.emptySpaceItem6.Size = new System.Drawing.Size(216, 26);
            this.emptySpaceItem6.Text = "emptySpaceItem6";
            this.emptySpaceItem6.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem7
            // 
            this.emptySpaceItem7.AllowHotTrack = false;
            this.emptySpaceItem7.CustomizationFormText = "emptySpaceItem7";
            this.emptySpaceItem7.Location = new System.Drawing.Point(248, 0);
            this.emptySpaceItem7.MaxSize = new System.Drawing.Size(10, 0);
            this.emptySpaceItem7.MinSize = new System.Drawing.Size(10, 10);
            this.emptySpaceItem7.Name = "emptySpaceItem7";
            this.emptySpaceItem7.Size = new System.Drawing.Size(10, 40);
            this.emptySpaceItem7.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.emptySpaceItem7.Text = "emptySpaceItem7";
            this.emptySpaceItem7.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem8
            // 
            this.emptySpaceItem8.AllowHotTrack = false;
            this.emptySpaceItem8.CustomizationFormText = "emptySpaceItem8";
            this.emptySpaceItem8.Location = new System.Drawing.Point(0, 40);
            this.emptySpaceItem8.MaxSize = new System.Drawing.Size(0, 10);
            this.emptySpaceItem8.MinSize = new System.Drawing.Size(10, 10);
            this.emptySpaceItem8.Name = "emptySpaceItem8";
            this.emptySpaceItem8.Size = new System.Drawing.Size(729, 10);
            this.emptySpaceItem8.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.emptySpaceItem8.Text = "emptySpaceItem8";
            this.emptySpaceItem8.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem9
            // 
            this.emptySpaceItem9.AllowHotTrack = false;
            this.emptySpaceItem9.CustomizationFormText = "emptySpaceItem9";
            this.emptySpaceItem9.Location = new System.Drawing.Point(0, 346);
            this.emptySpaceItem9.MaxSize = new System.Drawing.Size(0, 10);
            this.emptySpaceItem9.MinSize = new System.Drawing.Size(10, 10);
            this.emptySpaceItem9.Name = "emptySpaceItem9";
            this.emptySpaceItem9.Size = new System.Drawing.Size(729, 10);
            this.emptySpaceItem9.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.emptySpaceItem9.Text = "emptySpaceItem9";
            this.emptySpaceItem9.TextSize = new System.Drawing.Size(0, 0);
            // 
            // Ing_ControlOfApplicability
            // 
            this.Ing_ControlOfApplicability.CustomizationFormText = "Контроль применяемости";
            this.Ing_ControlOfApplicability.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem3});
            this.Ing_ControlOfApplicability.Location = new System.Drawing.Point(0, 0);
            this.Ing_ControlOfApplicability.Name = "Ing_ControlOfApplicability";
            this.Ing_ControlOfApplicability.Size = new System.Drawing.Size(729, 382);
            this.Ing_ControlOfApplicability.Text = "Контроль применяемости";
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.layoutControl1;
            this.layoutControlItem3.CustomizationFormText = "layoutControlItem3";
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(729, 382);
            this.layoutControlItem3.Text = "layoutControlItem3";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextToControlDistance = 0;
            this.layoutControlItem3.TextVisible = false;
            // 
            // lcg_Devices
            // 
            this.lcg_Devices.CustomizationFormText = "Приборы:";
            this.lcg_Devices.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.lcg_Devices.ExpandButtonLocation = DevExpress.Utils.GroupElementLocation.AfterText;
            this.lcg_Devices.ExpandButtonVisible = true;
            this.lcg_Devices.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem6});
            this.lcg_Devices.Location = new System.Drawing.Point(0, 0);
            this.lcg_Devices.Name = "lcg_Devices";
            this.lcg_Devices.Size = new System.Drawing.Size(725, 65);
            this.lcg_Devices.Text = "Приборы:";
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.CustomizationFormText = "layoutControlItem6";
            this.layoutControlItem6.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(0, 0);
            this.layoutControlItem6.Text = "layoutControlItem6";
            this.layoutControlItem6.TextSize = new System.Drawing.Size(50, 20);
            this.layoutControlItem6.TextToControlDistance = 5;
            // 
            // colName1
            // 
            this.colName1.FieldName = "Name";
            this.colName1.Name = "colName1";
            // 
            // colNeedInherit1
            // 
            this.colNeedInherit1.FieldName = "NeedInherit";
            this.colNeedInherit1.Name = "colNeedInherit1";
            // 
            // colNeedAssign1
            // 
            this.colNeedAssign1.FieldName = "NeedAssign";
            this.colNeedAssign1.Name = "colNeedAssign1";
            // 
            // colInheritance1
            // 
            this.colInheritance1.FieldName = "Inheritance";
            this.colInheritance1.Name = "colInheritance1";
            // 
            // colPropagation1
            // 
            this.colPropagation1.FieldName = "Propagation";
            this.colPropagation1.Name = "colPropagation1";
            // 
            // ArchiveManagerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(751, 601);
            this.Controls.Add(this.Control_Layout);
            this.Controls.Add(this.StatusBar_StateBar);
            this.Controls.Add(this.Control_Ribbon);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ArchiveManagerForm";
            this.Ribbon = this.Control_Ribbon;
            this.StatusBar = this.StatusBar_StateBar;
            this.Text = "Утилита Архивариуса";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.View_CardRightGroups)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Repository_CardRights)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Control_CardRights)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSource_TargetObject)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.View_CardRights)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Control_Ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.View_FolderGroupRights)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Repository_FolderRigths)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Control_FolderRights)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.View_FolderRights)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Edit_IfPattern.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Control_Layout)).EndInit();
            this.Control_Layout.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Control_Errors)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ViewErrors)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcg_Bugs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Control_Matches)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSource_Unrelated)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.View_Matches)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Repository_Matches_Guid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Edit_TotalFileSize.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Control_FoundFiles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSource_FoundFile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.View_FoundFiles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Repository_FileSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Repository_DateEdit.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Repository_DateEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Edit_DVFolder.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Edit_FileSize.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Edit_Action.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Control_Objects)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.View_Objects)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Repository_Guid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Edit_FindPattern.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Edit_ReplacePattern.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Edit_NewPath.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Edit_OldPath.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Edit_CardId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Control_Tabs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcg_AssignRights)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Control_Matrix)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcg_FolderRirhtsMatrix)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lci_Control_FolderRights)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcg_CardRightsMatrix)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lci_Control_CardRights)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcg_PathCorrection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcg_PathCorrection_Cards)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lci_Edit_IfPattern)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lci_Edit_FindPattern)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lci_Edit_ReplacePattern)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lci_Button_Replace)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcg_PathCorrection_Card)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lci_Edit_CardId)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lci_Edit_OldPath)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lci_Edit_NewPath)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcg_ArchiveAnalyzing)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcg_UnrelatedObjects)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lci_Control_UnrelatedDirs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcg_Matches)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lci_Control_Matches)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitterItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcg_UploadFilesToServer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lci_Action)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lci_Edit_FileSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lci_Edit_DVFolder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lci_Control_FoundFiles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lci_Button_SelectAll)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lci_Button_UnselectAll)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lci_Edit_TotalFileSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ing_ControlOfApplicability)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcg_Devices)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        
        private DevExpress.XtraGrid.GridControl Control_Objects;
        private DevExpress.XtraGrid.Views.Grid.GridView View_Objects;
        private DevExpress.XtraBars.BarStaticItem Item_CurrentState;
        private DevExpress.LookAndFeel.DefaultLookAndFeel Control_DefaultLAF;
        private DevExpress.XtraBars.BarSubItem Item_Theme;
        private DevExpress.XtraEditors.TextEdit Edit_ReplacePattern;
        private DevExpress.XtraEditors.TextEdit Edit_FindPattern;
        private DevExpress.XtraEditors.ButtonEdit Edit_NewPath;
        private System.Windows.Forms.FolderBrowserDialog Dialog_Folder;
        private DevExpress.XtraEditors.TextEdit Edit_IfPattern;
        private DevExpress.XtraBars.Ribbon.RibbonControl Control_Ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar StatusBar_StateBar;
        private DevExpress.XtraBars.Ribbon.RibbonPage Page_AssignRights;
        private DevExpress.XtraLayout.LayoutControl Control_Layout;
        private DevExpress.XtraLayout.LayoutControlGroup lcg;
        private DevExpress.XtraLayout.TabbedControlGroup Control_Tabs;
        private DevExpress.XtraLayout.LayoutControlGroup lcg_AssignRights;
        private DevExpress.XtraLayout.LayoutControlGroup lcg_ArchiveAnalyzing;
        private DevExpress.XtraLayout.LayoutControlItem lci_Control_UnrelatedDirs;
        private DevExpress.XtraBars.Ribbon.RibbonPage Page_Correction;
        private DevExpress.XtraBars.Ribbon.RibbonPage Page_ArchiveAnalyzing;
        private DevExpress.XtraBars.BarButtonItem Item_CheckGroups;
        private DevExpress.XtraBars.BarButtonItem Item_SetRightsToFolders;
        private DevExpress.XtraBars.BarButtonItem Item_SetRightsToCards;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup PageGroup_AssignRights;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup PageGroup_ArchiveSearch;
        private DevExpress.XtraEditors.ButtonEdit Edit_OldPath;
        private DevExpress.XtraBars.BarButtonItem Item_Find;
        private DevExpress.XtraBars.BarButtonItem Item_UploadFiles;
        private DevExpress.XtraBars.Ribbon.RibbonPage Page_UploadFilesToServer;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup PageGroup_UploadFilesToServer;
        private DevExpress.XtraLayout.LayoutControlGroup lcg_UploadFilesToServer;
        private DevExpress.XtraEditors.SpinEdit Edit_TotalFileSize;
        private DevExpress.XtraEditors.SimpleButton Button_UnselectAll;
        private DevExpress.XtraEditors.SimpleButton Button_SelectAll;
        private DevExpress.XtraGrid.GridControl Control_FoundFiles;
        private DevExpress.XtraGrid.Views.Grid.GridView View_FoundFiles;
        private DevExpress.XtraEditors.ButtonEdit Edit_DVFolder;
        private DevExpress.XtraEditors.SpinEdit Edit_FileSize;
        private DevExpress.XtraEditors.ComboBoxEdit Edit_Action;
        private DevExpress.XtraLayout.LayoutControlItem lci_Action;
        private DevExpress.XtraLayout.LayoutControlItem lci_Edit_FileSize;
        private DevExpress.XtraLayout.LayoutControlItem lci_Edit_DVFolder;
        private DevExpress.XtraLayout.LayoutControlItem lci_Control_FoundFiles;
        private DevExpress.XtraLayout.LayoutControlItem lci_Button_SelectAll;
        private DevExpress.XtraLayout.LayoutControlItem lci_Button_UnselectAll;
        private DevExpress.XtraLayout.LayoutControlItem lci_Edit_TotalFileSize;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem3;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem4;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem5;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem6;
        private DevExpress.XtraLayout.LayoutControlGroup lcg_PathCorrection;
        private DevExpress.XtraLayout.LayoutControlGroup lcg_PathCorrection_Cards;
        private DevExpress.XtraLayout.LayoutControlItem lci_Edit_IfPattern;
        private DevExpress.XtraLayout.LayoutControlItem lci_Edit_FindPattern;
        private DevExpress.XtraLayout.LayoutControlItem lci_Edit_ReplacePattern;
        private DevExpress.XtraLayout.LayoutControlGroup lcg_PathCorrection_Card;
        private DevExpress.XtraLayout.LayoutControlItem lci_Edit_CardId;
        private DevExpress.XtraLayout.LayoutControlItem lci_Edit_OldPath;
        private DevExpress.XtraLayout.LayoutControlItem lci_Edit_NewPath;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem7;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem8;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem9;
        private DevExpress.XtraGrid.Columns.GridColumn Column_Selected_File;
        private DevExpress.XtraGrid.Columns.GridColumn Column_Name_File;
        private DevExpress.XtraGrid.Columns.GridColumn Column_Size_File;
        private DevExpress.XtraGrid.Columns.GridColumn Column_Category_File;
        private DevExpress.XtraGrid.Columns.GridColumn Column_Registrar_File;
        private DevExpress.XtraGrid.Columns.GridColumn Column_CreationDate_File;
        private System.Windows.Forms.BindingSource BindingSource_FoundFile;
        private DevExpress.XtraEditors.ButtonEdit Edit_CardId;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit Repository_FileSize;
        private DevExpress.XtraBars.BarButtonItem Item_SetNoUnreadCards;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup PageGroup_Categories;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit Repository_DateEdit;
        private DevExpress.XtraEditors.SimpleButton Button_Replace;
        private DevExpress.XtraEditors.SimpleButton Button_SavePath;
        private DevExpress.XtraEditors.SimpleButton Button_CheckPath;
        private DevExpress.XtraLayout.LayoutControlItem lci_Button_Replace;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem12;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem10;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem11;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraBars.BarButtonItem Item_FindUnrelatedCards;
        private DevExpress.XtraBars.BarButtonItem Item_FindUnrelatedFolders;
        private DevExpress.XtraBars.BarButtonItem Item_FindMatchByIN;
        private DevExpress.XtraGrid.GridControl Control_Matches;
        private DevExpress.XtraGrid.Views.Grid.GridView View_Matches;
        private DevExpress.XtraLayout.LayoutControlGroup lcg_UnrelatedObjects;
        private DevExpress.XtraLayout.LayoutControlItem lci_Control_Matches;
        private DevExpress.XtraLayout.LayoutControlGroup lcg_Matches;
        private DevExpress.XtraLayout.SplitterItem splitterItem1;
        private DevExpress.XtraGrid.Columns.GridColumn Column_Selected_Object;
        private DevExpress.XtraGrid.Columns.GridColumn Column_DocType_Object;
        private DevExpress.XtraGrid.Columns.GridColumn Column_DocName_Object;
        private DevExpress.XtraGrid.Columns.GridColumn Column_Folder_Object;
        private DevExpress.XtraGrid.Columns.GridColumn Column_CardId_Object;
        private DevExpress.XtraGrid.Columns.GridColumn Column_Selected_Match;
        private DevExpress.XtraGrid.Columns.GridColumn Column_DocType_Match;
        private DevExpress.XtraGrid.Columns.GridColumn Column_DocName_Match;
        private DevExpress.XtraGrid.Columns.GridColumn Column_Folder_Match;
        private DevExpress.XtraGrid.Columns.GridColumn Column_CardId_Match;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit Repository_Matches_Guid;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit Repository_Guid;
        private System.Windows.Forms.BindingSource BindingSource_Unrelated;
        private DevExpress.XtraGrid.Columns.GridColumn Сolumn_Category_Match;
        private DevExpress.XtraGrid.Columns.GridColumn Column_Category_Object;
        private DevExpress.XtraGrid.GridControl Control_CardRights;
        private DevExpress.XtraGrid.Views.Grid.GridView View_CardRightGroups;
        private DevExpress.XtraGrid.Columns.GridColumn Column_Name_CardGroup;
        private DevExpress.XtraGrid.Views.Grid.GridView View_CardRights;
        private DevExpress.XtraGrid.Columns.GridColumn Column_Name_Card;
        private DevExpress.XtraGrid.Columns.GridColumn Column_NeedInherit_Card;
        private DevExpress.XtraGrid.Columns.GridColumn Column_NeedAssign_Card;
        private DevExpress.XtraLayout.TabbedControlGroup Control_Matrix;
        private DevExpress.XtraLayout.LayoutControlGroup lcg_CardRightsMatrix;
        private DevExpress.XtraLayout.LayoutControlItem lci_Control_CardRights;
        private DevExpress.XtraGrid.Columns.GridColumn colName1;
        private DevExpress.XtraGrid.Columns.GridColumn colNeedInherit1;
        private DevExpress.XtraGrid.Columns.GridColumn colNeedAssign1;
        private DevExpress.XtraGrid.Columns.GridColumn colInheritance1;
        private DevExpress.XtraGrid.Columns.GridColumn colPropagation1;
        private DevExpress.XtraGrid.Columns.GridColumn Column_Rights_CardGroup;
        private System.Windows.Forms.BindingSource BindingSource_TargetObject;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckedComboBoxEdit Repository_CardRights;
        private DevExpress.XtraBars.BarButtonItem Item_SetWDCategory;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup PageGroup_ArchiveFix;
        private DevExpress.XtraBars.BarButtonItem Item_CheckAll;
        private DevExpress.XtraBars.BarButtonItem Item_UncheckAll;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup PageGroup_EditMatrix;
        private DevExpress.XtraBars.BarButtonItem Item_ShowDetails;
        private DevExpress.XtraBars.BarButtonItem Item_HideDetails;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup PageGroup_Expand;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup PageGroup_Matrix;
        private DevExpress.XtraGrid.GridControl Control_FolderRights;
        private DevExpress.XtraGrid.Views.Grid.GridView View_FolderGroupRights;
        private DevExpress.XtraGrid.Columns.GridColumn Column_Name_FolderGroup;
        private DevExpress.XtraGrid.Columns.GridColumn Column_Rights_FolderGroup;
        private DevExpress.XtraGrid.Views.Grid.GridView View_FolderRights;
        private DevExpress.XtraGrid.Columns.GridColumn Column_Name_Folder;
        private DevExpress.XtraGrid.Columns.GridColumn Column_NeedInherit_Folder;
        private DevExpress.XtraGrid.Columns.GridColumn Column_NeedAssign_Folder;
        private DevExpress.XtraLayout.LayoutControlGroup lcg_FolderRirhtsMatrix;
        private DevExpress.XtraLayout.LayoutControlItem lci_Control_FolderRights;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckedComboBoxEdit Repository_FolderRigths;
        private DevExpress.XtraBars.BarButtonItem Item_SaveMatrix;
        private DevExpress.XtraBars.BarButtonItem Item_ReloadMatrix;
        private DevExpress.XtraBars.BarButtonItem Item_CheckApplicability;
        private DevExpress.XtraBars.Ribbon.RibbonPage Page_ControlOfApplicability;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup PageGroup_ControlOfApplicability;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraGrid.GridControl Control_Errors;
        private DevExpress.XtraGrid.Views.Grid.GridView ViewErrors;
        private DevExpress.XtraLayout.LayoutControlGroup lcg_Bugs;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlGroup Ing_ControlOfApplicability;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraGrid.Columns.GridColumn Column_Device;
        private DevExpress.XtraGrid.Columns.GridColumn Column_Document_Id;
        private DevExpress.XtraGrid.Columns.GridColumn Column_Document_Description;
        private DevExpress.XtraGrid.Columns.GridColumn Column_Applicability;
        private DevExpress.XtraGrid.Columns.GridColumn Column_Error_Text;
        private DevExpress.XtraLayout.LayoutControlGroup lcg_Devices;
        //private RKIT.MyCollectionControl.Design.Control.CollectionControlView Edit_Device;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraBars.BarButtonItem Item_CreateHierarchyOfApplicability;
    }
}