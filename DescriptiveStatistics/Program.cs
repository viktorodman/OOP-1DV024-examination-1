using System;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DescriptiveStatistics
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int[] numbers = GetJsonNumbers(args[0]);

                foreach (var item in numbers)
                {
                System.Console.WriteLine(item);
                }
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
