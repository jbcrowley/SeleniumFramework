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
            string environment = GetEnvironment();
            string url;
            switch (environment)
            {
                case "prod":
                    url = ConfigurationManager.AppSettings["PRODUrl"];
                    break;
                case "qa":
                    url = ConfigurationManager.AppSettings["QAUrl"];
                    break;
                case "uat":
                    url = ConfigurationManager.AppSettings["UATUrl"];
                    break;
                default:
                    throw new ArgumentOutOfRangeException($"'{environment}' is not a valid environment.");
            }

            if (string.IsNullOrEmpty(url))
            {
                throw new ArgumentOutOfRangeException($"The '{environment}' environment does not have a valid AppSetting for URL.");
            }

            return url;
        }

        /// <summary>
        /// Gets the run environment from either the value passed through TFS or from the local.runsettings file.
        /// </summary>
        /// <returns>The environment.</returns>
        public static string GetEnvironment()
        {
            return TestContext.Parameters.Get("env")?.ToLower() ?? TestContext.Parameters.Get("localEnv").ToLower();
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
    }
}