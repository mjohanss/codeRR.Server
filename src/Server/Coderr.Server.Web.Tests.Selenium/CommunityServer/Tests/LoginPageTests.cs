using codeRR.Server.Web.Tests.Selenium.CommunityServer.Fixtures;
using codeRR.Server.Web.Tests.Selenium.CommunityServer.Pages;
using Xunit;

namespace codeRR.Server.Web.Tests.Selenium.CommunityServer.Tests
{
    [Collection("CommunityServerCollection")]
    [Trait("Category", "Integration")]
    public class LoginPageTests : CommunityServerTestBase
    {
        private readonly CommunityServerFixture _fixture;

        public LoginPageTests(CommunityServerFixture fixture) : base(fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public void Should_not_be_able_to_login_with_empty_username()
        {
            var sut = new LoginPage(_fixture.WebDriver)
                .LoginWithNoUserNameSpecified();

            Assert.IsType<LoginPage>(sut);
            sut.VerifyIsCurrentPage();
        }

        [Fact]
        public void Should_not_be_able_to_login_with_empty_password()
        {
            var sut = new LoginPage(_fixture.WebDriver)
                .LoginWithNoPasswordSpecified();

            Assert.IsType<LoginPage>(sut);
            sut.VerifyIsCurrentPage();
        }

        [Fact]
        public void Should_not_be_able_to_login_with_wrong_password()
        {
            var sut = new LoginPage(_fixture.WebDriver)
                .LoginWithWrongPasswordSpecified();

            Assert.IsType<LoginPage>(sut);
            sut.VerifyIsCurrentPage();
        }

        [Fact]
        public void Should_be_able_to_login_with_valid_credentials()
        {
            var sut = new LoginPage(_fixture.WebDriver)
                .LoginWithValidCredentials();

            Assert.IsType<HomePage>(sut);
            sut.VerifyIsCurrentPage();
        }
    }
}
