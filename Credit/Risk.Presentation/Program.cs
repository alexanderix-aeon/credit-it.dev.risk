using Risk.Integrations;
using Risk.Persistence;
using Risk.Business;
using System.Globalization;

namespace Risk.Presentation
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("************************************");
            Console.WriteLine("*    Credit Suisse – IT DEV RISK   *");
            Console.WriteLine("*  Hit 'Esc' to exit at any time...*");
            Console.WriteLine("************************************");
            Console.WriteLine();

            while (true)
            {
                DateTime referenceDate;
                Console.WriteLine("Please, inform the reference date in format (mm/dd/yyyy):");
                if (!DateTime.TryParseExact(Console.ReadLine(), "MM/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out referenceDate))
                {
                    Console.WriteLine("Invalid date format.");
                    continue;
                }
                Console.WriteLine();

                int n;
                Console.WriteLine("Please, inform the number of trades in portfolio (integer number > 0):");
                if (!int.TryParse(Console.ReadLine(), out n) || n < 0)
                {
                    Console.WriteLine("Invalid number format.");
                    continue;
                }
                Console.WriteLine();

                List<ITrade> portfolio = new List<ITrade>();

                for (int i = 0; i < n; i++)
                {
                    Console.WriteLine($"Please, inform the data, separated by a space, for trade {i + 1} (Value Sector Date(mm/dd/yyyy)):");
                    string line = Console.ReadLine();
                    string[] parts = line.Split(' ');

                    if (parts.Length != 3)
                    {
                        Console.WriteLine("Invalid data format.");
                        break;
                    }

                    double value;
                    DateTime nextPaymentDate;

                    if (!double.TryParse(parts[0], out value))
                    {
                        Console.WriteLine("Invalid number format for value.");
                        break;
                    }
                    Console.WriteLine();

                    if (!DateTime.TryParseExact(parts[2], "MM/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out nextPaymentDate))
                    {
                        Console.WriteLine("Invalid date format.");
                        break;
                    }
                    Console.WriteLine();

                    portfolio.Add(new Trade { Value = value, ClientSector = parts[1], NextPaymentDate = nextPaymentDate, ReferenceDate = referenceDate });
                }

                TradeCategoryStrategyFactory factory = new TradeCategoryStrategyFactory();
                TradeCategorizer categorizer = new TradeCategorizer(factory);

                List<string> tradeCategories = categorizer.CategorizeTrades(portfolio);

                Console.WriteLine("Category results:");
                foreach (var category in tradeCategories)
                {
                    Console.WriteLine(category);
                }

                Console.WriteLine();
                Console.WriteLine("Hit 'Esc' to exit at any time or hit another key to continue...");
                if (Console.ReadKey(true).Key == ConsoleKey.Escape)
                {
                    break;
                }
            }
        }
    }
}
