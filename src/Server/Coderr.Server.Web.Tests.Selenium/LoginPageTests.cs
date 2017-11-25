using System;
using System.Text;
using canopy;
using codeRR.Server.Web.Tests.Selenium.Pages;
using codeRR.Server.Web.Tests.Selenium.SeleniumHelpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Xunit;
using _ = canopy.csharp.canopy;

namespace Coderr.Server.Web.Tests.Selenium
{
    public class LoginPageTests : IDisposable
    {
        private readonly IWebDriver _driver;
        private StringBuilder _verificationErrors;
        private readonly string _baseUrl;

        public LoginPageTests()
        {
            //_driver = DriverFactory.Create(BrowserType.Chrome);
            _baseUrl = "http://stargate.soderby.local/codeRR";
            _verificationErrors = new StringBuilder();
        }

        [Theory]
        [Browser(BrowserType.Chrome)]
        [Browser(BrowserType.InternetExplorer)]
        public void Should_be_able_to_login_with_valid_credentials(IWebDriver driver)
        {
            var sut = new LoginPage(driver)
                    .LoginAsAdmin(_baseUrl);

            Assert.Equal("Overview", driver.Title);
        }

        [Theory]
        [Browser(BrowserType.Chrome)]
        public void Canopy_test(IWebDriver driver)
        {
            _.switchTo(driver);

            _.test("clearing #firstName sets text to new empty string via IWebElement", () =>
            {
                _.url(_baseUrl + "/Account/Login");
                _.clear(_.element("#Username"));
                _.eq("#Username", "");
            });
            _.run();

            Assert.True(canopy.runner.failedCount == 0);

            _.quit();
        }

        public void Dispose()
        {
            try
            {
                //_driver.Quit();
                //_driver.Close();
            }
            // ReSharper disable once EmptyGeneralCatchClause
            catch
            {
            }
        }
    }
}
