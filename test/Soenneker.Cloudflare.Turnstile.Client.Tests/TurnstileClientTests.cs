using System.Net.Http;
using AwesomeAssertions;
using Soenneker.Cloudflare.Turnstile.Client.Abstract;
using Soenneker.Tests.HostedUnit;
using System.Threading.Tasks;


namespace Soenneker.Cloudflare.Turnstile.Client.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public class TurnstileClientTests : HostedUnitTest
{
    private readonly ITurnstileClient _util;

    public TurnstileClientTests(Host host) : base(host)
    {
        _util = Resolve<ITurnstileClient>(true);
    }

    [Test]
    public async Task GetClient_should_return_client()
    {
        HttpClient client = await _util.Get(cancellationToken: CancellationToken);
        client.Should().NotBeNull();
    }
}
