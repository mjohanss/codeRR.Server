﻿using System;
using System.IO;
using codeRR.Server.SqlServer.Tests;
using codeRR.Server.Web.Tests.Selenium.Helpers;
using codeRR.Server.Web.Tests.Selenium.Helpers.Selenium;
using OpenQA.Selenium;

namespace codeRR.Server.Web.Tests.Selenium.CommunityServer.Fixtures
{
    public class CommunityServerFixture : IDisposable
    {
        private readonly TestTools _testTools;

        public IWebDriver WebDriver { get; }
        public IisExpress IisExpress { get; }

        public CommunityServerFixture()
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