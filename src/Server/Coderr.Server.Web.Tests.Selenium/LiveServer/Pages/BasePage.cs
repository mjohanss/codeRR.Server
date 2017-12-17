using System;
using System.Configuration;
using System.IO;
using codeRR.Server.Web.Tests.Selenium.LiveServer.Fixtures;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using Xunit;

namespace codeRR.Server.Web.Tests.Selenium.LiveServer.Pages
{
    public class BasePage
    {
        protected readonly LiveServerFixture Fixture;
        protected IWebDriver WebDriver;
        protected WebDriverWait Wait;
        protected string BaseUrl { get; }
        protected string Url { get; }
        protected string UserName { get; }
        protected string Password { get; }
        protected string Title { get; }

        public BasePage(LiveServerFixture fixture, string url, string title)
        {
            Fixture = fixture;
            WebDriver = fixture.WebDriver;
            Title = title;

            Wait = new WebDriverWait(fixture.WebDriver, TimeSpan.FromSeconds(10));

            UserName = fixture.UserName;
            Password = fixture.Password;

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

        public virtual void VerifyPageLoaded()
        {
            Wait.Until(ExpectedConditions.TitleIs(Title));
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
