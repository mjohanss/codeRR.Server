using codeRR.Server.Web.Tests.Selenium.LiveServer.Fixtures;
using FluentAssertions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace codeRR.Server.Web.Tests.Selenium.LiveServer.Pages
{
    public class LoginPage : BasePage
    {
        private const string Title = "Log in - codeRR lobby";

        public LoginPage(LiveServerFixture fixture) : base(fixture, "Account/Login")
        {
        }

        [FindsBy(How = How.ClassName, Using = "btn-primary")]
        public IWebElement LogInButton { get; set; }

        [FindsBy(How = How.Id, Using = "Email")]
        public IWebElement UserNameField { get; set; }

        [FindsBy(How = How.Id, Using = "Password")]
        public IWebElement PasswordField { get; set; }

        public WelcomePage LoginWithValidCredentials()
        {
            NavigateToPage();

            UserNameField.Clear();
            UserNameField.SendKeys(UserName);

            PasswordField.Clear();
            PasswordField.SendKeys(Password);

            LogInButton.Click();

            return new WelcomePage(Fixture);
        }

        public LoginPage LoginWithNoUserNameSpecified()
        {
            NavigateToPage();

            UserNameField.Clear();

            PasswordField.Clear();
            PasswordField.SendKeys(Password);

            LogInButton.Click();

            return this;
        }

        public LoginPage LoginWithNoPasswordSpecified()
        {
            NavigateToPage();

            UserNameField.Clear();
            UserNameField.SendKeys(UserName);

            PasswordField.Clear();

            LogInButton.Click();

            return this;
        }

        public void VerifyIsCurrentPage()
        {
            Wait.Until(ExpectedConditions.TitleIs(Title));

            WebDriver.Title.Should().Be(Title);
        }
    }
}
