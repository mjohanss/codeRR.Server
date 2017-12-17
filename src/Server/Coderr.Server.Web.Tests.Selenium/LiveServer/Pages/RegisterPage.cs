using log4net;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace codeRR.Server.Web.Tests.Selenium.LiveServer.Pages
{
    public class RegisterPage : BasePage
    {
        private readonly ILog _logger = LogManager.GetLogger(typeof(RegisterPage));

        private readonly string _userName;
        private readonly string _userNameRegister;
        private readonly string _password;
        private const string Title = "Register - codeRR lobby";

        public RegisterPage(IWebDriver webDriver, string userName, string password) : base(webDriver, "Account/Register")
        {
            _userName = userName;
            _password = password;

            _userNameRegister = userName.Replace("testuser.", "testuser2.");
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
            _logger.Info($"Registering user '{_userName}'");

            DeleteCookies();

            NavigateToPage();

            EMailField.Clear();
            EMailField.SendKeys(_userName);

            PasswordField.Clear();
            PasswordField.SendKeys(_password);

            ConfirmPasswordField.Clear();
            ConfirmPasswordField.SendKeys(_password);

            RegisterButton.Click();

            return new WelcomePage(WebDriver, _userName, _password);
        }

        public WelcomePage RegisterUser()
        {
            DeleteCookies();

            NavigateToPage();

            EMailField.Clear();
            EMailField.SendKeys(_userNameRegister);

            PasswordField.Clear();
            PasswordField.SendKeys(_password);

            ConfirmPasswordField.Clear();
            ConfirmPasswordField.SendKeys(_password);

            RegisterButton.Click();

            return new WelcomePage(WebDriver, _userName, _password);
        }

        public RegisterPage RegisterUserThatAlreadyExists()
        {
            DeleteCookies();

            NavigateToPage();

            EMailField.Clear();
            EMailField.SendKeys(_userName);

            PasswordField.Clear();
            PasswordField.SendKeys(_password);

            ConfirmPasswordField.Clear();
            ConfirmPasswordField.SendKeys(_password);

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
            EMailField.SendKeys(_userName);

            PasswordField.Clear();

            RegisterButton.Click();

            return this;
        }

        public RegisterPage RegisterWithPasswordsNotMatching()
        {
            NavigateToPage();

            EMailField.Clear();
            EMailField.SendKeys(_userName);

            PasswordField.Clear();
            PasswordField.SendKeys(_password);

            ConfirmPasswordField.Clear();
            ConfirmPasswordField.SendKeys(_password + "11");

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
