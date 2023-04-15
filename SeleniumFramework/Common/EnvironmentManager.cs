using Microsoft.Extensions.Configuration;

namespace SeleniumFramework.Common
{
    public class EnvironmentManager
    {
        private static string baseUrl;
        private static IConfiguration configuration;
        private static EnvironmentName environment;
        private static string landingUrl;

        private EnvironmentManager()
        {
        }

        /// <summary>
        /// The URL based on 'environment' from local.runsettings.
        /// </summary>
        public static string BaseUrl
        {
            get
            {
                if (baseUrl == null)
                {
                    string url = Configuration.GetValue<string>($"Urls:{Environment}Url");

                    if (string.IsNullOrEmpty(url))
                    {
                        throw new ArgumentException($"The <{Environment}> environment does not have a URL defined in appsettings.json.");
                    }

                    baseUrl = url;
                }

                return baseUrl;
            }
        }

        /// <summary>
        /// The configuration settings from appsettings.json.
        /// </summary>
        public static IConfiguration Configuration
        {
            get
            {
                if (configuration == null)
                {
                    configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").AddEnvironmentVariables().Build();
                }

                return configuration;
            }
        }

        /// <summary>
        /// The 'environment' passed from Azure DevOps or from the local.runsettings file.
        /// </summary>
        public static EnvironmentName Environment
        {
            get
            {
                string environmentValue = TestContext.Parameters.Get("environment");

                if (Enum.TryParse(environmentValue, true, out EnvironmentName environmentName))
                {
                    if (Enum.IsDefined(typeof(EnvironmentName), environmentName))
                    {
                        environment = environmentName;
                    }
                    else
                    {
                        throw new ArgumentException($"<{environmentValue}> is not a defined Environment.");
                    }
                }

                return environment;
            }
        }

        /// <summary>
        /// The landing URL, the URL all tests will start on. A combination of BaseUrl and 'path' from appsettings.json.
        /// </summary>
        public static string LandingUrl
        {
            get
            {
                if (landingUrl == null)
                {
                    string path = Configuration.GetValue<string>($"Urls:Path");

                    if (string.IsNullOrEmpty(path))
                    {
                        throw new ArgumentException($"'{nameof(path)}' is not defined in appsettings.json.");
                    }

                    landingUrl = BaseUrl + path;
                }

                return landingUrl;
            }
        }

        /// <summary>
        /// All environment names.
        /// </summary>
        public enum EnvironmentName
        {
            Prod,
            Qa,
            Uat
        }
    }
}