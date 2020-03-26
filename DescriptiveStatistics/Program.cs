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
            

            /* string st = File.ReadAllText(args[0]);

            System.Console.WriteLine(st);

            string json = JsonConverter(JToken.Parse(args[0])); */

            using (StreamReader reader = File.OpenText(@args[0]))
            {
                JObject o = (JObject)JToken.ReadFrom(new JsonTextReader(reader));
                System.Console.WriteLine(o);
            }
        }
    }
}
