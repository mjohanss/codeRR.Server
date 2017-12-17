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

        private readonly string _userName;
        private readonly string _password;

        private const string Title = "Welcome - codeRR";

        public WelcomePage(IWebDriver webDriver, string userName, string password) : base(webDriver, "welcome")
        {
            _userName = userName;
            _password = password;
        }

        [FindsBy(How = How.XPath, Using = "//div[@data-href='/organization/create']")]
        public IWebElement CreateButton { get; set; }

        [Fact]
        public OrganizationCreatePage CreateOrganization()
        {
            var welcomePage = new LoginPage(WebDriver, _userName, _password)
                .LoginWithValidCredentials();

            welcomePage.VerifyIsCurrentPage();

            welcomePage.CreateButton.Click();

            return new OrganizationCreatePage(WebDriver, _userName, _password);
        }

        [Fact]
        public void VerifyIsCurrentPage()
        {
            Wait.Until(ExpectedConditions.TitleIs(Title));
        }
    }
}
