using static MathUtils.MathUtils;

namespace MathUtils
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            ExecuteMathUtilMethods();
        }

        public static void ExecuteMathUtilMethods()
        {
            Console.Write("Square root of 9 (0 decimals, error margin 0.00001): ");
            Console.WriteLine(Root(9, 2, 0.00001m, 0)); // 3

            Console.Write("Square root of 7.1 (default 6 decimals): ");
            Console.WriteLine(Root(7.1m, 2, 0.000001m)); // 2.664

            Console.Write("Square root of 10 (4 decimals, error margin 0.01): ");
            Console.WriteLine(Root(10, 2, 0.01m, 4)); // 3.161


            Console.Write("Final money after 5000 coin tosses (×1.9 or ×0.5 each): ");
            Console.WriteLine(SimulateExponentialWealthParadox(5000, 5)); // Output varies, it tends toward 0


            Console.Write("Sum of 1000 halved terms starting from 1: ");
            Console.WriteLine(SumOfHalves(5)); // tends to 2.0


            Console.Write("Approximation of Euler’s number (e) using (1 + 1/n)^n with n = 1000: ");
            Console.WriteLine(ApproximateE(1000)); // 2.714


            Console.Write("2^1.04 = ");
            Console.WriteLine(Power(2, 1.04m)); // 2.056

            Console.Write("8^3.5 = ");
            Console.WriteLine(Power(8, 3.5m)); // 1448.154
        }
    }
}
