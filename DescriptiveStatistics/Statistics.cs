using System;
using System.Linq;
using CustomExtensions;

namespace DescriptiveStatistics
{
    public static class Statistics
    {
        public static dynamic DescriptiveStatistics(int[] source)
        {
            return new { 
                Max = Maximum(source),
                Mean = Mean(source),
                Median = Median(source),
                Min = Minimum(source),
                Mode = Mode(source),
                Range = Range(source),
                StandardDeviation = StandardDeviation(source)
                };
        }

       

        private static int Maximum(int[] source) => source.Max();

        private static double Mean (int[] source) => source.Mean();
        
        private static double Median (int[] source) => source.Median();

        private static int Minimum (int[] source) => source.Minimum();
        
        private static int[] Mode (int[] source) => source.Mode();

        private static int Range (int[] source) => source.Range();

        private static double StandardDeviation (int[] source) => source.StandardDeviation();
    }
}