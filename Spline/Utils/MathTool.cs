using System;
using System.Collections.Generic;
using System.Text;

namespace Spline.Utils
{
    public class MathTool
    {
        public static int GetFactorial(int i)
        {
            if (i < 0)
            {
                throw new ArgumentException("Factorial value must be bigger than 0");
            }

            int result = 1;
            for (int k = 1; k <= i; k++)
            {
                result *= k;
            }

            return result;
        }

        public static int GetBinomialCoefficient(int n, int i)
        {
            if (n < 0)
            {
                throw new ArgumentException("The value must be bigger than 0");
            }
            if (i < 0)
            {
                throw new ArgumentException("The value must be bigger than 0");
            }
            int val = GetFactorial(n) / (GetFactorial(i) * GetFactorial(n - i));

            return val;
        }
    }
}
