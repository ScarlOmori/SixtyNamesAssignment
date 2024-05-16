namespace SixtyNamesAssignment.Models
{
    /// <summary>
    /// Модель данных для запроса суммы договоров по каждому Российскому контрагенту.
    /// </summary>
    public class AgreementSummary
    {
        /// <summary>
        /// Идентификатор контрагента.
        /// </summary>
        public int LegalPersonId { get; set; }

        /// <summary>
        /// Сумма договоров.
        /// </summary>
        public decimal TotalSum { get; set; }
    }
}
