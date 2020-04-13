using System.Linq;
using System;

namespace CustomExtensions
{
    /// <summary>
    ///  Represents an extension for the Statistics class
    /// </summary>
    public static class StatisticsExtension
    {
        /// <summary>
        /// Checks if the passed array is null or empty
        /// </summary>
        /// <param name="source"></param>
        public static void ValidateNullOrEmpty(this int[] source)
        {
            if (source == null)
            {
                throw new ArgumentException();
            }

            if (source.Length == 0)
            {
                throw new InvalidOperationException();
            }
        }

        
         /// <summary>
        /// Takes an array of integers and returns the
        /// median of the array.
        /// </summary>
        /// <param name="source">An Array of integers</param>
        /// <returns>The median of the passed array.</returns>
        public static double Median (this int[] source)
        {
            int arrayLength = source.Length;
            int middleOfArray = arrayLength / 2;

            int[] sortedArray = SortArray(source);
            

            double median = (new int[]{ sortedArray[middleOfArray -1], sortedArray[middleOfArray]}).Average();

            if (arrayLength % 2 != 0) 
            {
                median = sortedArray[middleOfArray - 1];
            }
            return median;
        }


        /// <summary>
        /// Takes an array of integers and returns the
        /// mode of the array
        /// </summary>
        /// <param name="source">An array of integers</param>
        /// <returns>The mode of the passed array</returns>
        public static int[] Mode (this int[] source)
        {
            int[] sortedNumbers = SortArray(source);
            int[] uniqueNumbers = sortedNumbers.Distinct().ToArray();

            int[] numberCount = new int[uniqueNumbers.Length];
            
            for (int i = 0; i < uniqueNumbers.Length; i++)
		    {
                for (int x = 0; x < source.Length; x++)
                {
                    if (uniqueNumbers[i] == source[x])
                    {
                        numberCount[i]++;
                    }
                }	
		    }

            return uniqueNumbers.Where((u,i) => numberCount[i] == numberCount.Max()).ToArray();
        }

         /// <summary>
        /// Takes an array of integers and returns the
        /// range of the passed array.
        /// </summary>
        /// <param name="source">An array of integers</param>
        /// <returns>The range of the passed array</returns>
        public static int Range (this int[] source) => (source.Max() - source.Min());
        
        /// <summary>
        /// Takes an array of doubles and returns the
        /// range of the passed array.
        /// </summary>
        /// <param name="source">An array of doubles</param>
        /// <returns>The range of the passed array</returns>
        public static double Range (this double[] source) => (source.Max()) - (source.Min());
        
        /// <summary>
        /// Takes an array of integers and returns the
        /// standard deviation of the passed array
        /// </summary>
        /// <param name="source">An array of integers</param>
        /// <returns>The standard deviation of the passed array</returns>
        public static double StandardDeviation (this int[] source)
        {
            double[] toDoubleArray = source.Select(num => (double)num).ToArray();
            
            double numbersMean = source.Average();

            double[] numbersRange = toDoubleArray.Select(number => Range(new double[] {number, numbersMean})).ToArray();

            double[] squaredNumbers = numbersRange.Select(numRange => Math.Pow(numRange, 2)).ToArray();

            return Math.Sqrt(squaredNumbers.Average());
        }

        /// <summary>
        /// Sorts an array of integers
        /// </summary>
        /// <param name="source">An array of integers</param>
        /// <returns>A sorted arrray of integers</returns>
        private static int[] SortArray (int[] source) => source.OrderBy(num => num).ToArray();
    }
}