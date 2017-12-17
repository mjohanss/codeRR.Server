using codeRR.Server.Web.Tests.Selenium.LiveServer.Fixtures;
using log4net;
using OpenQA.Selenium.Support.UI;
using Xunit;

namespace codeRR.Server.Web.Tests.Selenium.LiveServer.Pages
{
    public class OrganizationCreatePage : BasePage
    {
        private readonly ILog _logger = LogManager.GetLogger(typeof(WelcomePage));

        private const string Title = "Create a new team - codeRR";

        public OrganizationCreatePage(LiveServerFixture fixture) : base(fixture, "organization/create")
        {
        }

        [Fact]
        public void VerifyIsCurrentPage()
        {
            Wait.Until(ExpectedConditions.TitleIs(Title));
        }
    }
}
