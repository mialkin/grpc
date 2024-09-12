API_PROJECT := src/Grpc.Api
GRPC_SERVER_PROJECT := src/Grpc.Server

.PHONY: run-api
run-api:
	dotnet run --project $(API_PROJECT)

.PHONY: watch-api
watch-api:
	dotnet watch --project $(API_PROJECT) --no-hot-reload

.PHONY: run-grpc-server
run-grpc-server:
	dotnet run --project $(GRPC_SERVER_PROJECT)

.PHONY: watch-grpc-server
watch-grpc-server:
	dotnet watch --project $(GRPC_SERVER_PROJECT) --no-hot-reload

.PHONY: test
test:
	dotnet test
