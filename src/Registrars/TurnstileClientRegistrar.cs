using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.Cloudflare.Turnstile.Client.Abstract;

namespace Soenneker.Cloudflare.Turnstile.Client.Registrars;

/// <summary>
/// A .NET HTTP client for Cloudflare's Turnstile API, commonly used for server validation
/// </summary>
public static class TurnstileClientRegistrar
{
    /// <summary>
    /// Adds <see cref="ITurnstileClient"/> as a singleton service. <para/>
    /// </summary>
    public static void AddTurnstileClientAsSingleton(this IServiceCollection services)
    {
        services.TryAddSingleton<ITurnstileClient, TurnstileClient>();
    }

    /// <summary>
    /// Adds <see cref="ITurnstileClient"/> as a scoped service. <para/>
    /// </summary>
    public static void AddTurnstileClientAsScoped(this IServiceCollection services)
    {
        services.TryAddScoped<ITurnstileClient, TurnstileClient>();
    }
}