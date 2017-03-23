using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewtonSqrt
{
    public static class NewtonSqrt
    {
        public static double RootN(double x, int n, double precition)
        {
            if ((x < 0 && n % 2 == 0) || (precition < 0 || precition > 1) || n == 0) 
                throw new ArgumentException();

            double result = x / n;
            double previousResult;
            do
            {
                previousResult = result;
                result = ((double)1 / n) * ((n - 1) * previousResult + (x / Math.Pow(previousResult, n - 1)));
            }
            while (Math.Abs(result - previousResult) > precition);

            return result;
        }
    }
}
