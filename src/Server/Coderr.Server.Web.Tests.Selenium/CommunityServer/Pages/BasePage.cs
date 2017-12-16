using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using Xunit;

namespace codeRR.Server.Web.Tests.Selenium.CommunityServer.Pages
{
    public class BasePage
    {
        protected IWebDriver WebDriver;
        protected WebDriverWait Wait;
        protected string BaseUrl { get; }
        protected string Url { get; }

        public BasePage(IWebDriver webDriver, string url)
        {
            WebDriver = webDriver;

            Wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(3));

            BaseUrl = "http://localhost:50473/coderr/";

            Url = new Uri(new Uri(BaseUrl), url).ToString();

            PageFactory.InitElements(WebDriver, this);
        }

        public void NavigateToPage()
        {
            WebDriver.Navigate().GoToUrl(Url);

            Wait.Until(ExpectedConditions.UrlMatches(Url));

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
