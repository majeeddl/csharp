using ModularMonolith.Modules.Conferences.Api;
using ModularMonolith.Shared.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// builder.Services.AddControllers();
var services = builder.Services;

services.AddInfrastructure();
services.AddConferencesModule();


var app = builder.Build();

app.UseRouting();
app.UseInfrastructure();
app.UseConferencesModule();

app.MapControllers();
// app.MapGet("/", () => "Hello World!");

app.Run();
