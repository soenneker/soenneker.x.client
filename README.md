[![](https://img.shields.io/nuget/v/soenneker.x.client.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.x.client/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.x.client/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.x.client/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.x.client.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.x.client/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.x.client/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.x.client/actions/workflows/codeql.yml)

# ![](https://user-images.githubusercontent.com/4441470/224455560-91ed3ee7-f510-4041-a8d2-3fc093025112.png) Soenneker.X.Client

Provides a cached `HttpClient` configured for X API v2. Authentication is applied per request so the same transport can safely serve app-only and user-context calls.

## Installation

```bash
dotnet add package Soenneker.X.Client
```

## Registration and usage

```csharp
using System.Net.Http.Headers;
using Soenneker.X.Client.Abstract;
using Soenneker.X.Client.Registrars;

services.AddXHttpClientAsSingleton();

public sealed class XUserService
{
    private readonly IXHttpClient _clientProvider;

    public XUserService(IXHttpClient clientProvider)
    {
        _clientProvider = clientProvider;
    }

    public async Task<string> GetByUsername(
        string username,
        string bearerToken,
        CancellationToken cancellationToken)
    {
        HttpClient client = await _clientProvider.Get(cancellationToken);
        using var request = new HttpRequestMessage(
            HttpMethod.Get,
            $"users/by/username/{Uri.EscapeDataString(username)}");
        request.Headers.Authorization =
            new AuthenticationHeaderValue("Bearer", bearerToken);

        using HttpResponseMessage response = await client.SendAsync(
            request,
            cancellationToken);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadAsStringAsync(cancellationToken);
    }
}
```

Do not place a per-user token in `DefaultRequestHeaders` on the shared client. Add the appropriate app bearer token or OAuth user access token to each request; X endpoints differ in which authentication context they accept.

Use `AddXHttpClientAsScoped()` when the provider should follow a scope. Each provider owns its cached client and removes it when disposed.
