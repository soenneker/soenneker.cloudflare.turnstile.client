using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.Cloudflare.Turnstile.Client.Abstract;
using Soenneker.Utils.HttpClientCache.Registrar;

namespace Soenneker.Cloudflare.Turnstile.Client.Registrars;

/// <summary>
/// A .NET HTTP client for Cloudflare's Turnstile API, commonly used for server validation
/// </summary>
public static class TurnstileClientRegistrar
{
    /// <summary>
    /// Adds <see cref="ITurnstileClient"/> as a singleton service. <para/>
    /// </summary>
    public static IServiceCollection AddTurnstileClientAsSingleton(this IServiceCollection services)
    {
        services.AddHttpClientCacheAsSingleton().TryAddSingleton<ITurnstileClient, TurnstileClient>();

        return services;
    }

    /// <summary>
    /// Adds <see cref="ITurnstileClient"/> as a scoped service. <para/>
    /// </summary>
    public static IServiceCollection AddTurnstileClientAsScoped(this IServiceCollection services)
    {
        services.AddHttpClientCacheAsSingleton().TryAddScoped<ITurnstileClient, TurnstileClient>();

        return services;
    }
}