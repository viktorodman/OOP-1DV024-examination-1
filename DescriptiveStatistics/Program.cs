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

               
                dynamic result = Statistics.DescriptiveStatistics(numbers);

                StatisticsView.ShowResults(result);
            }
            catch (System.Exception)
            {
                
                System.Console.WriteLine("AAAAH");
            }
        }
        private static int[] GetJsonNumbers(string filePath)
        {
            string readText = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<int[]>(readText);
        }
    }
}
