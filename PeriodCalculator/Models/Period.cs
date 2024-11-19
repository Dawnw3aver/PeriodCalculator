namespace PeriodCalculator.Models
{
    /// <summary>
    /// Объектная модель периода
    /// </summary>
    public class Period
    {
        public HashSet<DayOfWeek> DaysOfWeek { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public int StartHour { get; private set; }
        public int EndHour { get; private set; }

        private Period(HashSet<DayOfWeek> daysOfWeek, DateTime startDate, DateTime endDate, int startHour, int endHour)
        {
            DaysOfWeek = daysOfWeek;
            StartDate = startDate;
            EndDate = endDate;
            StartHour = startHour;
            EndHour = endHour;
        }
        public static (Period value, string error) Create(HashSet<DayOfWeek> daysOfWeek, DateTime startDate, DateTime endDate, int startHour, int endHour)
        {
            string error = string.Empty;
            if (daysOfWeek == null || daysOfWeek.Count == 0)
                error += "Должен быть указан хотя бы один день недели.";

            if (startDate > endDate)
                error += "Дата начала не может быть позже даты окончания.";

            if (startHour < 0 || startHour > 23)
                error += "Час начала должен быть в диапазоне от 0 до 23.";

            if (endHour <= startHour || endHour > 24)
                error +=  "Час окончания должен быть больше часа начала и не превышать 24.";

            Period period = new Period(daysOfWeek, startDate, endDate, startHour, endHour);
            return (period, error);
        }
    }
}
