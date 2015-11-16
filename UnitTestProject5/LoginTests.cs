using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace UnitTestProject5
{
    [TestClass]
    public class FacebookLoginTests
    {
        IWebDriver driver;

        [TestInitialize]
        public void TestInitialize()
        {
            driver = new FirefoxDriver();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            driver.Url = "https://github.com/session";
        }

        [TestCleanup]
        public void TestCleanUp()
        {
            driver.Quit();
            driver.Dispose();
        }

        [TestMethod]
        public void InvalidCredentialsLeadToErrorPage()
        {
            // init

            // act
            var emailTextBox = driver.FindElement(By.Id("login_field"));
            var passwordTextBox = driver.FindElement(By.Id("password"));

            emailTextBox.SendKeys("notValid@gmail.com");
            passwordTextBox.SendKeys("lalala");

            passwordTextBox.SendKeys(Keys.Return);

            // assert
            Assert.IsTrue(Helpers.IsElementPresent(driver, By.ClassName("flash-error")));
        }

        [TestMethod]
        public void ClickingSignUpLeadsToSignUpPage()
        {
            // init

            // act
            IWebElement signUp = driver.FindElement(By.CssSelector("a[href=\"/join\"]"));
            signUp.Click();

            // assert
            Assert.IsTrue(Helpers.IsElementPresent(driver, By.ClassName("signup")));
        }
    }
}
