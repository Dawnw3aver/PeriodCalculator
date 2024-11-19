using PeriodCalculator.Models;

namespace PeriodCalculator.Logic
{
    internal class Calculator
    {
        /// <summary>
        /// Вычисляет количество активных часов из коллекции периодов
        /// </summary>
        /// <param name="periods">Коллекция периодов</param>
        /// <returns></returns>
        internal static int CalculateActiveHours(List<Period> periods)
        {
            var activeHours = new HashSet<(DateTime Date, int Hour)>();

            foreach (var period in periods)
            {
                //создаем множество дат от начала до конца одного периода
                var activeDates = Enumerable.Range(0, (period.EndDate - period.StartDate).Days + 1)
                    .Select(offset => period.StartDate.AddDays(offset))
                    .Where(date => period.DaysOfWeek.Contains(date.DayOfWeek));

                //добавляем в сет активные часы по каждой дате
                foreach (var date in activeDates)
                {
                    for (int hour = period.StartHour; hour < period.EndHour; hour++)
                    {
                        activeHours.Add((date, hour));
                    }
                }
            }

            return activeHours.Count;
        }
    }
}
