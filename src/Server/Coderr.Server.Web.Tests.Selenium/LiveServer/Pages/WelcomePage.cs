using codeRR.Server.Web.Tests.Selenium.LiveServer.Fixtures;
using log4net;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace codeRR.Server.Web.Tests.Selenium.LiveServer.Pages
{
    public class WelcomePage : BasePage
    {
        private readonly ILog _logger = LogManager.GetLogger(typeof(WelcomePage));

        public WelcomePage(LiveServerFixture fixture) : base(fixture, "welcome", "Welcome - codeRR")
        {
        }

        [FindsBy(How = How.XPath, Using = "//div[@data-href='/organization/create']")]
        public IWebElement CreateButton { get; set; }

        public OrganizationCreatePage CreateOrganization()
        {
            CreateButton.Click();

            return new OrganizationCreatePage(Fixture);
        }
    }
}
