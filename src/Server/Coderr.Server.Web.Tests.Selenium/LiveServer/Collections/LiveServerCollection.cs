using codeRR.Server.Web.Tests.Selenium.LiveServer.Fixtures;
using Xunit;

namespace codeRR.Server.Web.Tests.Selenium.LiveServer.Collections
{
    [CollectionDefinition("LiveServerCollection")]
    public class LiveServerCollection : ICollectionFixture<LiveServerFixture>
    {
    }
}
