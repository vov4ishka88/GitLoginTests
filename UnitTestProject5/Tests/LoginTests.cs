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
			//init
			driver = new FirefoxDriver();
			driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
			driver.Url = "https://github.com/session";
			loginPage = new Login(driver);
		}

		[TestCleanup]
		public void TestCleanUp()
		{	
			//clearing up
			driver.Quit();
			driver.Dispose();
		}

		[TestMethod]
		public void InvalidCredentialsLeadToErrorPage()
		{
			//act
			loginPage.LoginField = "notvalid@gmail.com";
			loginPage.PasswordField = "lalala";
			loginPage.Submit();
			
			//assert
			Assert.IsTrue(loginPage.ErrorMessageExists());
		}

		[TestMethod]
		public void ClickingSignUpLeadsToSignUpPage()
		{
			//act
			loginPage.ClickOnSignUpButton();
			
			//assert
			Assert.IsTrue(loginPage.SignUpPageExists());
		}
	}
}
