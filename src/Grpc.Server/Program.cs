using Grpc.Server.AutoMapperProfiles;
using Grpc.Server.Services;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

services.AddGrpc();
services.AddGrpcReflection();
services.AddAutoMapper(x => x.AddProfile<GrpcMappingProfile>());

var application = builder.Build();

application.MapGrpcService<GreeterService>();

if (application.Environment.IsDevelopment())
{
    application.MapGrpcReflectionService();
}

application.Run();

public partial class Program;
