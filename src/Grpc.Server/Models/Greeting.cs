namespace Grpc.Server.Models;

public record Greeting
{
    public required List<int> Amounts { get; init; }
    public required int Size { get; init; }
    public required List<Item> Items { get; init; }
    public required DateTime OrderDate { get; init; }
}
