using codeRR.Server.Web.Tests.Selenium.LiveServer.Fixtures;
using log4net;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using Xunit;

namespace codeRR.Server.Web.Tests.Selenium.LiveServer.Pages
{
    public class WelcomePage : BasePage
    {
        private readonly ILog _logger = LogManager.GetLogger(typeof(WelcomePage));

        private const string Title = "Welcome - codeRR";

        public WelcomePage(LiveServerFixture fixture) : base(fixture, "welcome")
        {
        }

        [FindsBy(How = How.XPath, Using = "//div[@data-href='/organization/create']")]
        public IWebElement CreateButton { get; set; }

        [Fact]
        public OrganizationCreatePage CreateOrganization()
        {
            var welcomePage = new LoginPage(Fixture)
                .LoginWithValidCredentials();

            welcomePage.VerifyIsCurrentPage();

            welcomePage.CreateButton.Click();

            return new OrganizationCreatePage(Fixture);
        }

        [Fact]
        public void VerifyIsCurrentPage()
        {
            Wait.Until(ExpectedConditions.TitleIs(Title));
        }
    }
}
