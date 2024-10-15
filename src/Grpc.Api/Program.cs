using Grpc.Server;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;
services.AddGrpcClient<Greeter.GreeterClient>(x => { x.Address = new Uri("http://localhost:5140"); });

var application = builder.Build();

application.MapGet("/", () => "ping");

application.MapGet(
    pattern: "/call-server",
    handler: async (Greeter.GreeterClient client) =>
    {
        var request = new GetGreetingRequest();
        var result = await client.GetGreetingAsync(request);
        return result;
    });

application.Run();
