[![](https://img.shields.io/nuget/v/soenneker.cloudflare.turnstile.client.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.cloudflare.turnstile.client/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.cloudflare.turnstile.client/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.cloudflare.turnstile.client/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.cloudflare.turnstile.client.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.cloudflare.turnstile.client/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.cloudflare.turnstile.client/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.cloudflare.turnstile.client/actions/workflows/codeql.yml)

# Soenneker.Cloudflare.Turnstile.Client

Provides an owned, reusable `HttpClient` for server-side Cloudflare Turnstile requests.

## Installation

```bash
dotnet add package Soenneker.Cloudflare.Turnstile.Client
```

## Registration

```csharp
using Soenneker.Cloudflare.Turnstile.Client.Registrars;

services.AddTurnstileClientAsSingleton();
```

Scoped registration is available with `AddTurnstileClientAsScoped()`. Each provider instance owns a separate cached `HttpClient`; disposing that provider removes and disposes its client without affecting another scope.

## Usage

```csharp
using Soenneker.Cloudflare.Turnstile.Client.Abstract;

HttpClient httpClient = await turnstileClient.Get(cancellationToken);

using var request = new HttpRequestMessage(
    HttpMethod.Post,
    "https://challenges.cloudflare.com/turnstile/v0/siteverify");
```

`Get` returns the same client for the lifetime of the injected provider. It does not set a base address, authentication header, or Turnstile secret; callers must build the request required by the endpoint.

Applications that only need token validation should normally use `Soenneker.Cloudflare.Turnstile.Validator`, which builds the Siteverify request and parses the response. This lower-level package is useful when a validator or custom Turnstile integration needs direct `HttpClient` access.

Do not dispose the returned `HttpClient` directly. Let dependency injection dispose `ITurnstileClient`, which owns and removes the cached client.
