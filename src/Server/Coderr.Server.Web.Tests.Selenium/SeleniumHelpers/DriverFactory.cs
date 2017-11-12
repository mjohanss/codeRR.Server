using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace codeRR.Server.Web.Tests.Selenium.SeleniumHelpers
{
    public class DriverFactory
    {
        public IWebDriver Create(Browser browser)
        {
            IWebDriver webDriver;

            switch (browser)
            {
                case Browser.Chrome:
                    webDriver = new ChromeDriver();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            webDriver.Manage().Window.Maximize();

            return webDriver;
        }
    }
}
