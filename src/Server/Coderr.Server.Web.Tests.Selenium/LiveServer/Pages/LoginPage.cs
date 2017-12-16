using FluentAssertions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace codeRR.Server.Web.Tests.Selenium.LiveServer.Pages
{
    public class LoginPage : BasePage
    {
        private readonly string _userName;
        private readonly string _password;
        private const string Title = "Log in - codeRR lobby";

        public LoginPage(IWebDriver webDriver, string userName, string password) : base(webDriver, "Account/Login")
        {
            _userName = userName;
            _password = password;
        }

        [FindsBy(How = How.ClassName, Using = "btn-primary")]
        public IWebElement LogInButton { get; set; }

        [FindsBy(How = How.Id, Using = "Email")]
        public IWebElement UserNameField { get; set; }

        [FindsBy(How = How.Id, Using = "Password")]
        public IWebElement PasswordField { get; set; }

        public LoginPage LoginWithValidCredentials()
        {
            NavigateToPage();

            UserNameField.Clear();
            UserNameField.SendKeys(_userName);

            PasswordField.Clear();
            PasswordField.SendKeys(_password);

            LogInButton.Click();

            return this;
        }

        public LoginPage LoginWithNoUserNameSpecified()
        {
            NavigateToPage();

            UserNameField.Clear();

            PasswordField.Clear();
            PasswordField.SendKeys(_password);

            LogInButton.Click();

            return this;
        }

        public LoginPage LoginWithNoPasswordSpecified()
        {
            NavigateToPage();

            UserNameField.Clear();
            UserNameField.SendKeys(_userName);

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
