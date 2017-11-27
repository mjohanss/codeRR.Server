using System;
using System.IO;
using codeRR.Server.Web.Tests.Selenium;
using codeRR.Server.Web.Tests.Selenium.Fixtures;
using codeRR.Server.Web.Tests.Selenium.Helpers;
using codeRR.Server.Web.Tests.Selenium.Helpers.xUnit;
using codeRR.Server.Web.Tests.Selenium.Pages;
using Xunit;

namespace Coderr.Server.Web.Tests.Selenium
{
    [Collection("Selenium collection")]
    [Trait("Category", "Integration")]
    public class LoginPageTests : TestBase
    {
        private readonly SeleniumFixture _seleniumFixture;

        public LoginPageTests(SeleniumFixture seleniumFixture)
        {
            _seleniumFixture = seleniumFixture;
        }

        [Fact, TestPriority(0)]
        public void Should_be_able_to_create_account()
        {

        }

        [Fact, TestPriority(1)]
        public void Should_be_able_to_login_with_valid_credentials()
        {
            var sut = new LoginPage(_seleniumFixture.WebDriver)
                .LoginAsAdmin();

            sut.VerifyLoggedIn();
        }

        /*
                [Theory]
                [Browser(BrowserType.Chrome)]
                [Browser(BrowserType.InternetExplorer)]
                [Trait("Category", "UI")]
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
        */
    }
}
