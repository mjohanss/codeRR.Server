using FluentAssertions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace codeRR.Server.Web.Tests.Selenium.CommunityServer.Pages
{
    public class HomePage : BasePage
    {
        public HomePage(IWebDriver webDriver) : base(webDriver, "/")
        {
        }

        public void VerifyIsCurrentPage()
        {
            Wait.Until(ExpectedConditions.TitleIs("Overview"));

            WebDriver.Title.Should().Be("Overview");
        }
    }
}
