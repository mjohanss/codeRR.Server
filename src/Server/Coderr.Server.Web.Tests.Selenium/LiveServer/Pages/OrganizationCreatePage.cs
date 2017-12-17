using codeRR.Server.Web.Tests.Selenium.LiveServer.Fixtures;
using log4net;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace codeRR.Server.Web.Tests.Selenium.LiveServer.Pages
{
    public class OrganizationCreatePage : BasePage
    {
        private readonly ILog _logger = LogManager.GetLogger(typeof(OrganizationCreatePage));

        public OrganizationCreatePage(LiveServerFixture fixture) : base(fixture, "organization/create", "Create a new team - codeRR")
        {
        }

        [FindsBy(How = How.ClassName, Using = "btn-primary")]
        public IWebElement CreateButton { get; set; }

        [FindsBy(How = How.Id, Using = "Name")]
        public IWebElement CompanyNameField { get; set; }

        public ConfigureApplicationPage CreateOrganization(string name)
        {
            CompanyNameField.Clear();
            CompanyNameField.SendKeys(name);

            CreateButton.Click();

            return new ConfigureApplicationPage(Fixture);
        }
    }
}
