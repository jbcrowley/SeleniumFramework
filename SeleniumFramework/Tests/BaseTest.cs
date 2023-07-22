using Newtonsoft.Json;
using NUnit.Framework.Interfaces;
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using SeleniumFramework.Common;
using SeleniumFramework.TestData;
using SeleniumFramework.Utils;
using Logger = SeleniumFramework.Utils.Logger;

namespace SeleniumFramework.Tests
{
    public class BaseTest : DriverManager
    {
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
        public string Url;

        [OneTimeSetUp]
        public virtual void OneTimeSetup()
        {
            Url = EnvironmentManager.LandingUrl;
        }

        [SetUp]
        public void Setup()
        {
            // new DriverManager().CreateDriverInstance();
            DriverInstance.Url = Url;
            DriverInstance.Manage().Window.Maximize();
        }

        [TearDown]
        public virtual void TearDown()
        {
            try
            {
                if (!Equals(TestExecutionContext.CurrentContext.CurrentResult.ResultState, ResultState.Success))
                {
                    GenericHelper.TakeScreenshot(DriverInstance);
                }
            }
            catch (WebDriverException e)
            {
                Logger.Log($"DOM may not be ready, debug info not added: {e.Message}");
            }
            finally
            {
                DriverInstance.Quit();
            }
        }
    }
}