using System;
using System.Text;
using codeRR.Server.Web.Tests.Selenium.Pages;
using codeRR.Server.Web.Tests.Selenium.SeleniumHelpers;
using OpenQA.Selenium;
using Xunit;

namespace Coderr.Server.Web.Tests.Selenium
{
    public class LoginPageTests : IDisposable
    {
        private readonly IWebDriver _driver;
        private StringBuilder _verificationErrors;
        private readonly string _baseUrl;

        public LoginPageTests()
        {
            _driver = new DriverFactory().Create(Browser.Chrome);
            _baseUrl = "http://stargate.soderby.local/codeRR";
            _verificationErrors = new StringBuilder();
        }

        [Fact]
        public void Should_be_able_to_login_with_valid_credentials_using_Chrome()
        {
            new LoginPage(_driver).LoginAsAdmin(_baseUrl);
        }

        public void Dispose()
        {
            try
            {
                _driver.Quit();
                _driver.Close();
            }
            // ReSharper disable once EmptyGeneralCatchClause
            catch
            {
            }
        }
    }
}
