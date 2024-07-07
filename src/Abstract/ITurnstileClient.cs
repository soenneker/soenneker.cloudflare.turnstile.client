using System.Net.Http;
using System.Threading.Tasks;
using System;
using System.Threading;

namespace Soenneker.Cloudflare.Turnstile.Client.Abstract;

/// <summary>
/// A .NET HTTP client for Cloudflare's Turnstile API, commonly used for server validation
/// </summary>
public interface ITurnstileClient : IAsyncDisposable, IDisposable
{
    ValueTask<HttpClient> Get(CancellationToken cancellationToken = default);
}