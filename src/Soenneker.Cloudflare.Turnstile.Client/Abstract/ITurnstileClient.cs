using System.Net.Http;
using System.Threading.Tasks;
using System;
using System.Threading;

namespace Soenneker.Cloudflare.Turnstile.Client.Abstract;

/// <summary>
/// Provides an owned, reusable <see cref="HttpClient"/> for Cloudflare Turnstile requests.
/// </summary>
public interface ITurnstileClient : IAsyncDisposable, IDisposable
{
    /// <summary>
    /// Gets the HTTP client owned by this provider instance.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task containing the result of the operation.</returns>
    ValueTask<HttpClient> Get(CancellationToken cancellationToken = default);
}
