var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var application = builder.Build();
application.UseSwagger();
application.UseSwaggerUI();

application.MapGet("/", () => "ping")
    .WithName("get-ping")
    .WithOpenApi();

application.MapGet("/get-name", () =>
{

    return "Aleksei";
});

application.Run();
