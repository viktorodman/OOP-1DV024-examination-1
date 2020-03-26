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
                test = Mean(source)
                };
        }

        private static int Maximum (int[] source)
        {
            return source.Max();
        }
        private static double Mean (int[] source)
        {
            double sum = source.Aggregate(0, (acc, x) => acc + x);
            return sum / source.Length;
        }
        private static double Median (int[] source)
        {
         
        }
       /*  private static int Minimum (int[] source)
        {

        }
        private static int[] Mode (int[] source)
        {

        }
        private static int Range (int[] source)
        {

        }
        private static double StandardDeviation (int[] source)
        {

        } */

        
    }
}