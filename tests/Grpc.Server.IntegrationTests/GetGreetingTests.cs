using FluentAssertions;
using Grpc.Net.Client;
using Grpc.Server.Greet.API;
using Microsoft.AspNetCore.Mvc.Testing;

namespace Grpc.Server.IntegrationTests;

public class GetGreetingTests(WebApplicationFactory<Program> factory)
    : IClassFixture<WebApplicationFactory<Program>>
{
    [Fact]
    public async Task WhenMethodIsCalled_ReturnsValidGreeting()
    {
        // Arrange
        var options = new GrpcChannelOptions { HttpHandler = factory.Server.CreateHandler() };
        var channel = GrpcChannel.ForAddress(factory.Server.BaseAddress, options);
        var client = new Greeter.GreeterClient(channel);
        var request = new GetGreetingRequest();

        // Act
        var response = await client.GetGreetingAsync(request);

        // Assert
        response.Should().NotBeNull();
    }
}
