using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Soenneker.Dtos.HttpClientOptions;
using Soenneker.X.Client.Abstract;
using Soenneker.Utils.HttpClientCache.Abstract;

namespace Soenneker.X.Client;

///<inheritdoc cref="IXHttpClient"/>
public sealed class XHttpClient : IXHttpClient
{
    private readonly IHttpClientCache _httpClientCache;

    private const string _prodBaseUrl = "https://api.twitter.com/2/";

    public XHttpClient(IHttpClientCache httpClientCache)
    {
        _httpClientCache = httpClientCache;
    }

    public ValueTask<HttpClient> Get(CancellationToken cancellationToken = default)
    {
        return _httpClientCache.Get(nameof(XHttpClient), () =>
        {
            var options = new HttpClientOptions
            {
                BaseAddress = _prodBaseUrl
            };
            return options;
        }, cancellationToken: cancellationToken);
    }

    public void Dispose()
    {
        _httpClientCache.RemoveSync(nameof(XHttpClient));
    }

    public ValueTask DisposeAsync()
    {
        return _httpClientCache.Remove(nameof(XHttpClient));
    }
}