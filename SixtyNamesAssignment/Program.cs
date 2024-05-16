using SixtyNamesAssignment.Services;

namespace SixtyNamesAssignment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("You can press Q to exit.");
                Console.Write("Enter number of the task:");

                var input = Console.ReadKey();

                if (input.Key == ConsoleKey.Q)
                {
                    break;
                }

                switch (input.Key)
                {
                    case ConsoleKey.D1:
                    {
                        Console.WriteLine("\n\nFirst task:");
                        DbService.GetThisYearAgreementSum();
                        Console.WriteLine();
                        break;
                    }
                    case ConsoleKey.D2:
                    {
                        Console.WriteLine("\n\nSecond task:");
                        DbService.GetAgreementSumOfEveryRussianLegalPerson();
                        Console.WriteLine();
                        break;
                    }
                    case ConsoleKey.D3:
                    {
                        Console.WriteLine("\n\nThird task:");
                        DbService.GetIndividualPersonsEmail();
                        Console.WriteLine();
                        break;
                    }
                    case ConsoleKey.D4:
                    {
                        Console.WriteLine("\n\nFourth task:");
                        DbService.SetAgreementToTerminated();
                        Console.WriteLine();
                        break;
                    }
                    case ConsoleKey.D5:
                    {
                        Console.WriteLine("\n\nFifth task:");
                        DbService.MakeReport();
                        Console.WriteLine();
                        break;
                    }
                }
            }
        }
    }
}
