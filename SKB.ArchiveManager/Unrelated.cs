using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SKB.ArchiveManager
{
    /// <summary>
    /// Отвязанная папка/карточка.
    /// </summary>
    public class Unrelated
    {
        /// <summary>
        /// Метка.
        /// </summary>
        public Boolean Selected { get; set; }
        /// <summary>
        /// Тип документа.
        /// </summary>
        public String DocType { get; private set; }
        /// <summary>
        /// Название документа.
        /// </summary>
        public String DocName { get; private set; }
        /// <summary>
        /// Категория.
        /// </summary>
        public String Category { get; private set; }
        /// <summary>
        /// Папка.
        /// </summary>
        public String Folder { get; private set; }
        /// <summary>
        /// Идентификатор карточки.
        /// </summary>
        public Guid? CardId { get; private set; }
        /// <summary>
        /// Инициализирует пустую папку/карточку.
        /// </summary>
        public Unrelated ()
            : this(String.Empty, String.Empty, String.Empty, null, null) { }
        /// <summary>
        /// Инициализирует отвязанную папку.
        /// </summary>
        public Unrelated (String Folder)
            : this(String.Empty, String.Empty, String.Empty, Folder, null) { }
        /// <summary>
        /// Инициализирует папку/карточку заданными значениями.
        /// </summary>
        /// <param name="DocType">Тип документа.</param>
        /// <param name="DocName">Название документа.</param>
        /// <param name="Folder">Папка.</param>
        /// <param name="CardId">Идентификатор карточки.</param>
        public Unrelated (String DocType, String DocName, String Category, String Folder, Guid? CardId)
        {
            this.Selected = false;
            this.DocType = DocType;
            this.DocName = DocName;
            this.Category = Category;
            this.Folder = Folder;
            this.CardId = CardId;
        }
    }
}