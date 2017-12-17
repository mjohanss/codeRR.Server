using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using codeRR.Server.Web.Tests.Selenium.LiveServer.Fixtures;

namespace codeRR.Server.Web.Tests.Selenium
{
    public class LiveServerTestBase : TestBase
    {
        protected LiveServerFixture Fixture { get; }

        public LiveServerTestBase(LiveServerFixture fixture) : base(fixture.WebDriver)
        {
            Fixture = fixture;
        }
    }
}
