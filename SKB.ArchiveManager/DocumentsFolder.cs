using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocsVision.Platform.ObjectManager;
using DocsVision.Platform.ObjectManager.SystemCards;
using DocsVision.Platform.ObjectManager.SearchModel;
using DocsVision.Platform.ObjectManager.Metadata;
using DocsVision.Platform.Cards.Constants;
using DocsVision.TakeOffice.Cards.Constants;
using SKB.Base.Ref.Properties;
using SKB.Base;

namespace SKB.ArchiveManager
{
    /// <summary>
    /// Папка дерева применяемости.
    /// </summary>
    class DocumentsFolder
    {
        /// <summary>
        /// ID кода СКБ.
        /// </summary>
        public Guid CodeID { get; private set; }
        /// <summary>
        /// Отображаемое значение кода СКБ.
        /// </summary>
        public string CodeName { get; set; }
        /// <summary>
        /// ID документа.
        /// </summary>
        public Guid DocumentID { get; set; }
        /// <summary>
        /// Карточка документа.
        /// </summary>
        public CardData Document { get; set; }
        /// <summary>
        /// Название документа.
        /// </summary>
        public string DocumentName { get; set; }
        /// <summary>
        /// Тип документа.
        /// </summary>
        public string DocumentType { get; set; }
        /// <summary>
        /// Применяемость.
        /// </summary>
        public string Applicability { get; set; }
        /// <summary>
        /// Папка.
        /// </summary>
        public Folder Folder { get; set; }
        /// <summary>
        /// ID родительской папки.
        /// </summary>
        public Folder ParentFolder { get; set; }
        /// <summary>
        /// Инициализирует папку заданными значениями.
        /// </summary>
        /// <param name="Device">Прибор.</param>
        /// <param name="CodeID">ID кода СКБ.</param>
        /// <param name="CodeName">Отобразаемое значение кода СКБ.</param>
        /// <param name="DocumentID">ID документа.</param>
        /// <param name="DocumentName">Название документа.</param>
        /// <param name="FolderID">ID папки.</param>
        public DocumentsFolder(Folder ParentFolder, CardData Document, SavedSearchGroup SearchGroup, SavedView View, FolderCard FolderCard)
        {
            this.ParentFolder = ParentFolder;
            this.Document       = Document;
            DocumentID = Document.Id;

            SectionData Properties = Document.Sections[CardOrd.Properties.ID];
            DocumentType = Properties.FindRow("@Name = '" + RefPropertiesCD.Requisities.FileType + "'").GetString("Value");
            RowData Code = Properties.FindRow("@Name = '" + RefPropertiesCD.Requisities.Code + "'");
            CodeID = Code.GetGuid("Value").Value;
            CodeName = Code.GetString("DisplayValue");
            RowData Applicable = Properties.FindRow("@Name = '" + RefPropertiesCD.Requisities.Applicable + "'");
            Applicability = Applicable.GetString("DisplayValue");
            RowData Name = Properties.FindRow("@Name = '" + RefPropertiesCD.Requisities.DocumentName + "'");

            string ShortType = DocumentType == "СД - Спецификация (не платы)" || DocumentType == "СП - Спецификация платы" ? "" : DocumentType.Remove(DocumentType.IndexOf(" - "));
            DocumentName = CodeName + " " + ShortType + " " + Name.GetString("Value");
            
            Folder = FolderCard.CreateFolder(ParentFolder.Id, DocumentName);
            Folder.Type = FolderTypes.Virtual;

            if (!SearchGroup.Queries.Any(row => row.Name == DocumentName))
            {
                SearchQuery Query = FolderCard.Session.CreateSearchQuery();
                CardTypeQuery CardType = Query.AttributiveSearch.CardTypeQueries.AddNew(CardOrd.ID);
                SectionQuery Section = CardType.SectionQueries.AddNew(CardOrd.MainInfo.ID);
                Section.Operation = SectionQueryOperation.And;
                Section.ConditionGroup.Operation = ConditionGroupOperation.And;
                Section.ConditionGroup.Conditions.AddNew(CardOrd.MainInfo.Type, FieldType.RefId, ConditionOperation.Equals, MyHelper.RefType_CD);

                Section = CardType.SectionQueries.AddNew(CardOrd.Properties.ID);
                Section.Operation = SectionQueryOperation.And;
                Section.ConditionGroup.Operation = ConditionGroupOperation.And;
                Section.ConditionGroup.Conditions.AddNew(CardOrd.Properties.Value, FieldType.Unistring, ConditionOperation.Equals, DocumentType);
                Section.ConditionGroup.Conditions.AddNew(CardOrd.Properties.Name, FieldType.Unistring, ConditionOperation.Equals, RefPropertiesCD.Requisities.FileType);

                Section = CardType.SectionQueries.AddNew(CardOrd.Properties.ID);
                Section.Operation = SectionQueryOperation.And;
                Section.ConditionGroup.Operation = ConditionGroupOperation.And;
                Section.ConditionGroup.Conditions.AddNew(CardOrd.Properties.Value, FieldType.RefId, ConditionOperation.Equals, CodeID);
                Section.ConditionGroup.Conditions.AddNew(CardOrd.Properties.Name, FieldType.Unistring, ConditionOperation.Equals, RefPropertiesCD.Requisities.Code);
                Query.Limit = 0;
                SearchGroup.Queries.AddNew(DocumentName).Import(Query);
            }
            SavedSearchQuery SavedQuery = SearchGroup.Queries.First(row => row.Name == DocumentName);
            Folder.RefId = SavedQuery.Id;
            
            Folder.CurrentViewId = View.Id;
            Folder.DefaultViewId = View.Id;
        }
    }
}