using Soenneker.X.Client.Abstract;
using Soenneker.Tests.FixturedUnit;
using Xunit;

namespace Soenneker.X.Client.Tests;

[Collection("Collection")]
public sealed class XHttpClientTests : FixturedUnitTest
{
    private readonly IXHttpClient _httpclient;

    public XHttpClientTests(Fixture fixture, ITestOutputHelper output) : base(fixture, output)
    {
        _httpclient = Resolve<IXHttpClient>(true);
    }

    [Fact]
    public void Default()
    {

    }
}
