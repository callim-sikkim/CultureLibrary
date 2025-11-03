var builder = DistributedApplication.CreateBuilder(args);

var cache = builder.AddRedis("cache");
 
var bookApi = builder.AddProject<Projects.CultureLibrary_BookApi>("BookApi")
    .WithReference(cache)
    .WaitFor(cache)
    .WithHttpHealthCheck("/health");

builder.AddNpmApp("angular", "../CultureLibrary.Web")
    .WithReference(cache)
    .WaitFor(cache)
    .WithReference(bookApi)
    .WaitFor(bookApi)
    .WithHttpEndpoint(env: "PORT", targetPort: 4200)
    .WithExternalHttpEndpoints()
    .WithHttpHealthCheck();

builder.Build().Run();
