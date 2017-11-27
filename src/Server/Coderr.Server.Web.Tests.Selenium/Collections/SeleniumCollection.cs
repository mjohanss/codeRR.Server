using codeRR.Server.Web.Tests.Selenium.Fixtures;
using Xunit;

namespace codeRR.Server.Web.Tests.Selenium.Collections
{
    [CollectionDefinition("Selenium collection")]
    public class SeleniumCollection : ICollectionFixture<SeleniumFixture>
    {
    }
}
