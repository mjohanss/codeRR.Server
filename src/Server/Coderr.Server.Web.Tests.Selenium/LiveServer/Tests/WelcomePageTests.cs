using codeRR.Server.Web.Tests.Selenium.LiveServer.Fixtures;
using codeRR.Server.Web.Tests.Selenium.LiveServer.Pages;
using Xunit;

namespace codeRR.Server.Web.Tests.Selenium.LiveServer.Tests
{
    [Collection("LiveServerCollection")]
    [Trait("Category", "Integration")]
    public class WelcomePageTests : TestBase
    {
        private readonly LiveServerFixture _fixture;

        public WelcomePageTests(LiveServerFixture fixture) : base(fixture.WebDriver)
        {
            _fixture = fixture;
        }

        [Fact]
        public void Should_be_able_to_click_create_organization()
        {
            UITest(() =>
            {
                var sut = new WelcomePage(_fixture.WebDriver, _fixture.UserName, _fixture.Password)
                        .CreateOrganization();

                sut.VerifyIsCurrentPage();
            });
        }
    }
}
