using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace codeRR.Server.Web.Tests.Selenium.CommunityServer.Pages
{
    public class IncidentsPage : BasePage
    {
        public IncidentsPage(IWebDriver webDriver, int id) : base(webDriver, "#/application/{id}/incidents/")
        {
            Url = Url.Replace("{id}", id.ToString());
        }

        [FindsBy(How = How.Id, Using = "pageTitle")]
        public IWebElement PageTitle { get; set; }

        public void VerifyIsCurrentPage()
        {
            Wait.Until(ExpectedConditions.TitleIs("Incidents"));
        }

        public void VerifyIncidentReported()
        {
            var by = By.PartialLinkText("Value cannot be null");
            //var element = WebDriver.FindElement(by);
            Wait.Until(ExpectedConditions.ElementExists(by));
        }
    }
}
