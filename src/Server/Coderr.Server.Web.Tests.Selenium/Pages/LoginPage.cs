using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace codeRR.Server.Web.Tests.Selenium.Pages
{
    public class LoginPage : BasePage
    {
        public LoginPage(IWebDriver driver) : base(driver)
        {
        }

        [FindsBy(How = How.Id, Using = "login-button")]
        public IWebElement SignInButton { get; set; }

        [FindsBy(How = How.Id, Using = "Username")]
        public IWebElement UserNameField { get; set; }

        [FindsBy(How = How.Id, Using = "Password")]
        public IWebElement PasswordField { get; set; }

        public LoginPage LoginAsAdmin(string baseUrl)
        {
            _driver.Navigate().GoToUrl(baseUrl + "/Account/Login");

            UserNameField.Clear();
            UserNameField.SendKeys("joma");

            PasswordField.Clear();
            PasswordField.SendKeys("Abc123");

            SignInButton.Click();

            return this;
        }
    }
}
