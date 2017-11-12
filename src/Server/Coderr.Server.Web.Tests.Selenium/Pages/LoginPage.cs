using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace codeRR.Server.Web.Tests.Selenium.Pages
{
    public class LoginPage
    {
        private readonly IWebDriver _webDriver;

        public LoginPage(IWebDriver webDriver)
        {
            _webDriver = webDriver;

            PageFactory.InitElements(_webDriver, this);

            // Always start clean
            _webDriver.Manage().Cookies.DeleteAllCookies();
        }

        [FindsBy(How = How.Id, Using = "login-button")]
        public IWebElement SignInButton { get; set; }

        [FindsBy(How = How.Id, Using = "Username")]
        public IWebElement UserNameField { get; set; }

        [FindsBy(How = How.Id, Using = "Password")]
        public IWebElement PasswordField { get; set; }

        public void LoginAsAdmin(string baseUrl)
        {
            _webDriver.Navigate().GoToUrl(baseUrl);

            UserNameField.Clear();
            UserNameField.SendKeys("joma");

            PasswordField.Clear();
            PasswordField.SendKeys("Abc123");

            SignInButton.Click();
        }
    }
}
