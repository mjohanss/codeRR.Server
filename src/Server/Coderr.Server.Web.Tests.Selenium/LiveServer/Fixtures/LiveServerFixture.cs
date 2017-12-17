using System;
using System.Diagnostics;
using System.IO;
using codeRR.Server.Web.Tests.Selenium.Helpers.Selenium;
using codeRR.Server.Web.Tests.Selenium.LiveServer.Pages;
using log4net.Config;
using OpenQA.Selenium;

namespace codeRR.Server.Web.Tests.Selenium.LiveServer.Fixtures
{
    public class LiveServerFixture : IDisposable
    {
        public string UserName { get; }

        public string Password => "Pa$$w0rd";

        public IWebDriver WebDriver { get; }

        public LiveServerFixture()
        {
            XmlConfigurator.ConfigureAndWatch(new FileInfo(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log4net.config")));

            WebDriver = DriverFactory.Create(BrowserType.Chrome);
            UserName = $"testuser.{Guid.NewGuid():N}@coderrapp.com";

            Debug.WriteLine($"Registering user '{UserName}'");

            var page = new RegisterPage(WebDriver, UserName, Password)
                .RegisterUserStartup();

            page.VerifyIsCurrentPage();
        }

        public void Dispose()
        {
            try
            {
                WebDriver.Quit();
                WebDriver.Close();
            }
            // ReSharper disable once EmptyGeneralCatchClause
            catch
            {
            }
        }
    }
}
