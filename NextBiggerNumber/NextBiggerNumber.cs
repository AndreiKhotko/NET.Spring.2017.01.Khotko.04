using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextBiggerNumber
{
    public static class NextBiggerNumber
    {
        public static int GetNextBiggerNumber(int number)
        {
            if (number < 0)
            {
                throw new ArgumentException();
            }
            // GetDigits
            List<byte> digits = new List<byte>();
            int tmp_number = number;

            while (tmp_number > 9)
            {
                byte digit = (byte)(tmp_number % 10);
                digits.Add(digit);
                tmp_number /= 10;
            }

            digits.Add((byte)tmp_number);

            if (digits.Count == 1)
                return -1;

            //====
            
            int i = 1;
            while (i < digits.Count && digits[i] >= digits[i - 1])
                i++;

            // if we went to end, there is no biggerDigitNumber
            if (i == digits.Count)
                return -1;

            //Swap digits[i] and digits[i - 1]
            byte tmp = digits[i];
            digits[i] = digits[i - 1];
            digits[i - 1] = tmp;

            byte[] digitsArray = digits.ToArray();

            SortReverse(digitsArray, i);

            //GetNewNumberFromDigitsArray
            int result = 0;
            int powerOfTen = 0;
            for (i = 0; i < digitsArray.Length; i++)
            {
                result += digitsArray[i] * (int)Math.Pow(10, powerOfTen++);
            }

            return result;
        }

        /// <summary>
        /// Construct a sorted array A by merging two sorted arrays L and R
        /// </summary>
        /// <param name="A">Array to be need to sort</param>
        /// <param name="L">Left part of array A</param>
        /// <param name="R">Right part of array A</param>
        private static void Merge(byte[] A, byte[] L, byte[] R)
        {
            int i = 0; // i - index of A
            int j = 0; // j - index of L
            int k = 0; // k - index of R

            while (j < L.Length && k < R.Length)
            {
                if (L[j] > R[k])
                {
                    A[i++] = L[j++];
                }
                else
                {
                    A[i++] = R[k++];
                }
            }

            while (j < L.Length)
                A[i++] = L[j++];

            while (k < R.Length)
                A[i++] = R[k++];
        }

        /// <summary>
        /// Sort an array using merge algorithm
        /// </summary>
        /// <param name="array"></param>
        private static void SortReverse(byte[] array, int toIndex)
        { 
            int n = toIndex;

            if (n < 2)
                return;

            int middle = n / 2;

            // Divide our array into 2 parts. 
            byte[] L = CopyArray(array, 0, middle - 1);
            byte[] R = CopyArray(array, middle, n - 1);

            // Sort Left and Right parts of our array using a recursion
            SortReverse(L, L.Length);
            SortReverse(R, R.Length);

            // Merge sorted left and right parts
            Merge(array, L, R);
        }

        /// <summary>
        /// Copy an array source from startIndex to endIndex
        /// </summary>
        /// <param name="source"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns>Destination array</returns>
        private static byte[] CopyArray(byte[] source, int startIndex, int endIndex)
        {
            byte[] result = new byte[endIndex - startIndex + 1];

            int j = 0;

            for (int i = startIndex; i <= endIndex; i++)
            {
                result[j++] = source[i];
            }

            return result;
        }
    }
}
