# GRPC server

Running application:

```bash
dotnet run
```

Calling GRPC endpoint with [↑ `gRPCurl`](https://github.com/fullstorydev/grpcurl):

```bash
grpcurl -plaintext localhost:5140 greet.Greeter/GetGreeting
```
