using System;
using System.Linq;
using System.Reflection;

namespace DescriptiveStatistics
{
    /// <summary>
    /// Represents the presentation of some statistics
    /// </summary>
    public static class StatisticsView
    {
        /// <summary>
        /// Displays the results of the passed object
        /// </summary>
        /// <param name="result">An object with statistics</param>
        public static void ShowResults(object result)
        {
        PropertyInfo[] props = result.GetType().GetProperties();

		var values = props.Select(x => x.GetValue(result, null)).ToArray();
		var keys = props.Select(y => y.Name).ToArray();
		
		string str = "";
		for (int i = 0; i < values.Length; i++)
		{
			
				
			switch (values[i].GetType().ToString())
            {
                case "System.Int32":
                    str = $"{keys[i],-20} : {values[i]}";
                break;
                case "System.Double":
                    str = $"{keys[i],-20} : {values[i]:F1}";
                break;
                case "System.Int32[]":
                    str = $"{keys[i],-20} : {NumbersToString((int[])values[i])}";
                break;    
            }

          
            Console.WriteLine(str);
		}	

        }

        /// <summary>
        /// Creates a string from an array of integers.
        /// </summary>
        /// <param name="numbers">An array of integers</param>
        /// <returns>A string representing the passed array</returns>
        public static string NumbersToString(int[] numbers)
        {
            return String.Join(", ", numbers.Select(n => n.ToString()).ToArray());
        }
    }
}