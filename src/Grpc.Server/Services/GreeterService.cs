using AutoMapper;
using Grpc.Core;
using Grpc.Server.Models;

namespace Grpc.Server.Services;

public class GreeterService(IMapper mapper) : Greeter.GreeterBase
{
    public override async Task<GetGreetingResponse> GetGreeting(GetGreetingRequest request, ServerCallContext context)
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
            OrderDate = DateTime.UtcNow
        };

        return mapper.Map<GetGreetingResponse>(result);
    }
}
