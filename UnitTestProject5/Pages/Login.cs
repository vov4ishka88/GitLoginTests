using Git.Tests;
using OpenQA.Selenium;

namespace UnitTestProject5.Pages
{
    class Login
    {
        private IWebDriver driver;
        private By LoginFieldSelector { get { return By.Id("login_field"); } }
        private By PasswordFieldSelector { get { return By.Id("password"); } }
        private By ErrorMessagSelector { get { return By.ClassName("flash-error"); } }

        public string LoginField
        {
            get { return driver.FindElement(LoginFieldSelector).Text; }
            set { driver.FindElement(LoginFieldSelector).SendKeys(value); }
        }

        public string PasswordField
        {
            set { driver.FindElement(PasswordFieldSelector).SendKeys(value); }
        }

        public bool ErrorMessageExists()
        {
            return Helpers.IsElementPresent(driver, ErrorMessagSelector);
        }

        public Login(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void Submit()
        {
            driver.FindElement(PasswordFieldSelector).SendKeys(Keys.Return);
        }
    }
}
