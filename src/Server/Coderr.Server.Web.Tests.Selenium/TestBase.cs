using System;
using System.IO;
using codeRR.Server.Web.Tests.Selenium.LiveServer.Fixtures;
using log4net;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using Xunit;

namespace codeRR.Server.Web.Tests.Selenium
{
    [TestCaseOrderer("codeRR.Server.Web.Tests.Selenium.Helpers.xUnit.TestCaseOrderer", "codeRR.Server.Web.Tests.Selenium")]
    public abstract class TestBase
    {
        private readonly IWebDriver _webDriver;
        private readonly ILog _logger = LogManager.GetLogger(typeof(TestBase));

        protected TestBase(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        // ReSharper disable once InconsistentNaming
        public void UITest(Action action)
        {
            try
            {
                action();
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message, ex);

                var screenshot = _webDriver.TakeScreenshot();

                var fileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"{this.GetType().Name}.{DateTime.Now:yyyMMdd.HHmmss}.png");

                screenshot.SaveAsFile(fileName, ScreenshotImageFormat.Png);

                throw;
            }
        }
    }
}
