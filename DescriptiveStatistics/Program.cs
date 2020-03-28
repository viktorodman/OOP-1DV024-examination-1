using System;
using System.IO;
using Newtonsoft.Json;



namespace DescriptiveStatistics
{
    class Program
    {
        static void Main(string[] args)
        {
            
            try
            {
                int[] numbers = GetJsonNumbers(args[0]);

               
                int[] max = Statistics.DescriptiveStatistics(numbers);

                foreach (var item in max)
                {
                System.Console.WriteLine(item);
                }

               /*  System.Console.WriteLine(max); */
            }
            catch (System.Exception)
            {
                
                System.Console.WriteLine("AAAAH");
            }
        }
        private static int[] GetJsonNumbers(string filePath)
        {
            return JsonConvert.DeserializeObject<int[]>(File.ReadAllText(filePath));
        }
    }
}
