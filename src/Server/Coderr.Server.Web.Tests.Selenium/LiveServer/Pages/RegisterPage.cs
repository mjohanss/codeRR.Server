using codeRR.Server.Web.Tests.Selenium.LiveServer.Fixtures;
using log4net;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace codeRR.Server.Web.Tests.Selenium.LiveServer.Pages
{
    public class RegisterPage : BasePage
    {
        private readonly ILog _logger = LogManager.GetLogger(typeof(RegisterPage));

        private readonly string _userNameRegister;

        public RegisterPage(LiveServerFixture fixture) : base(fixture, "Account/Register", "Register - codeRR lobby")
        {
            _userNameRegister = UserName.Replace("testuser.", "testuser2.");
        }

        [FindsBy(How = How.ClassName, Using = "btn-primary")]
        public IWebElement RegisterButton { get; set; }

        [FindsBy(How = How.Id, Using = "Email")]
        public IWebElement EMailField { get; set; }

        [FindsBy(How = How.Id, Using = "Password")]
        public IWebElement PasswordField { get; set; }

        [FindsBy(How = How.Id, Using = "ConfirmPassword")]
        public IWebElement ConfirmPasswordField { get; set; }

        public WelcomePage RegisterUserStartup()
        {
            _logger.Info($"Registering user '{UserName}'");

            DeleteCookies();

            NavigateToPage();

            EMailField.Clear();
            EMailField.SendKeys(UserName);

            PasswordField.Clear();
            PasswordField.SendKeys(Password);

            ConfirmPasswordField.Clear();
            ConfirmPasswordField.SendKeys(Password);

            RegisterButton.Click();

            return new WelcomePage(Fixture);
        }

        public WelcomePage RegisterUser()
        {
            DeleteCookies();

            NavigateToPage();

            EMailField.Clear();
            EMailField.SendKeys(_userNameRegister);

            PasswordField.Clear();
            PasswordField.SendKeys(Password);

            ConfirmPasswordField.Clear();
            ConfirmPasswordField.SendKeys(Password);

            RegisterButton.Click();

            return new WelcomePage(Fixture);
        }

        public RegisterPage RegisterUserThatAlreadyExists()
        {
            DeleteCookies();

            NavigateToPage();

            EMailField.Clear();
            EMailField.SendKeys(UserName);

            PasswordField.Clear();
            PasswordField.SendKeys(Password);

            ConfirmPasswordField.Clear();
            ConfirmPasswordField.SendKeys(Password);

            RegisterButton.Click();

            return this;
        }

        public RegisterPage RegisterWithNoEMailSpecified()
        {
            NavigateToPage();

            EMailField.Clear();

            PasswordField.Clear();

            RegisterButton.Click();

            return this;
        }

        public RegisterPage RegisterWithNoPasswordSpecified()
        {
            NavigateToPage();

            EMailField.Clear();
            EMailField.SendKeys(UserName);

            PasswordField.Clear();

            RegisterButton.Click();

            return this;
        }

        public RegisterPage RegisterWithPasswordsNotMatching()
        {
            NavigateToPage();

            EMailField.Clear();
            EMailField.SendKeys(UserName);

            PasswordField.Clear();
            PasswordField.SendKeys(Password);

            ConfirmPasswordField.Clear();
            ConfirmPasswordField.SendKeys(Password + "11");

            RegisterButton.Click();

            return this;
        }

        public void VerifyRequireEMail()
        {
            Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[@data-valmsg-for='Email']")));
        }

        public void VerifyRequirePassword()
        {
            Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[@data-valmsg-for='Password']")));
        }

        public void VerifyPasswordsNotMatchingPasswords()
        {
            Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[@data-valmsg-for='ConfirmPassword']")));
        }

        public void VerifyRegisterUser()
        {
            Wait.Until(driver => !driver.Url.Contains("Account/Register"));
        }

        public void VerifyRegisterUserThatAlreadyExists()
        {
            Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@data-valmsg-summary='true']")));
        }
    }
}
