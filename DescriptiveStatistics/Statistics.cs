using System;
using System.Linq;
using CustomExtensions;

namespace DescriptiveStatistics
{
    /// <summary>
    /// Represents number statistics
    /// </summary>
    public static class Statistics
    {
        /// <summary>
        /// Takes an array of integers and return the Max value, Mean,
        /// Median, Min value, Mode, Range and standard deviation of the passed array.
        /// </summary>
        /// <param name="source">An array of integers</param>
        /// <returns>the Max value, Mean, Median, Min value, Mode, Range and standard deviation of the passed array</returns>
        public static dynamic DescriptiveStatistics(int[] source)
        {
            source.ValidateNullOrEmpty();
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

       
        /// <summary>
        /// Takes an array of integers and returns the
        /// largest integer in the array. 
        /// 
        /// </summary>
        /// <param name="source">An Array of integers</param>
        /// <returns>The largest integer in the passed array.</returns>
        private static int Maximum(int[] source) 
        {
            source.ValidateNullOrEmpty();

            return source.Max();
        } 



        /// <summary>
        /// Takes an array of integers and returns the
        /// mean of the array.
        /// </summary>
        /// <param name="source">An Array of integers</param>
        /// <returns>The mean of the passed array.</returns>
        private static double Mean (int[] source) 
        {
            source.ValidateNullOrEmpty();

            return source.Average();
        }       


        /// <summary>
        /// Takes an array of integers and returns the
        /// median of the array.
        /// </summary>
        /// <param name="source">An Array of integers</param>
        /// <returns>The median of the passed array.</returns>
        private static double Median (int[] source) 
        { 
            source.ValidateNullOrEmpty();

            return source.Median();

        }

        /// <summary>
        /// Takes an array of integers and returns the
        /// smallest integer in the array.
        /// </summary>
        /// <param name="source">An Array of integers</param>
        /// <returns>The smallest integer in the passed array.</returns>
        private static int Minimum (int[] source) 
        {
            source.ValidateNullOrEmpty();

            return source.Min();
        }


        /// <summary>
        /// Takes an array of integers and returns the
        /// mode of the array
        /// </summary>
        /// <param name="source">An array of integers</param>
        /// <returns>The mode of the passed array</returns>       
        private static int[] Mode (int[] source) 
        {
            source.ValidateNullOrEmpty();

            return source.Mode();
        }


        /// <summary>
        /// Takes an array of integers and returns the
        /// range of the passed array.
        /// </summary>
        /// <param name="source">An array of integers</param>
        /// <returns>The range of the passed array</returns>
        private static int Range (int[] source) 
        {
            source.ValidateNullOrEmpty();

            return source.Range();
        }


        /// <summary>
        /// Takes an array of integers and returns the
        /// standard deviation of the passed array
        /// </summary>
        /// <param name="source">An array of integers</param>
        /// <returns>The standard deviation of the passed array</returns>
        private static double StandardDeviation (int[] source) 
        {
            source.ValidateNullOrEmpty();   

            return source.StandardDeviation();
        }
    }
}