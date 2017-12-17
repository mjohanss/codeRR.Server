using codeRR.Server.Web.Tests.Selenium.LiveServer.Fixtures;
using codeRR.Server.Web.Tests.Selenium.LiveServer.Pages;
using Xunit;

namespace codeRR.Server.Web.Tests.Selenium.LiveServer.Tests
{
    [Collection("LiveServerCollection")]
    [Trait("Category", "Integration")]
    public class OrganizationCreatePageTests : LiveServerTestBase
    {
        public OrganizationCreatePageTests(LiveServerFixture fixture) : base(fixture)
        {
        }

        [Fact]
        public void Should_be_able_to_create_new_organization()
        {
            UITest(() =>
            {
                Login();

                var sut = new WelcomePage(Fixture)
                        .CreateOrganization();

                sut.VerifyPageLoaded();

                var result = sut.CreateOrganization("DummyOrganization");

                result.VerifyPageLoaded();

                Logout();
            });
        }
    }
}
