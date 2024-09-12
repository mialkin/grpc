using Grpc.Server.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddGrpc();

var application = builder.Build();

application.MapGrpcService<GreeterService>();
application.MapGet("/",
    () =>
        "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

application.Run();
