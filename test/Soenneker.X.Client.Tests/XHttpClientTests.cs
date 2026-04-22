using Soenneker.X.Client.Abstract;
using Soenneker.Tests.HostedUnit;

namespace Soenneker.X.Client.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public sealed class XHttpClientTests : HostedUnitTest
{
    private readonly IXHttpClient _httpclient;

    public XHttpClientTests(Host host) : base(host)
    {
        _httpclient = Resolve<IXHttpClient>(true);
    }

    [Test]
    public void Default()
    {

    }
}
