using codeRR.Server.Web.Tests.Selenium.LiveServer.Fixtures;

namespace codeRR.Server.Web.Tests.Selenium.LiveServer.Pages
{
    public class LogoutPage : BasePage
    {
        public LogoutPage(LiveServerFixture fixture) : base(fixture, "Account/Logout", string.Empty)
        {
        }

        public LoginPage Logout()
        {
            NavigateToPage();

            return new LoginPage(Fixture);
        }
    }
}
