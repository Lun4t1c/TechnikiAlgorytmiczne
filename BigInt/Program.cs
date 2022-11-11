
namespace BigNumber
{
    public class Program
    {
        public static void Main(string[] args)
        {
            while (true)
            {
                BigNumber a;
                BigNumber b;
                BigNumber result = null;

                try
                {
                    Console.Write("Podaj pierwszą liczbę:\n> ");
                    a = new BigNumber(Console.ReadLine());

                    Console.Write("Podaj drugą liczbę:\n> ");
                    b = new BigNumber(Console.ReadLine());

                    string choice = MenuPrompt();

                    var watch = System.Diagnostics.Stopwatch.StartNew();
                    watch.Start();

                    switch (choice)
                    {
                        case "1":
                            result = a + b;
                            break;


                        case "2":
                            result = a - b;
                            break;


                        case "3":
                            result = a * b;
                            break;


                        case "4":
                            result = a / b;
                            break;


                        case "0":
                            return;


                        default:
                            Console.WriteLine("Nierozpoznany wybór.");
                            break;
                    }
                    watch.Stop();

                    if (result != null)
                    {
                        Console.WriteLine($"\nWynik:\n{result}");
                        Console.WriteLine($"Czas: {watch.ElapsedMilliseconds}ms");
                    }
                }
                catch (Exception exc)
                {
                    Console.WriteLine(exc.Message);
                }

                Console.WriteLine("\n======================================================================");
            }
        }

        public static string MenuPrompt()
        {
            Console.WriteLine("\nWybierz działanie:");
            Console.WriteLine("1. Dodawanie");
            Console.WriteLine("2. Odejmowanie");
            Console.WriteLine("3. Mnożenie");
            Console.WriteLine("4. Dzielenie");
            Console.WriteLine("0. Wyjdź");
            Console.Write("> ");
            return Console.ReadLine();
        }
    }
}
