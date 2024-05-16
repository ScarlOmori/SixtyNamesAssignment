using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SixtyNamesAssignment.Models
{
    /// <summary>
    /// Модель договора.
    /// </summary>
    [Table("Agreement")]
    public class Agreement
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Идентификатор юридического лица.
        /// </summary>
        public int LegalPersonId { get; set; }

        /// <summary>
        /// Идентификатор физического лица.
        /// </summary>
        public int IndividualPersonId { get; set; }

        /// <summary>
        /// Сумма договора.
        /// </summary>
        public int Sum { get; set; }

        /// <summary>
        /// Статус договора.
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Дата подписания.
        /// </summary>
        public DateTime SigningDate { get; set; }
    }
}
