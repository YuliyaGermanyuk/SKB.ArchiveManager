using DocsVision.Platform.ObjectManager;
using DocsVision.Platform.ObjectModel;
using SKB.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CardFile = DocsVision.TakeOffice.Cards.Constants.CardFile;

namespace SKB.ArchiveManager
{
    /// <summary>
    /// Строка таблицы "Найденные файлы".
    /// </summary>
    public class FoundFile
    {
        /// <summary>
        /// Идентфикатор карточки файла.
        /// </summary>
        public Guid FileCardId { get; private set; }
        /// <summary>
        /// Метка о выделении.
        /// </summary>
        public Boolean Selected { get; set; }
        /// <summary>
        /// Название файла.
        /// </summary>
        public String Name { get; private set; }
        /// <summary>
        /// Размер (Мб) файла.
        /// </summary>
        public Decimal Size { get; private set; }
        /// <summary>
        /// Категория.
        /// </summary>
        public String Category { get; private set; }
        /// <summary>
        /// Регистратор.
        /// </summary>
        public String Registrar { get; private set; }
        /// <summary>
        /// Регистратор.
        /// </summary>
        public Guid RegistrarId { get; private set; }
        /// <summary>
        /// Дата создания файла.
        /// </summary>
        public DateTime CreationDate { get; private set; }
        /// <summary>
        /// Идентификатор карточки Файлы Маркетинга.
        /// </summary>
        public Guid MarketingFileId { get; set; }
        /// <summary>
        /// Инициализирует строку по указанным данным.
        /// </summary>
        /// <param name="Context">Объектный контекст.</param>
        /// <param name="FileCard">Данные карточки файла.</param>
        /// <param name="Selected">Выделена ли строка.</param>
        public FoundFile (ObjectContext Context, CardData FileCard, Boolean Selected = false)
        {
            this.FileCardId = FileCard.Id;
            this.Selected = Selected;
            this.MarketingFileId = Guid.Empty;

            Initalize(Context, FileCard);            
        }
        /// <summary>
        /// Обновляет значения строки из карточки файла.
        /// </summary>
        /// <param name="Context">Объектный контекст.</param>
        public void Refresh (ObjectContext Context)
        {
            UserSession Session = Context.GetService<UserSession>();
            if (Session.CardManager.GetCardState(FileCardId) == DocsVision.Platform.ObjectManager.ObjectState.Existing)
                Initalize(Context, Session.CardManager.GetCardData(FileCardId));
        }
        /// <summary>
        /// Инициализирует строку по данным карточки файла.
        /// </summary>
        /// <param name="Context">Объектный контекст.</param>
        /// <param name="FileCard">Данные карточки файла.</param>
        private void Initalize (ObjectContext Context, CardData FileCard)
        {
            RowData FileCardMainInfoRow = FileCard.Sections[CardFile.MainInfo.ID].FirstRow;
            List<RowData> FileCardCategories = FileCard.Sections[CardFile.Categories.ID].Rows.Where(row => !row.GetObject(CardFile.Categories.CategoryID).ToGuid().IsEmpty()).ToList();
            Guid AuthorId = FileCardMainInfoRow.GetGuid(CardFile.MainInfo.Author) ?? Guid.Empty;

            this.Name = FileCardMainInfoRow.GetString(CardFile.MainInfo.FileName);
            this.Size = (Decimal)FileCardMainInfoRow.GetInt32(CardFile.MainInfo.FileSize) / (Decimal)1024;
            this.Category = FileCardCategories.Any() ? FileCardCategories.Select(row => row.GetString("Name")).Aggregate((a, b) => a + ";" + b) : String.Empty;
            this.Registrar = AuthorId.IsEmpty() ? String.Empty : Context.GetEmployeeDisplay(AuthorId);
            this.RegistrarId = AuthorId;
            this.CreationDate = FileCard.CreateDate;
        }
    }
}