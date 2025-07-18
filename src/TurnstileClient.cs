using Soenneker.Cloudflare.Turnstile.Client.Abstract;
using System.Net.Http;
using System.Threading.Tasks;
using System;
using System.Threading;
using Soenneker.Utils.HttpClientCache.Abstract;

namespace Soenneker.Cloudflare.Turnstile.Client;

/// <inheritdoc cref="ITurnstileClient"/>
public sealed class TurnstileClient : ITurnstileClient
{
    private readonly IHttpClientCache _httpClientCache;

    public TurnstileClient(IHttpClientCache httpClientCache)
    {
        _httpClientCache = httpClientCache;
    }

    public ValueTask<HttpClient> Get(CancellationToken cancellationToken = default)
    {
        return _httpClientCache.Get(nameof(TurnstileClient), cancellationToken: cancellationToken);
    }

    public void Dispose()
    {
        _httpClientCache.RemoveSync(nameof(TurnstileClient));
    }

    public ValueTask DisposeAsync()
    {
        return _httpClientCache.Remove(nameof(TurnstileClient));
    }
}