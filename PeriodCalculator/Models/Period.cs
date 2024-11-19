namespace PeriodCalculator.Models
{
    public class Period
    {
        public HashSet<DayOfWeek> DaysOfWeek { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int StartHour { get; set; }
        public int EndHour { get; set; }
    }
}
