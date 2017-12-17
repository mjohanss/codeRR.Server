using log4net;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Xunit;

namespace codeRR.Server.Web.Tests.Selenium.LiveServer.Pages
{
    public class OrganizationCreatePage : BasePage
    {
        private readonly ILog _logger = LogManager.GetLogger(typeof(WelcomePage));

        private readonly string _userName;
        private readonly string _password;

        private const string Title = "Create a new team - codeRR";

        public OrganizationCreatePage(IWebDriver webDriver, string userName, string password) : base(webDriver, "organization/create")
        {
            _userName = userName;
            _password = password;
        }

        [Fact]
        public void VerifyIsCurrentPage()
        {
            Wait.Until(ExpectedConditions.TitleIs(Title));
        }
    }
}
