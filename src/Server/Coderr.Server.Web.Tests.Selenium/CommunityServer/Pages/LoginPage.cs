using FluentAssertions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace codeRR.Server.Web.Tests.Selenium.CommunityServer.Pages
{
    public class LoginPage : BasePage
    {
        private const string UserName = "admin";
        private const string Password = "admin";

        public LoginPage(IWebDriver webDriver) : base(webDriver, "Account/Login")
        {
        }

        [FindsBy(How = How.Id, Using = "login-button")]
        public IWebElement SignInButton { get; set; }

        [FindsBy(How = How.Id, Using = "Username")]
        public IWebElement UserNameField { get; set; }

        [FindsBy(How = How.Id, Using = "Password")]
        public IWebElement PasswordField { get; set; }

        public HomePage LoginAsAdmin()
        {
            NavigateToPage();

            UserNameField.Clear();
            UserNameField.SendKeys(UserName);

            PasswordField.Clear();
            PasswordField.SendKeys(Password);

            SignInButton.Click();

            return new HomePage(WebDriver);
        }

        public LoginPage LoginWithNoUserNameSpecified()
        {
            NavigateToPage();

            UserNameField.Clear();

            PasswordField.Clear();
            PasswordField.SendKeys(Password);

            SignInButton.Click();

            return this;
        }

        public LoginPage LoginWithNoPasswordSpecified()
        {
            NavigateToPage();

            UserNameField.Clear();
            UserNameField.SendKeys(UserName);

            PasswordField.Clear();

            SignInButton.Click();

            return this;
        }

        public void VerifyIsCurrentPage()
        {
            Wait.Until(ExpectedConditions.TitleIs("Login - codeRR"));

            WebDriver.Title.Should().Be("Login - codeRR");
        }
    }
}
