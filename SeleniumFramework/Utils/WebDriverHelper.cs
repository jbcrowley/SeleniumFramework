using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using System;

namespace SeleniumFramework.Utils
{
    class WebDriverHelper
    {
        /// <summary>
        /// Gets the name of the browser from the NUnit TestContext.
        /// </summary>
        /// <returns>The browser name.</returns>
        public static string GetBrowserFromTestContext()
        {
            return TestContext.Parameters.Get("browser")?.ToLower() ?? TestContext.Parameters.Get("localBrowser").ToLower();
        }

        /// <summary>
        /// Gets the desired Selenium driver from the config.
        /// </summary>
        /// <returns>A driver instance.</returns>
        public static IWebDriver GetDriver()
        {
            string browser = GetBrowserFromTestContext();
            switch (browser)
            {
                case "chrome":
                    return new ChromeDriver();
                case "edge":
                    return new EdgeDriver();
                default:
                    throw new ArgumentOutOfRangeException($"{browser} is not a defined browser type.");
            }
        }
    }
}