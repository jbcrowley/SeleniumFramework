using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;

namespace SeleniumFramework.Utils
{
    class GenericHelper
    {
        private static string BaseUrl;
        private static string LandingUrl;

        /// <summary>
        /// Gets the URL based on the environment passed as an NUnit parameter.
        /// </summary>
        /// <returns>The site URL.</returns>
        public static string GetBaseUrl()
        {
            if (BaseUrl == null)
            {
                Environment environment = GetEnvironment();
                IConfiguration config = new ConfigurationBuilder().AddJsonFile("appsettings.json").AddEnvironmentVariables().Build();
                string url = config.GetValue<string>($"Urls:{environment}Url");

                if (string.IsNullOrEmpty(url))
                {
                    throw new ArgumentException($"The <{environment}> environment does not have a URL defined in appsettings.json.");
                }

                BaseUrl = url;
            }

            return BaseUrl;
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
        /// Gets the landing URL, the URL all tests will start on.
        /// </summary>
        /// <returns>The landing URL.</returns>
        public static string GetLandingUrl()
        {
            if (LandingUrl == null)
            {
                IConfiguration config = new ConfigurationBuilder().AddJsonFile("appsettings.json").AddEnvironmentVariables().Build();
                string path = config.GetValue<string>($"Urls:Path");

                if (string.IsNullOrEmpty(path))
                {
                    throw new ArgumentException($"'{nameof(path)}' is not defined in appsettings.json.");
                }

                LandingUrl = GetBaseUrl() + path;
            }

            return LandingUrl;
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