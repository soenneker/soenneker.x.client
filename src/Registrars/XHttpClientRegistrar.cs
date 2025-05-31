using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.X.Client.Abstract;
using Soenneker.Utils.HttpClientCache.Registrar;

namespace Soenneker.X.Client.Registrars;

/// <summary>
/// A .NET thread-safe singleton HttpClient for GitHub
/// </summary>
public static class XHttpClientRegistrar
{
    /// <summary>
    /// Adds <see cref="XHttpClient"/> as a singleton service. <para/>
    /// </summary>
    public static IServiceCollection AddXHttpClientAsSingleton(this IServiceCollection services)
    {
        services.AddHttpClientCacheAsSingleton()
                .TryAddSingleton<IXHttpClient, XHttpClient>();

        return services;
    }

    /// <summary>
    /// Adds <see cref="XHttpClient"/> as a scoped service. <para/>
    /// </summary>
    public static IServiceCollection AddXHttpClientAsScoped(this IServiceCollection services)
    {
        services.AddHttpClientCacheAsSingleton()
                .TryAddScoped<IXHttpClient, XHttpClient>();

        return services;
    }
}
