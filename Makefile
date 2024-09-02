STARTUP_PROJECT := src/Grpc
DEFAULT_ENVIRONMENT := Ide

.PHONY: run
run:
	dotnet run --project $(STARTUP_PROJECT)

.PHONY: watch
watch:
	dotnet watch --project $(STARTUP_PROJECT) --no-hot-reload

.PHONY: test
test:
	dotnet test --environment ASPNETCORE_ENVIRONMENT=$(DEFAULT_ENVIRONMENT)
