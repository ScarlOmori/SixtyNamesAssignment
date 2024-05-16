using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SixtyNamesAssignment.Models
{
    /// <summary>
    /// Юридическое лицо.
    /// </summary>
    [Table("LegalPerson")]
    public class LegalPerson
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Наименование компании.
        /// </summary>
        public string CompanyName { get; set; }

        /// <summary>
        /// ИНН.
        /// </summary>
        public int INN { get; set; }

        /// <summary>
        /// ОГРН.
        /// </summary>
        public int OGRN { get; set; }

        /// <summary>
        /// Страна.
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// Город.
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Адрес.
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Электронная почта.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Номер телефона.
        /// </summary>
        public string Phone { get; set; }
    }
}
