# Grpc

## Prerequisites

- [↑ .NET SDK 8](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)

## How to run application

Run server:

```bash
dotnet run --project=src/Grpc.Server
```

Run client:

```bash
dotnet run --project=src/Grpc.Api
```

Make call from client to server by visiting:

<http://localhost:5130/call-server>.

Or call server directly with [↑ `gRPCurl`](https://github.com/fullstorydev/grpcurl):

```bash
grpcurl -plaintext localhost:5140 greet.Greeter/GetGreeting
