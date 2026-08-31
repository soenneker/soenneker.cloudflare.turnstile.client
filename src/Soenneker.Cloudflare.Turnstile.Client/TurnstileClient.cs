using Soenneker.Cloudflare.Turnstile.Client.Abstract;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Threading;
using Soenneker.Utils.HttpClientCache.Abstract;

namespace Soenneker.Cloudflare.Turnstile.Client;

public sealed class TurnstileClient : ITurnstileClient
{
    private readonly IHttpClientCache _httpClientCache;
    private readonly string _cacheKey = $"{nameof(TurnstileClient)}:{Guid.NewGuid():N}";

    public TurnstileClient(IHttpClientCache httpClientCache)
    {
        _httpClientCache = httpClientCache;
    }

    public ValueTask<HttpClient> Get(CancellationToken cancellationToken = default)
    {
        return _httpClientCache.Get(_cacheKey, cancellationToken: cancellationToken);
    }

    public void Dispose()
    {
        _httpClientCache.RemoveSync(_cacheKey);
    }

    public ValueTask DisposeAsync()
    {
        return _httpClientCache.Remove(_cacheKey);
    }
}
