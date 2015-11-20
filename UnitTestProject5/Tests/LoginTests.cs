using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using UnitTestProject5.Pages;

namespace Git.Tests
{
    [TestClass]
    public class GitLoginTests
    {
        IWebDriver driver;

        Login loginPage;

        [TestInitialize]
        public void TestInitialize()
        {
            driver = new FirefoxDriver();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            driver.Url = "https://github.com/session";

            loginPage = new Login(driver);
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
            loginPage.LoginField = "notvalid@gmail.com";
            loginPage.PasswordField = "lalala";

            loginPage.Submit();
            
            // assert
            Assert.IsTrue(loginPage.ErrorMessageExists());
        }

        [TestMethod]
        public void ClickingSignUpLeadsToSignUpPage()
        {
            // init

            // act
            // IWebElement signUp = driver.FindElement(By.CssSelector("a[href=\"/join\"]"));
						loginPage.ClickOnSignUpButton();
            //signUp.Click();

            // assert
            //Assert.IsTrue(Helpers.IsElementPresent(driver, By.CssSelector("body.signup")));
						Assert.IsTrue(loginPage.SignUpPageExists());
        }
    }
}
