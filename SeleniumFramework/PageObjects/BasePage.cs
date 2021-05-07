using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace SeleniumFramework.PageObjects
{
    public class BasePage
    {
        protected IWebDriver Driver;

        public BasePage(IWebDriver driver)
        {
            Driver = driver;
        }

        /// <summary>
        /// Clicks the element.
        /// </summary>
        /// <param name="locator">The By locator for the desired element.</param>
        /// <param name="timeOut">[Optional] How long to wait for the element (in seconds). The default is 10s.</param>
        public void Click(By locator, int timeOut = 10)
        {
            DateTime now = DateTime.Now;
            while (DateTime.Now < now.AddSeconds(timeOut))
            {
                try
                {
                    new WebDriverWait(Driver, TimeSpan.FromSeconds(timeOut)).Until(ExpectedConditions.ElementToBeClickable(locator)).Click();

                    return;
                }
                catch (Exception e) when (e is ElementClickInterceptedException || e is StaleElementReferenceException)
                {
                    // do nothing, loop again
                }
            }

            throw new Exception($"Not able to click element <{locator}> within {timeOut}s.");
        }

        /// <summary>
        /// Sends the provided string to the element.
        /// </summary>
        /// <param name="locator">The By locator for the desired element.</param>
        /// <param name="text">The string to be typed.</param>
        /// <param name="timeOut">[Optional] How long to wait for the element (in seconds). The default is 10s.</param>
        public void SendKeys(By locator, string text, int timeOut = 10)
        {
            DateTime now = DateTime.Now;
            while (DateTime.Now < now.AddSeconds(timeOut))
            {
                try
                {
                    new WebDriverWait(Driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementIsVisible(locator)).SendKeys(text);

                    return;
                }
                catch (StaleElementReferenceException)
                {
                    // do nothing, loop again
                }
            }

            throw new Exception($"Not able to .SendKeys() to element <{locator}> within {timeOut}s.");
        }

        /// <summary>
        /// Determines if the element exists.
        /// </summary>
        /// <param name="locator">The By locator for the desired element.</param>
        /// <returns>true if the element exists, false otherwise.</returns>
        public virtual bool ElementExists(By locator)
        {
            return FindElements(locator).Any();
        }

        /// <summary>
        /// Finds a single element with the provided locator.
        /// </summary>
        /// <param name="locator">The By locator for the desired element.</param>
        /// <returns>The found element.</returns>
        public virtual IWebElement FindElement(By locator)
        {
            return Driver.FindElement(locator);
        }

        /// <summary>
        /// Finds a single element using the provided wait condition.
        /// </summary>
        /// <param name="waitCondition">The wait condition can be an ExpectedCondition or a custom wait that returns an IWebElement.</param>
        /// <param name="timeOut">[Optional] How long to wait for the element (in seconds). The default timeOut is 10s.</param>
        /// <returns>The found element.</returns>
        public virtual IWebElement FindElement(Func<IWebDriver, IWebElement> waitCondition, int timeOut = 10)
        {
            return new WebDriverWait(Driver, TimeSpan.FromSeconds(timeOut)).Until(waitCondition);
        }

        /// <summary>
        /// Finds all elements with the provided locator.
        /// </summary>
        /// <param name="locator">The By locator for the desired element.</param>
        /// <returns>The collection of elements.</returns>
        public virtual IReadOnlyCollection<IWebElement> FindElements(By locator)
        {
            return Driver.FindElements(locator);
        }

        /// <summary>
        /// Finds all elements using the provided wait condition.
        /// </summary>
        /// <param name="waitCondition">The wait condition can be an ExpectedCondition or a custom wait that returns a boolean.</param>
        /// <param name="timeOut">[Optional] How long to wait for the element (in seconds). The default timeOut is 10s.</param>
        /// <returns>true if the waitCondition succeeds, false otherwise.</returns>
        public virtual bool FindElements(Func<IWebDriver, bool> waitCondition, int timeOut = 10)
        {
            return new WebDriverWait(Driver, TimeSpan.FromSeconds(timeOut)).Until(waitCondition);
        }

        /// <summary>
        /// Finds all elements using the provided wait condition.
        /// </summary>
        /// <param name="waitCondition">The wait condition can be an ExpectedCondition or a custom wait that returns a collection of IWebElement.</param>
        /// <param name="timeOut">[Optional] How long to wait for the element (in seconds). The default timeOut is 10s.</param>
        /// <returns>The collection of found elements.</returns>
        public virtual IReadOnlyCollection<IWebElement> FindElements(Func<IWebDriver, IReadOnlyCollection<IWebElement>> waitCondition, int timeOut = 10)
        {
            return new WebDriverWait(Driver, TimeSpan.FromSeconds(timeOut)).Until(waitCondition);
        }

        /// <summary>
        /// Returns the text of the element.
        /// </summary>
        /// <param name="locator">The By locator for the desired element.</param>
        /// <returns>The text contained in the element.</returns>
        public virtual string GetText(By locator)
        {
            int timeOut = 10;
            DateTime now = DateTime.Now;
            while (DateTime.Now < now.AddSeconds(timeOut))
            {
                try
                {
                    return FindElement(ExpectedConditions.ElementIsVisible(locator)).Text;
                }
                catch (StaleElementReferenceException)
                {
                    // do nothing, loop again
                }
            }

            throw new Exception($"Not able to get .Text from element <{locator}> within {timeOut}s.");
        }

        /// <summary>
        /// Returns the value of the element.
        /// </summary>
        /// <param name="locator">The By locator for the desired element.</param>
        /// <returns>The value of the element.</returns>
        public virtual string GetValue(By locator)
        {
            int timeOut = 10;
            DateTime now = DateTime.Now;
            while (DateTime.Now < now.AddSeconds(timeOut))
            {
                try
                {
                    return FindElement(ExpectedConditions.ElementIsVisible(locator)).GetAttribute("value");
                }
                catch (StaleElementReferenceException)
                {
                    // do nothing, loop again
                }
            }

            throw new Exception($"Not able to get 'value' from element <{locator}> within {timeOut}s.");
        }

        /// <summary>
        /// Determines if an element is displayed with an optional wait.
        /// </summary>
        /// <param name="locator">The By locator for the desired element.</param>
        /// <param name="timeOut">[Optional] How long to wait for the element in seconds. The default timeOut is 10s.</param>
        /// <returns>true if displayed, false otherwise</returns>
        public virtual bool IsElementDisplayed(By locator, int timeOut = 10)
        {
            try
            {
                FindElement(ExpectedConditions.ElementIsVisible(locator), timeOut);

                return true;
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }
        }

        /// <summary>
        /// Locates a SELECT element and selects an option by index, text or value.
        /// </summary>
        /// <param name="locator">The locator used to find the element.</param>
        /// <param name="dropDownVal"></param>
        /// <param name="selectBy"></param>
        /// <param name="timeOut">How long to wait for the element in seconds (optional). The default timeOut is 10s.</param>
        /// <param name="waitForStale">If true, waits for the dropdown to go stale after setting the desired value. This is useful for those dropdowns that refresh the page after being set.</param>
        /// <param name="verify">[Optional] If true, verifies that the value selected is equal to the desired value. If false, the validation is skipped.</param>
        //public virtual void SelectOption(By locator, string dropDownVal, SelectBy selectBy, int timeOut = 10, bool waitForStale = false, bool verify = true)
        //{
        //    IWebElement element = FindElement(locator);

        //    switch (selectBy)
        //    {
        //        case SelectBy.Index:
        //            element.ComboBox().SelectByIndex(int.Parse(dropDownVal));
        //            break;
        //        case SelectBy.Text:
        //            element.ComboBox().SelectByText(dropDownVal);
        //            break;
        //        case SelectBy.PartialText:
        //            element.ComboBox().SelectByText(dropDownVal, true);
        //            break;
        //        case SelectBy.Value:
        //            element.ComboBox().SelectByValue(dropDownVal);
        //            break;
        //    }
        //}
    }
}