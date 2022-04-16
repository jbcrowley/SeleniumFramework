using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Configuration;

namespace SeleniumFramework.Utils
{
    class GenericHelper
    {
        /// <summary>
        /// Gets the URL based on the environment passed as an NUnit parameter.
        /// </summary>
        /// <returns>The site URL.</returns>
        public static string GetBaseUrl()
        {
            Environment environment = GetEnvironment();
            string url = ConfigurationManager.AppSettings[$"{environment}Url"];

            if (string.IsNullOrEmpty(url))
            {
                throw new ArgumentException($"The <{environment}> environment does not have a URL defined in app.config.");
            }

            return url;
        }

        /// <summary>
        /// Gets the run environment from either the value passed through TFS or from the local.runsettings file.
        /// </summary>
        /// <returns>The environment.</returns>
        public static Environment GetEnvironment()
        {
            string environmentValue = TestContext.Parameters.Get("environment");

            if (Enum.TryParse(environmentValue, true, out Environment environment))
            {
                return environment;
            }

            throw new ArgumentException($"<{environmentValue}> is not a defined Environment.");
        }

        /// <summary>
        /// Writes a message to the current test.
        /// </summary>
        /// <param name="message">The message to be written.</param>
        public static void Log(string message)
        {
            TestContext.Out.WriteLine(message);
        }

        /// <summary>
        /// Takes a screenshot and attaches it to the current NUnit TestContext.
        /// </summary>
        /// <param name="driver">The current IWebDriver instance.</param>
        public static void TakeScreenshot(IWebDriver driver)
        {
            // TODO: Write screenshot code
        }

        /// <summary>
        /// A list of environments.
        /// </summary>
        public enum Environment
        {
            Prod,
            Qa,
            Uat
        }
    }
}