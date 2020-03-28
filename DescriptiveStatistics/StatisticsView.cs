using System;
using System.Linq;

namespace DescriptiveStatistics
{
    public static class StatisticsView
    {
        public static void ShowResults(dynamic result)
        {
        var results = (Object)result;

        var type = results.GetType();
		var props = type.GetProperties();
		
		var values = props.Select(x => x.GetValue(results, null)).ToArray();
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

        /* System.Console.WriteLine(test2); */
        }

        public static string NumbersToString(int[] numbers)
        {
            return String.Join(",", numbers.Select(n => n.ToString()).ToArray());
        }
    }
}