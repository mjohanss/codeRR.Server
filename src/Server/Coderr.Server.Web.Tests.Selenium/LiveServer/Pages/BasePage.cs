using System;
using System.Configuration;
using System.IO;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using Xunit;

namespace codeRR.Server.Web.Tests.Selenium.LiveServer.Pages
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

            Wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(10));

            BaseUrl = ConfigurationManager.AppSettings["LiveServerUrl"];
            if (BaseUrl.EndsWith("/") == false)
                BaseUrl += "/";

            Url = new Uri(new Uri(BaseUrl), url).ToString();

            PageFactory.InitElements(WebDriver, this);
        }

        public void NavigateToPage()
        {
            WebDriver.Navigate().GoToUrl(Url);

            Wait.Until(ExpectedConditions.UrlMatches(Url));

            Assert.Equal(Url, WebDriver.Url);
        }

        public void TakeScreenshot()
        {
            var screenshot = WebDriver.TakeScreenshot();

            var fileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"screenshot.{this.GetType().Name}.{DateTime.Now:yyyMMdd.HHmmss}.png");

            screenshot.SaveAsFile(fileName, ScreenshotImageFormat.Png);
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
