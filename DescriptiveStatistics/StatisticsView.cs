using System;
using System.Linq;
using System.Reflection;
using CustomExtensions;

namespace DescriptiveStatistics
{
    public static class StatisticsView
    {
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

        public static string NumbersToString(int[] numbers)
        {
            return String.Join(",", numbers.Select(n => n.ToString()).ToArray());
        }
    }
}