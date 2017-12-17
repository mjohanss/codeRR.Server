using System;
using codeRR.Server.Web.Tests.Selenium.LiveServer.Fixtures;
using log4net;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace codeRR.Server.Web.Tests.Selenium.LiveServer.Pages
{
    public class ConfigureApplicationPage : BasePage
    {
        private readonly ILog _logger = LogManager.GetLogger(typeof(ConfigureApplicationPage));

        public ConfigureApplicationPage(LiveServerFixture fixture) : base(fixture, "configure/application", "Create a new application - codeRR")
        {
        }

        [FindsBy(How = How.ClassName, Using = "btn-primary")]
        public IWebElement CreateButton { get; set; }

        [FindsBy(How = How.Id, Using = "Name")]
        public IWebElement ApplicationNameField { get; set; }

        public ConfigureApplicationPage CreateApplication(string name)
        {
            ApplicationNameField.Clear();
            ApplicationNameField.SendKeys(name);

            CreateButton.Click();

            return new ConfigureApplicationPage(Fixture);
        }

        public override void VerifyPageLoaded()
        {
            Wait.Timeout = TimeSpan.FromSeconds(90);
            base.VerifyPageLoaded();
        }
    }
}
