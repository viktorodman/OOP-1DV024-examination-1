using System;
using System.IO;
using Newtonsoft.Json;



namespace DescriptiveStatistics
{
    /// <summary>
    /// Represents the main place where the program starts the execution. 
    /// </summary>
    class Program
    {
        /// <summary>
        /// The starting point of the application
        /// </summary>
        /// <param name="args">Array containing arguments passed to the application</param>
        static void Main(string[] args)
        {
            
            try
            {
                int[] numbers = GetJsonNumbers(args[0]);

                dynamic result = Statistics.DescriptiveStatistics(numbers);
                
                StatisticsView.ShowResults(result);
               
            }
            catch (System.Exception e)
            {
                
                System.Console.WriteLine(e);
            }
        }
        /// <summary>
        /// Reads a json file and return an integer array with its content
        /// </summary>
        /// <param name="filePath">Path to json file</param>
        /// <returns></returns>
        private static int[] GetJsonNumbers(string filePath)
        {
            string textInFile = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<int[]>(textInFile);
        }
    }
}
