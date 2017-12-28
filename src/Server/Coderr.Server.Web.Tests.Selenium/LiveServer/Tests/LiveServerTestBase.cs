using codeRR.Server.Web.Tests.Selenium.LiveServer.Fixtures;
using codeRR.Server.Web.Tests.Selenium.LiveServer.Pages;
using Xunit;

namespace codeRR.Server.Web.Tests.Selenium.LiveServer.Tests
{
    public class LiveServerTestBase : TestBase
    {
        protected LiveServerFixture Fixture { get; }

        public LiveServerTestBase(LiveServerFixture fixture) : base(fixture.WebDriver)
        {
            Fixture = fixture;
        }
        
        public WelcomePage Login()
        {
            var page = new LoginPage(Fixture)
                .LoginWithValidCredentials();

            Assert.IsType<WelcomePage>(page);

            page.VerifyPageLoaded();

            return page;
        }

        public LoginPage Logout()
        {
            var page = new LogoutPage(Fixture)
                .Logout();

            page.VerifyPageLoaded();

            return page;
        }
    }
}
