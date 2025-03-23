using BasePage.Extensions;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using SeleniumFramework.Common;
using DescriptionAttribute = System.ComponentModel.DescriptionAttribute;

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
        public void ChooseByText(Option option)
        {
            FindElement(ExpectedConditions.ElementIsVisible(_dropdownLocator)).Select().SelectByText(option.GetDescription());
        }

        /// <summary>
        /// Returns the text of the selected OPTION.
        /// </summary>
        /// <returns>The text of the selected OPTION.</returns>
        public string GetSelectedOption()
        {
            return FindElement(ExpectedConditions.ElementIsVisible(_dropdownLocator)).Select().SelectedOption.Text;
        }

        /// <summary>
        /// The list of dropdown options.
        /// </summary>
        public enum Option
        {
            [Description("Option 1")]
            Option1,
            [Description("Option 2")]
            Option2
        }
    }
}