using AutoMapper;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Grpc.Server.Greet.API;
using Grpc.Server.Models;

namespace Grpc.Server.Services;

public class GreeterService(IMapper mapper) : Greeter.GreeterBase
{
    public override async Task<GetGreetingResponse> GetGreeting(Empty request, ServerCallContext context)
    {
        await Task.CompletedTask;

        var result = new Greeting
        {
            Amounts = [10, 20, 50],
            Size = 100,
            Items =
            [
                new Models.Item
                {
                    Weight = 40, Description = "Apple"
                },
                new Models.Item
                {
                    Weight = 20, Description = "Banana"
                }
            ],
            OrderDate = DateTime.UtcNow,
            Sum = 500.45m
        };

        return mapper.Map<GetGreetingResponse>(result);
    }
}
