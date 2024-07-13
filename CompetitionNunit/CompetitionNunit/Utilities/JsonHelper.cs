using CompetitionNunit.TestModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace CompetitionNunit.Utilities
{
    public class JsonHelper
    {


        public static List<T> ReadTestDataFromJson<T>(string jsonFilePath)
        {
#pragma warning disable
            string jsonContent = File.ReadAllText(jsonFilePath);
            List<T> testData = JsonConvert.DeserializeObject<List<T>>(jsonContent);
            return testData;

        }
    }
}
