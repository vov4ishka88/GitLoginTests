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
		private By SignUpButtonSelector { get { return By.CssSelector("a[href=\"/join\"]"); } }
		private By SignUpPageSelector { get { return By.CssSelector("body.signup"); } }

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

		public bool SignUpPageExists()
		{
			return Helpers.IsElementPresent(driver, SignUpPageSelector);
		}

		public Login(IWebDriver driver)
		{
			this.driver = driver;
		}

		public void Submit()
		{
			driver.FindElement(PasswordFieldSelector).SendKeys(Keys.Return);
		}

		public void ClickOnSignUpButton()
		{
			driver.FindElement(SignUpButtonSelector).SendKeys(Keys.Return);
		}

	}
}
