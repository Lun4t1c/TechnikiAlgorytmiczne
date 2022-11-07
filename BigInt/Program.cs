
namespace BigNumber
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BigNumber.isInDebugMode = true;
            BigNumber bigNumber = new BigNumber("12345");
            bigNumber /= new BigNumber("10");

            Console.WriteLine(bigNumber);
            bigNumber.DisplayLinks();
        }
    }
}
