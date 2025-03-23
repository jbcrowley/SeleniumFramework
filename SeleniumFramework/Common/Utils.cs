using OpenQA.Selenium;

namespace SeleniumFramework.Common
{
    public class Utils
    {
        /// <summary>
        /// Determines if an IMAGE is loaded.
        /// </summary>
        /// <param name="image">The IWebElement of the IMAGE tag.</param>
        /// <returns>true if the IMAGE is loaded, false otherwise.</returns>
        public static bool IsImageLoaded(IWebElement image)
        {
            return !image.GetAttribute("naturalWidth").Equals("0");
        }
    }
}