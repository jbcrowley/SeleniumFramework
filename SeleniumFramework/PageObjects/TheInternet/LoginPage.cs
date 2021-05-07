using OpenQA.Selenium;

namespace SeleniumFramework.PageObjects.TheInternet
{
    class LoginPage : BasePage
    {
        private readonly By _loginButtonLocator = By.CssSelector("button");
        private readonly By _passwordLocator = By.Id("password");
        private readonly By _usernameLocator = By.Id("username");

        public LoginPage(IWebDriver driver) : base(driver)
        {
        }

        /// <summary>
        /// Logs in with the provided username and password.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        public void Login(string username, string password)
        {
            SendKeys(_usernameLocator, username);
            SendKeys(_passwordLocator, password);
            Click(_loginButtonLocator);
        }
    }
}
