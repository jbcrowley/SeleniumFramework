using Newtonsoft.Json.Linq;

namespace SeleniumFramework.TestData
{
    public class JsonTestDataHandler : ITestData
    {
        /// <summary>
        /// Returns a collection of data from a JSON file for the current test
        /// </summary>
        /// <returns>The data for the current test</returns>
        public Dictionary<string, string> GetTestData()
        {
            JArray jArray = JArray.Parse(File.ReadAllText(new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory) + @"\TestData\TestData.json"));

            IList<JsonTestData> testData = jArray.Select(p => new JsonTestData
            {
                TestName = (string)p["TestName"],
                Properties = (KeyValuePair<string, string>)p["Properties"]
            }).ToList();

            return testData.Where(d => d.TestName == TestContext.CurrentContext.Test.Name).ToDictionary(x => x.Properties.Key, y => y.Properties.Value);
        }
    }
}