using System;
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

    private const string _clientId = nameof(XHttpClient);

    private static readonly Uri _prodBaseUri = new("https://api.twitter.com/2/", UriKind.Absolute);

    public XHttpClient(IHttpClientCache httpClientCache)
    {
        _httpClientCache = httpClientCache;
    }

    public ValueTask<HttpClient> Get(CancellationToken cancellationToken = default)
    {
        // No closure: state passed explicitly + static lambda
        return _httpClientCache.Get(_clientId, _prodBaseUri, static baseUri => new HttpClientOptions
        {
            BaseAddress = baseUri
        }, cancellationToken);
    }

    public void Dispose()
    {
        _httpClientCache.RemoveSync(_clientId);
    }

    public ValueTask DisposeAsync()
    {
        return _httpClientCache.Remove(_clientId);
    }
}