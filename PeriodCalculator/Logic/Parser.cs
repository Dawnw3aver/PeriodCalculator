using PeriodCalculator.Models;
using System.Globalization;

namespace PeriodCalculator.Logic
{
    internal class Parser
    {
        const int startDateOffset = 2;
        const int endDateOffset = 3;
        const int startHourOffset = 4;
        const int endHourOffset = 5;

        /// <summary>
        /// Парсит периоды из файла
        /// </summary>
        /// <param name="filePath">Путь к файлу с периодами</param>
        /// <returns></returns>
        /// <exception cref="FileNotFoundException"></exception>
        internal static List<Period> ParsePeriods(string filePath)
        {
            if (!File.Exists(filePath))
                throw new FileNotFoundException("Файл не найден");

            var lines = File.ReadAllLines(filePath);
            int numberOfPeriods = int.Parse(lines[0]);
            var periods = new List<Period>();

            for (int i = 0; i < numberOfPeriods; i++)
            {
                int baseIndex = i * 5;   //индекс, по которому отделяем один период от другого
                var daysOfWeek = new HashSet<DayOfWeek>(
                    lines[baseIndex + 1].Split(',')
                        .Select(day => (DayOfWeek)Enum.Parse(typeof(DayOfWeek), day, true))
                );
                var startDate = DateTime.ParseExact(lines[baseIndex + startDateOffset], "dd.MM.yyyy", CultureInfo.InvariantCulture);
                var endDate = DateTime.ParseExact(lines[baseIndex + endDateOffset], "dd.MM.yyyy", CultureInfo.InvariantCulture);
                int startHour = int.Parse(lines[baseIndex + startHourOffset]);
                int endHour = int.Parse(lines[baseIndex + endHourOffset]);

                var period = Period.Create(daysOfWeek, startDate, endDate, startHour, endHour);
                if (!string.IsNullOrEmpty(period.error))
                    throw new InvalidOperationException(period.error);

                periods.Add(period.value);
            }

            return periods;
        }
    }
}
