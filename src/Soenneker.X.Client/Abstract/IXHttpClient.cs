using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Threading;

namespace Soenneker.X.Client.Abstract;

/// <summary>
/// Provides a cached <see cref="HttpClient"/> configured for X API v2.
/// </summary>
public interface IXHttpClient : IDisposable, IAsyncDisposable
{
    /// <summary>
    /// Gets the configured X API client.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The cached HTTP client.</returns>
    ValueTask<HttpClient> Get(CancellationToken cancellationToken = default);
}
