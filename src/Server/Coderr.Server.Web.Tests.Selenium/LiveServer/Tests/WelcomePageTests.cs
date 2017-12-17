using codeRR.Server.Web.Tests.Selenium.LiveServer.Fixtures;
using codeRR.Server.Web.Tests.Selenium.LiveServer.Pages;
using Xunit;

namespace codeRR.Server.Web.Tests.Selenium.LiveServer.Tests
{
    [Collection("LiveServerCollection")]
    [Trait("Category", "Integration")]
    public class WelcomePageTests : LiveServerTestBase
    {
        public WelcomePageTests(LiveServerFixture fixture) : base(fixture)
        {
        }

        [Fact]
        public void Should_be_able_to_click_create_organization()
        {
            UITest(() =>
            {
                var sut = new WelcomePage(Fixture)
                        .CreateOrganization();

                sut.VerifyIsCurrentPage();
            });
        }
    }
}
