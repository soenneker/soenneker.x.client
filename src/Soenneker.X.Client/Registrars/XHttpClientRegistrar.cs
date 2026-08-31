using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.X.Client.Abstract;
using Soenneker.Utils.HttpClientCache.Registrar;

namespace Soenneker.X.Client.Registrars;

/// <summary>
/// Registers the X API v2 HTTP client provider.
/// </summary>
public static class XHttpClientRegistrar
{
    /// <summary>
    /// Adds the X HTTP client provider as a singleton service.
    /// </summary>
    public static IServiceCollection AddXHttpClientAsSingleton(this IServiceCollection services)
    {
        services.AddHttpClientCacheAsSingleton()
                .TryAddSingleton<IXHttpClient, XHttpClient>();

        return services;
    }

    /// <summary>
    /// Adds the X HTTP client provider as a scoped service.
    /// </summary>
    public static IServiceCollection AddXHttpClientAsScoped(this IServiceCollection services)
    {
        services.AddHttpClientCacheAsSingleton()
                .TryAddScoped<IXHttpClient, XHttpClient>();

        return services;
    }
}
