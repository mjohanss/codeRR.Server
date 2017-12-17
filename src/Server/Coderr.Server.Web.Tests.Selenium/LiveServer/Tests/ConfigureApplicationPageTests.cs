using codeRR.Server.Web.Tests.Selenium.LiveServer.Fixtures;
using codeRR.Server.Web.Tests.Selenium.LiveServer.Pages;
using Xunit;

namespace codeRR.Server.Web.Tests.Selenium.LiveServer.Tests
{
    [Collection("LiveServerCollection")]
    [Trait("Category", "Integration")]
    public class ConfigureApplicationPageTests : LiveServerTestBase
    {
        public ConfigureApplicationPageTests(LiveServerFixture fixture) : base(fixture)
        {
        }

        [Fact]
        public void Should_be_able_to_create_new_application()
        {
            UITest(() =>
            {
                Login();

                var organizationCreatePage = new WelcomePage(Fixture)
                        .CreateOrganization();

                organizationCreatePage.VerifyPageLoaded();

                var configureApplicationPage = organizationCreatePage.CreateOrganization("DummyOrganization2");

                configureApplicationPage.VerifyPageLoaded();

                var sut = configureApplicationPage.CreateApplication("DummyApplication");

                sut.VerifyPageLoaded();

                Logout();
            });
        }
    }
}
