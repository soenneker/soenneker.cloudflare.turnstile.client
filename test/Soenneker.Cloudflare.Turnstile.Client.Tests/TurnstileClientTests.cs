using System.Net.Http;
using FluentAssertions;
using Soenneker.Cloudflare.Turnstile.Client.Abstract;
using Soenneker.Tests.FixturedUnit;
using System.Threading.Tasks;
using Xunit;


namespace Soenneker.Cloudflare.Turnstile.Client.Tests;

[Collection("Collection")]
public class TurnstileClientTests : FixturedUnitTest
{
    private readonly ITurnstileClient _util;

    public TurnstileClientTests(Fixture fixture, ITestOutputHelper output) : base(fixture, output)
    {
        _util = Resolve<ITurnstileClient>(true);
    }

    [Fact]
    public async Task GetClient_should_return_client()
    {
        HttpClient client = await _util.Get();
        client.Should().NotBeNull();
    }
}
