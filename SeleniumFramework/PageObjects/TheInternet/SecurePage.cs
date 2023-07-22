using OpenQA.Selenium;

namespace SeleniumFramework.PageObjects.TheInternet
{
    class SecurePage : BasePage
    {
        private readonly By _logoutButtonLocator = By.CssSelector("a[href='/logout']");

        /// <summary>
        /// Clicks the Logout button.
        /// </summary>
        public void Logout()
        {
            Click(_logoutButtonLocator);
        }
    }
}