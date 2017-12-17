using codeRR.Server.Web.Tests.Selenium.Helpers.xUnit;
using codeRR.Server.Web.Tests.Selenium.LiveServer.Fixtures;
using codeRR.Server.Web.Tests.Selenium.LiveServer.Pages;
using Xunit;

namespace codeRR.Server.Web.Tests.Selenium.LiveServer.Tests
{
    [Collection("LiveServerCollection")]
    [Trait("Category", "Integration")]
    public class LoginPageTests : TestBase
    {
        private readonly LiveServerFixture _fixture;

        public LoginPageTests(LiveServerFixture fixture) : base(fixture.WebDriver)
        {
            _fixture = fixture;
        }

        [Fact]
        [TestPriority(10)]
        public void Should_not_be_able_to_login_with_empty_username()
        {
            UITest(() =>
            {
                var sut = new LoginPage(_fixture.WebDriver, _fixture.UserName, _fixture.Password)
                    .LoginWithNoUserNameSpecified();

                sut.VerifyIsCurrentPage();
            });
        }

        [Fact]
        [TestPriority(10)]
        public void Should_not_be_able_to_login_with_empty_password()
        {
            UITest(() =>
            {
                var sut = new LoginPage(_fixture.WebDriver, _fixture.UserName, _fixture.Password)
                    .LoginWithNoPasswordSpecified();

                sut.VerifyIsCurrentPage();
            });
        }

        [Fact]
        [TestPriority(20)]
        public void Should_be_able_to_login_with_valid_credentials()
        {
            UITest(() =>
            {
                var sut = new LoginPage(_fixture.WebDriver, _fixture.UserName, _fixture.Password)
                    .LoginWithValidCredentials();

                sut.VerifyIsCurrentPage();
            });
        }
    }
}
