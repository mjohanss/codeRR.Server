﻿using System;
using System.Configuration;
using System.IO;
using codeRR.Server.SqlServer.Tests;
using codeRR.Server.Web.Tests.Selenium.Helpers;
using codeRR.Server.Web.Tests.Selenium.Helpers.Selenium;
using OpenQA.Selenium;

namespace codeRR.Server.Web.Tests.Selenium.Fixtures
{
    public class SeleniumFixture : IDisposable
    {
        private readonly TestTools _testTools;

        public IWebDriver WebDriver { get; }
        public IisExpress IisExpress { get; }

        public SeleniumFixture()
        {
            _testTools = new TestTools {CanDropDatabase = false};
            _testTools.CreateAndInitializeDatabase();

            IisExpress = new IisExpress
            {
                ConfigPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "applicationhost.config")
            };

            IisExpress.Start("codeRR.Server.Web");

            WebDriver = DriverFactory.Create(BrowserType.Chrome);
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

            IisExpress.Stop();

            _testTools.Dispose();
        }
    }
}
