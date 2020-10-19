using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKB.ArchiveManager
{
    /// <summary>
    /// Ошибка применяемости документа.
    /// </summary>
    class ApplicableError
    {
        /// <summary>
        /// Прибор.
        /// </summary>
        public string Device { get; set; }
        /// <summary>
        /// ID документа.
        /// </summary>
        public string DocumentId { get; private set; }
        /// <summary>
        /// Название документа.
        /// </summary>
        public string DocumentName { get; set; }
        /// <summary>
        /// Применяемость документа.
        /// </summary>
        public string Applicability { get; set; }
        /// <summary>
        /// Текст ошибки.
        /// </summary>
        public string TextError { get; set; }
        /// <summary>
        /// Инициализирует ошибку заданными значениями.
        /// </summary>
        /// <param name="Device">Прибор.</param>
        /// <param name="DocumentId">ID документа.</param>
        /// <param name="DocumentName">Название документа.</param>
        /// <param name="Applicability">Применяемость.</param>
        /// <param name="TextError">Текст ошибки.</param>
        public ApplicableError(string Device, string DocumentId, string DocumentName, string Applicability, string TextError)
        {
            this.Device = Device;
            this.DocumentId = DocumentId;
            this.DocumentName = DocumentName;
            this.Applicability = Applicability;
            this.TextError = TextError;
        }
    }
}