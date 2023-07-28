using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using SeleniumFramework.Common;

namespace SeleniumFramework.PageObjects.TheInternet
{
    class DropdownPage : BasePage
    {
        private readonly By _dropdownLocator = By.Id("dropdown");

        public DropdownPage(IWebDriver driver) : base(driver)
        {
        }

        /// <summary>
        /// Choose an OPTION by text.
        /// </summary>
        public void ChooseByText(string option)
        {
            FindElement(ExpectedConditions.ElementIsVisible(_dropdownLocator)).Select().SelectByText(option);
        }

        /// <summary>
        /// Returns the text of the selected OPTION.
        /// </summary>
        /// <returns>The text of the selected OPTION.</returns>
        public string GetSelectedOption()
        {
            return FindElement(ExpectedConditions.ElementIsVisible(_dropdownLocator)).Select().SelectedOption.Text;
        }
    }
}