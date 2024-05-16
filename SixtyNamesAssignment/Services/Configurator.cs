using Microsoft.Extensions.Configuration;

namespace SixtyNamesAssignment.Services
{
    /// <summary>
    /// Содержит конфигурационный функционал.
    /// </summary>
    public static class Configurator
    {
        /// <summary>
        /// Инициализирует конфигурацию.
        /// </summary>
        private static IConfigurationBuilder builder = new ConfigurationBuilder().AddJsonFile("appsettings.json", false, true);
        private static IConfigurationRoot root = builder.Build();

        /// <summary>
        /// Возвращает строку подключения.
        /// </summary>
        /// <param name="sectionName">Название секции с необходимой строкой подключения.</param>
        /// <returns>Строка подключения.</returns>
        public static string GetConnectionString(string sectionName)
        {

            return root.GetConnectionString(sectionName);
        }
    }
}
