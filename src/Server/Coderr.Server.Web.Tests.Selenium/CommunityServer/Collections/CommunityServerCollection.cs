using codeRR.Server.Web.Tests.Selenium.CommunityServer.Fixtures;
using Xunit;

namespace codeRR.Server.Web.Tests.Selenium.CommunityServer.Collections
{
    [CollectionDefinition("CommunityServerCollection")]
    public class CommunityServerCollection : ICollectionFixture<CommunityServerFixture>
    {
    }
}
