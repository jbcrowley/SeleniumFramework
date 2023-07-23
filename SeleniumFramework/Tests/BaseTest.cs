using Newtonsoft.Json;
using OpenQA.Selenium;
using SeleniumFramework.TestData;

namespace SeleniumFramework.Tests
{
    public class BaseTest
    {
        /// <summary>
        /// The thread-safe driver instance.
        /// </summary>
        public ThreadLocal<IWebDriver> Driver = new ThreadLocal<IWebDriver>();

        /// <summary>
        /// The path to the globaldata.json file.
        /// </summary>
        public static string GlobalDataPath = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory) + @"\globaldata.json";

        /// <summary>
        /// Holds the global data from the JSON file.
        /// </summary>
        public static Dictionary<string, string> GlobalData { get; } = JsonConvert.DeserializeObject<Dictionary<string, string>>(File.ReadAllText(GlobalDataPath));

        /// <summary>
        /// Holds the test data for the current running script.
        /// </summary>
        public Dictionary<string, string> TestData = new CsvTestData().GetTestData();

        /// <summary>
        /// Holds the URL for the landing page.
        /// </summary>
        public static string Url;

        //[OneTimeSetUp]
        //public virtual void OneTimeSetup()
        //{
        //    Url = EnvironmentManager.LandingUrl;
        //}
    }
}