using Grpc.Net.Client;
using Grpc.Server;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var application = builder.Build();
application.UseSwagger();
application.UseSwaggerUI();

application.MapGet("/", () => "ping")
    .WithName("get-ping")
    .WithOpenApi();

application.MapGet(
    "/get-name", async () =>
    {
        using var handler = new HttpClientHandler();
        // https://learn.microsoft.com/en-us/aspnet/core/grpc/troubleshoot?view=aspnetcore-8.0#call-a-grpc-service-with-an-untrustedinvalid-certificate
        handler.ServerCertificateCustomValidationCallback =
            HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;

        using var channel = GrpcChannel.ForAddress(
            address: "http://localhost:5140",
            channelOptions: new GrpcChannelOptions { HttpHandler = handler });

        var client = new Greeter.GreeterClient(channel);
        var request = new GetGreetingRequest();
        var result = await client.GetGreetingAsync(request);

        return result;
    });

application.Run();
