using System;
using FluentAssertions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace codeRR.Server.Web.Tests.Selenium.Pages
{
    public class LoginPage : BasePage
    {
        public LoginPage(IWebDriver webDriver) : base(webDriver, "Account/Login")
        {
        }

        [FindsBy(How = How.Id, Using = "login-button")]
        public IWebElement SignInButton { get; set; }

        [FindsBy(How = How.Id, Using = "Username")]
        public IWebElement UserNameField { get; set; }

        [FindsBy(How = How.Id, Using = "Password")]
        public IWebElement PasswordField { get; set; }

        public LoginPage LoginAsAdmin()
        {
            NavigateToPage();

            UserNameField.Clear();
            UserNameField.SendKeys("admin");

            PasswordField.Clear();
            PasswordField.SendKeys("admin");

            SignInButton.Click();

            return this;
        }

        public void VerifyLoggedIn()
        {
            WebDriver.Title.Should().Be("Overview");
        }
    }
}
