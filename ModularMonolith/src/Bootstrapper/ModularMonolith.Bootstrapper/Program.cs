using ModularMonolith.Modules.Conferences.Api;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddConferencesModule();


var app = builder.Build();

app.UseRouting();
app.UseConferencesModule();

app.MapControllers();
// app.MapGet("/", () => "Hello World!");

app.Run();
