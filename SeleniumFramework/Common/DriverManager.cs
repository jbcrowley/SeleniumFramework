using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;

namespace SeleniumFramework.Common
{
    public class DriverManager
    {
        private IWebDriver driverInstance;
        private static DriverManager driverManagerInstance;

        public static DriverManager DriverManagerInstance
        {
            get
            {
                if (driverManagerInstance is null)
                {
                    driverManagerInstance = new DriverManager();
                }

                return driverManagerInstance;
            }
        }

        public IWebDriver DriverInstance
        {
            get
            {
                //if (driverInstance is null)
                //{
                //    CreateDriverInstance();
                //}

                return driverInstance ?? CreateDriverInstance();
            }
        }

        /// <summary>
        /// The IWebDriver instance based on 'browser' from local.runsettings.
        /// </summary>
        private IWebDriver CreateDriverInstance()
        {
            Browser browser = GetBrowserFromTestContext();
            switch (browser)
            {
                case Browser.Chrome:
                    return new ChromeDriver();
                case Browser.Edge:
                    return new EdgeDriver();
                default:
                    throw new ArgumentException($"{browser} is not defined in GetDriver().");
            }
        }

        /// <summary>
        /// Gets the name of the browser from the NUnit TestContext.
        /// </summary>
        /// <returns>The browser name.</returns>
        public static Browser GetBrowserFromTestContext()
        {
            string browserValue = TestContext.Parameters.Get("browser")!;
            if (Enum.TryParse(browserValue, true, out Browser browser))
            {
                return browser;
            }

            throw new ArgumentException($"<{browserValue}> is not a defined browser type.");
        }

        /// <summary>
        /// A list of supported browsers.
        /// </summary>
        public enum Browser
        {
            Chrome,
            Edge
        }
    }
}