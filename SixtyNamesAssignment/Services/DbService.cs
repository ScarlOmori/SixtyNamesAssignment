using Dapper;
using Microsoft.Data.SqlClient;
using SixtyNamesAssignment.Models;
using System.Data;

namespace SixtyNamesAssignment.Services
{
    /// <summary>
    /// Вмещает функциональность для работы с данными базы данных.
    /// </summary>
    public static class DbService
    {
        /// <summary>
        /// Строка подключения к базе данных.
        /// </summary>
        private static string ConnectionString { get; set; } = Configurator.GetConnectionString("Default");

        /// <summary>
        /// Выводит сумму всех заключенных договоров за текущий год.
        /// </summary>
        public static void GetThisYearAgreementSum()
        {
            using IDbConnection connection =
                new SqlConnection(ConnectionString);

            var res = connection.ExecuteScalar(@"
                SELECT SUM(Sum)
                FROM Agreement WHERE YEAR(SigningDate) = YEAR(CURRENT_TIMESTAMP);");

            Console.WriteLine(res);
        }

        /// <summary>
        /// Выводит сумму заключенных договоров по каждому контрагенту из России.
        /// </summary>
        public static void GetAgreementSumOfEveryRussianLegalPerson()
        {
            using IDbConnection connection =
                new SqlConnection(ConnectionString);

            var query = @"
                SELECT LegalPersonId, SUM(Sum) AS TotalSum
                FROM Agreement
                JOIN LegalPerson ON Agreement.LegalPersonId = LegalPerson.Id
                WHERE LegalPerson.Country = 'Russia'
                GROUP BY LegalPersonId";

            var result = connection.Query<AgreementSummary>(query).ToList();

            foreach (var summary in result)
            {
                Console.WriteLine($"Контрагент №{summary.LegalPersonId} имеет договоры в этом году на сумму - {summary.TotalSum}");
            }
        }

        /// <summary>
        /// Выводит список электронных почт уполномоченных лиц, заключивших договора за последние 30 дней, на сумму больше 40000.
        /// </summary>
        public static void GetIndividualPersonsEmail()
        {
            using IDbConnection connection =
                new SqlConnection(ConnectionString);

            var query = @"
                SELECT IndividualPerson.Email
                FROM Agreement
                JOIN IndividualPerson ON Agreement.IndividualPersonId = IndividualPerson.Id
                WHERE SigningDate >= dateadd(day, -30, getdate())
                AND Sum > 40000;";

            var result = connection.Query<string>(query);

            Console.WriteLine("Emails:");

            foreach (var email in result)
            {
                Console.WriteLine(email);
            }
        }

        /// <summary>
        /// Изменяет статус договора на "Terminated" для физических лиц, у которых есть действующий договор, и возраст которых старше 60 лет включительно.
        /// </summary>
        public static void SetAgreementToTerminated()
        {
            using IDbConnection connection =
                new SqlConnection(ConnectionString);

            var query = @"
            UPDATE Agreement
            SET Status = 'Terminated'
            WHERE IndividualPersonId IN (
                SELECT IndividualPersonId
                FROM Agreement
                JOIN IndividualPerson ON Agreement.IndividualPersonId = IndividualPerson.Id
                WHERE Status = 'Active' AND DATEDIFF(YEAR, IndividualPerson.Birthday, CURRENT_TIMESTAMP) >= 60
            )";

            var result = connection.Execute(query);

            Console.WriteLine($"{result} rows affected");
        }

        /// <summary>
        /// Создает отчет в формате JSON содержащий ФИО, e-mail, моб. телефон, дату рождения физ. лиц, у которых есть действующие договора по компаниям, расположенных в городе Москва.
        /// </summary>
        public static void MakeReport()
        {
            using IDbConnection connection =
                new SqlConnection(ConnectionString);

            var sql = @"
			SELECT IndividualPerson.FirstName, IndividualPerson.LastName, IndividualPerson.MiddleName, IndividualPerson.Email, IndividualPerson.Phone, IndividualPerson.Birthday
			FROM Agreement
			JOIN IndividualPerson ON Agreement.IndividualPersonId = IndividualPerson.Id
			JOIN LegalPerson ON Agreement.LegalPersonId = LegalPerson.Id
			WHERE Agreement.Status = 'Active' AND LegalPerson.City = 'Moscow'";

            var result = connection.Query<ReportModel>(sql);

            JsonReportMaker.MakeReport(result);
        }
    }
}
