using codeRR.Server.Web.Tests.Selenium.CommunityServer.Fixtures;
using codeRR.Server.Web.Tests.Selenium.CommunityServer.Pages;
using codeRR.Server.Web.Tests.Selenium.LiveServer.Pages;
using OpenQA.Selenium;
using Xunit;
using LoginPage = codeRR.Server.Web.Tests.Selenium.CommunityServer.Pages.LoginPage;

namespace codeRR.Server.Web.Tests.Selenium.CommunityServer.Tests
{
    public class CommunityServerTestBase : TestBase
    {
        protected CommunityServerFixture Fixture { get; }

        public CommunityServerTestBase(CommunityServerFixture fixture) : base(fixture.WebDriver)
        {
            Fixture = fixture;
        }

        public HomePage Login()
        {
            var page = new LoginPage(Fixture.WebDriver)
                .LoginWithValidCredentials();

            Assert.IsType<HomePage>(page);

            page.VerifyIsCurrentPage();

            return page;
        }
    }
}
