namespace MathUtils
{
    internal class MathUtils
    {
        /// <summary>
        /// Simulates a process where in each round you either multiply your wealth by 1.9 or by 0.5.
        /// This simulates the exponential paradox where despite the average seeming positive, the median tends toward 0.
        /// </summary>
        public static double SimulateExponentialWealthParadox(int attempts, double startingMoney)
        {
            Random random = new Random();

            for (int i = 0; i < attempts; i++)
            {
                // 50% chance to multiply by 1.9 (gain), 50% chance to multiply by 0.5 (loss)
                if (random.Next(0, 2) == 0)
                    startingMoney *= 1.9;
                else
                    startingMoney *= 0.5;
            }

            return startingMoney;
        }

        /// <summary>
        /// Approximates the series 1 + 1/2 + 1/4 + 1/8 + ... up to a given number of times.
        /// This series tends to 2 as the iterations approach infinity.
        /// </summary>
        public static decimal SumOfHalves(int terms)
        {
            decimal sum = 0;

            for (decimal term = 1, current = 0; current < terms; term /= 2, current++)
                sum += term;

            return sum;
        }

        /// <summary>
        /// Approximates Euler's number (e) using the formula: (1 + 1/n)^n
        /// </summary>
        public static decimal ApproximateE(int n)
        {
            decimal factor = 1 + 1 / (decimal)n;
            decimal result = 1;

            for (int i = 1; i < n; i++)
                result *= factor;

            return result;
        }

        /// <summary>
        /// Approximates the root of a given number to a given degree and precision.
        /// Supports both square roots and non-square roots.
        /// </summary>
        public static decimal Root(decimal number, decimal rootDegree = 2, decimal? maxError = null, int? decimalPlaces = null)
        {
            if (number < 0 || rootDegree < 0 || maxError < 0 || decimalPlaces < 0)
                throw new ArithmeticException("Negative numbers are not supported.");

            for (int i = 0; i <= number; i++)
            {
                if (i * i == number)
                    return i;
            }

            decimal errorMargin = maxError ?? 0.000001m;
            int decimals = decimalPlaces ?? 6;

            if (rootDegree == 2)
                return Math.Round(SquareRoot(number, errorMargin, decimals), decimals);

            decimal guess = number / 2;
            decimal increment = number / 2;

            if (number < 1)
            {
                guess = 1;
                increment = 1;
            }

            while (IntegerPower(guess, (int)rootDegree) < number - errorMargin / 2
                || IntegerPower(guess, (int)rootDegree) > number + errorMargin / 2)
            {
                increment /= 2;
                guess += IntegerPower(guess, (int)rootDegree) > number ? -increment : increment;
            }

            return Math.Round(guess - errorMargin / 2, decimals);
        }

        /// <summary>
        /// Raises a decimal number to an integer power.
        /// </summary>
        public static decimal IntegerPower(decimal baseNumber, int exponent)
        {
            decimal result = baseNumber;

            for (int i = 1; i < exponent; i++)
                result *= baseNumber;

            return result;
        }

        /// <summary>
        /// Raises a number to a decimal exponent. Supports decimal and negative exponents.
        /// </summary>
        public static decimal Power(decimal baseNumber, decimal exponent)
        {
            if (exponent == 0)
                return 1;
            if (baseNumber == 0)
                return 0;

            double result = Math.Pow((double)baseNumber, (double)exponent);
            return (decimal)result;
        }

        /// <summary>
        /// Approximates the square root of a number using binary search within a given margin of error.
        /// </summary>
        public static decimal SquareRoot(decimal number, decimal errorMargin, int decimalPlaces)
        {
            decimal guess = number / 2;
            decimal increment = number / 2;

            if (number < 1)
            {
                guess = 1;
                increment = 1;
            }

            while (guess * guess < number - errorMargin / 2 || guess * guess > number + errorMargin / 2)
            {
                increment /= 2;
                guess += guess * guess > number ? -increment : increment;
            }

            return guess;
        }
    }
}

