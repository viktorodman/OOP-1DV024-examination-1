using System.Linq;
using System;

namespace CustomExtensions
{
    public static class StatisticsExtension
    {

        public static int Maximum (this int[] source) => source.Max();
        public static double Maximum (this double[] source) => source.Max();

        public static double Mean (this int[] source) => source.Average();
        public static double Mean (this double[] source) => source.Average();

        public static double Median (this int[] source)
        {
            int arrayLength = source.Length;

            int[] sortedArray = source.OrderBy(num => num).ToArray();
            int middleOfArray = arrayLength / 2;

            double median = Mean(new int[]{ sortedArray[middleOfArray -1], sortedArray[middleOfArray]});

            if (arrayLength % 2 != 0) 
            {
                median = sortedArray[middleOfArray - 1];
            }
            return median;
        }

        public static int Minimum (this int[] source) => source.Min();
        public static double Minimum (this double[] source) => source.Min();

        public static int[] Mode (this int[] source)
        {
            int[] sortedNumbers = source.OrderBy(num => num).ToArray();
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

            return uniqueNumbers.Where((u,i) => numberCount[i] == Maximum(numberCount)).ToArray();
        }

        public static int Range (this int[] source) => (Maximum(source) - Minimum(source));
        
        public static double Range (this double[] source) => (Maximum(source) - Minimum(source));
        

        public static double StandardDeviation (this int[] source)
        {
            double[] toDoubleArray = source.Select(num => (double)num).ToArray();
            
            double numbersMean = Mean(source);

            double[] numbersRange = toDoubleArray.Select(number => Range(new double[] {number, numbersMean})).ToArray();

            double[] squaredNumbers = numbersRange.Select(numRange => Math.Pow(numRange, 2)).ToArray();

            return Math.Sqrt(Mean(squaredNumbers));
        }
    }
}