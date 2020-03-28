using System;
using System.Linq;

namespace DescriptiveStatistics
{
    static class Statistics
    {
        public static dynamic DescriptiveStatistics(int[] source)
        {
            return new { 
                max = Maximum(source),
                mean = Mean(source),
                median = Median(source),
                min = Minimum(source),
                mode = Mode(source),
                range = Range(source),
                standardDeviation = StandardDeviation(source)
                };
        }

       

        private static int Maximum(int[] source) => source.Max();


        private static double Mean (int[] source) => source.Average();
        
        private static double Median (int[] source)
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

        private static int Minimum (int[] source) => source.Min();
        
        private static int[] Mode (int[] source)
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

            return uniqueNumbers.Where((u,i) => numberCount[i] == numberCount.Max()).ToArray();
        }
        private static int Range (int[] source)
        {
            return (Maximum(source) - Minimum(source));
        }
        private static double StandardDeviation (int[] source)
        {
            double[] toDoubleArray = source.Select(num => (double)num).ToArray();

            double numbersMean = Mean(source);

            double[] numbersRange = toDoubleArray.Select(number => 
            ((new double[] {number, numbersMean}).Max()) - ((new double[] {number, numbersMean}).Min()))
            .ToArray();

            double[] squaredNumbers = numbersRange.Select(numRange => Math.Pow(numRange, 2)).ToArray();

            double meanOfSquaredNumbers = squaredNumbers.Average();

            return Math.Sqrt(meanOfSquaredNumbers);

        }
    }
}