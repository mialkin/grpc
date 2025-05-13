using Google.Protobuf.WellKnownTypes;
using Grpc.Api.Protos.Greet.API;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var services = builder.Services;
services.AddGrpcClient<Greeter.GreeterClient>(x => { x.Address = new Uri("http://localhost:5140"); });

var application = builder.Build();
application.UseSwagger(options => { options.RouteTemplate = "openapi/{documentName}.json"; });

application.MapScalarApiReference(x =>
{
    x.Title = "GRPC client API";
    x.DarkMode = false;
});

application.MapGet("/", () => Results.Redirect("/scalar/v1")).ExcludeFromDescription();

application.MapGet(
    pattern: "/call-server",
    handler: async (Greeter.GreeterClient client) =>
    {
        var result = await client.GetGreetingAsync(new Empty());

        var money = (decimal)result.Sum;
        return result;
    });

application.Run();
