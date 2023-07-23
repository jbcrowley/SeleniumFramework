using NUnit.Framework.Interfaces;
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using SeleniumFramework.Common;

namespace SeleniumFramework.Utils
{
    public class Driver
    {
        private static IWebDriver _driver;

        [SetUp]
        public void Setup()
        {
            _driver = DriverFactory.GetDriver();
            _driver.Url = EnvironmentManager.LandingUrl;
            _driver.Manage().Window.Maximize();
        }

        [TearDown]
        public void TearDown()
        {
            try
            {
                if (!Equals(TestExecutionContext.CurrentContext.CurrentResult.ResultState, ResultState.Success))
                {
                    GenericHelper.TakeScreenshot(_driver);
                }
            }
            catch (WebDriverException e)
            {
                Logger.Log($"DOM may not be ready, debug info not added: {e.Message}");
            }
            finally
            {
                _driver.Quit();
            }
        }

        public static IWebDriver WebDriver
        {
            get { return _driver; }
        }
    }
}