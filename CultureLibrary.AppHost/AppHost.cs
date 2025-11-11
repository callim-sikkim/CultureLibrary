using k8s.Models;

var builder = DistributedApplication.CreateBuilder(args);

var cache = builder.AddRedis("cache");
 
var bookApi = builder.AddProject<Projects.CultureLibrary_BookApi>("BookApi")
    .WithReference(cache)
    .WaitFor(cache)
    .WithHttpHealthCheck("/health");

var gameApi = builder.AddProject<Projects.CultureLibrary_GameApi>("GameApi")
    .WithReference(cache)
    .WaitFor(cache)
    .WithHttpHealthCheck("/health");

var scriptNpmName = "start";

if(builder.Environment.EnvironmentName == "Development")
    scriptNpmName = "start-dev";

var angularApp = builder.AddNpmApp("angular", "../CultureLibrary.Web",  scriptNpmName)
    .WithReference(cache)
    .WaitFor(cache)
    .WithReference(bookApi)
    .WaitFor(bookApi)
    .WithReference(gameApi)
    .WaitFor(gameApi)
    .WithHttpEndpoint(env: "PORT", targetPort: 4200)
    .WithExternalHttpEndpoints()
    .WithHttpHealthCheck() ;

builder.Build().Run();
