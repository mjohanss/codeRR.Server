using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace codeRR.Server.Web.Tests.Selenium.Pages
{
    public class BasePage
    {
        protected IWebDriver _driver;

        public BasePage(IWebDriver driver)
        {
            _driver = driver;

            PageFactory.InitElements(_driver, this);

            //_driver.Manage().Cookies.DeleteAllCookies();
        }

        public void Close()
        {
            _driver.Close();
            _driver.Dispose();
        }
    }
}
