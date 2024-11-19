using PeriodCalculator.Logic;
using PeriodCalculator.Models;

namespace PeriodCalculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 1)
            {
                Console.WriteLine("Не указан путь к файлу с периодами");
                return;
            }

            try
            {
                string path = args[0];
                var periods = Parser.ParsePeriods(path);
                int activeHours = Calculator.CalculateActiveHours(periods);
                Console.WriteLine($"Количество активных часов: {activeHours}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
