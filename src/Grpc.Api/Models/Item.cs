namespace Grpc.Api.Models;

public record Item
{
    public required int Weight { get; init; }
    public required string Description { get; init; }
}
