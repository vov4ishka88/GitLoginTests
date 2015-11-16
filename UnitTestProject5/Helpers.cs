using OpenQA.Selenium;

namespace Git.Tests
{
    static class Helpers
    {
        public static bool IsElementPresent(IWebDriver driver, By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    }
}
