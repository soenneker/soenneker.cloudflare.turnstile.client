using Soenneker.Cloudflare.Turnstile.Client.Abstract;
using Soenneker.Tests.FixturedUnit;
using Xunit;
using Xunit.Abstractions;

namespace Soenneker.Cloudflare.Turnstile.Client.Tests;

[Collection("Collection")]
public class TurnstileClientTests : FixturedUnitTest
{
    private readonly ITurnstileClient _util;

    public TurnstileClientTests(Fixture fixture, ITestOutputHelper output) : base(fixture, output)
    {
        _util = Resolve<ITurnstileClient>(true);
    }
}
