using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using Xunit;

namespace codeRR.Server.Web.Tests.Selenium.Pages
{
    public class BasePage
    {
        protected IWebDriver WebDriver;
        protected string BaseUrl { get; }
        protected string Url { get; }

        public BasePage(IWebDriver webDriver, string url)
        {
            WebDriver = webDriver;

            BaseUrl = "http://localhost:50473/coderr/";

            Url = new Uri(new Uri(BaseUrl), url).ToString();

            PageFactory.InitElements(WebDriver, this);
        }

        public void NavigateToPage()
        {
            WebDriver.Navigate().GoToUrl(Url);

            var wait = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(2000));
            wait.Until(ExpectedConditions.UrlMatches(Url));

            Assert.Equal(Url, WebDriver.Url);
        }

        public void DeleteCookies()
        {
            WebDriver.Manage().Cookies.DeleteAllCookies();
        }

        public void Close()
        {
            WebDriver.Close();
            WebDriver.Dispose();
        }
    }
}
