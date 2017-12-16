using codeRR.Server.Web.Tests.Selenium.CommunityServer.Fixtures;
using codeRR.Server.Web.Tests.Selenium.CommunityServer.Pages;
using codeRR.Server.Web.Tests.Selenium.Helpers.xUnit;
using Xunit;

namespace codeRR.Server.Web.Tests.Selenium.CommunityServer.Tests
{
    [Collection("CommunityServerCollection")]
    [Trait("Category", "Integration")]
    public class LoginPageTests : TestBase
    {
        private readonly CommunityServerFixture _fixture;

        public LoginPageTests(CommunityServerFixture fixture) : base(fixture.WebDriver)
        {
            _fixture = fixture;
        }

        [Fact]
        [TestPriority(15)]
        public void Should_not_be_able_to_login_with_empty_username()
        {
            var sut = new LoginPage(_fixture.WebDriver)
                .LoginWithNoUserNameSpecified();

            sut.VerifyIsCurrentPage();
        }

        [Fact]
        [TestPriority(15)]
        public void Should_not_be_able_to_login_with_empty_password()
        {
            var sut = new LoginPage(_fixture.WebDriver)
                .LoginWithNoPasswordSpecified();

            sut.VerifyIsCurrentPage();
        }

        [Fact]
        [TestPriority(10)]
        public void Should_be_able_to_create_account()
        {

        }

        [Fact]
        [TestPriority(20)]
        public void Should_be_able_to_login_with_valid_credentials()
        {
            var sut = new LoginPage(_fixture.WebDriver)
                .LoginAsAdmin();

            sut.VerifyIsCurrentPage();
        }

        //[Theory]
        //[Browser(BrowserType.Chrome)]
        //[Browser(BrowserType.InternetExplorer)]
        //[Trait("Category", "UI")]
        //public void Should_be_able_to_login_with_valid_credentials(IWebDriver driver)
        //{
        //    var sut = new LoginPage(driver)
        //            .LoginAsAdmin(_baseUrl);

        //    Assert.Equal("Overview", driver.Title);
        //}

        //[Theory]
        //[Browser(BrowserType.Chrome)]
        //public void Canopy_test(IWebDriver driver)
        //{
        //    _.switchTo(driver);

        //    _.test("clearing #firstName sets text to new empty string via IWebElement", () =>
        //    {
        //        _.url(_baseUrl + "/Account/Login");
        //        _.clear(_.element("#Username"));
        //        _.eq("#Username", "");
        //    });
        //    _.run();

        //    Assert.True(canopy.runner.failedCount == 0);

        //    _.quit();
        //}
    }
}
