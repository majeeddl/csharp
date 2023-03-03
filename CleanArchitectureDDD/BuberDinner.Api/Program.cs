// using BuberDinner.Application.Services.Authentication;

using BuberDinner.Api;
using BuberDinner.Api.Errors;
using BuberDinner.Api.Filters;
using BuberDinner.Api.Mapping;
using BuberDinner.Api.Middlewares;
using BuberDinner.Application;
using BuberDinner.Infrastructure;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//remove this line and use dependency injection
// builder.Services.AddScoped<IAuthenticationService,AuthenticationService>();

builder.Services.AddAdapter();

// => dependency injection
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);


//  add error handling filter attr to all controllers
// builder.Services.AddControllers(options => options.Filters.Add<ErrorHandlingFilterAttribute>());

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseExceptionHandler("/errors");

//minimal code for replacing Problem default factory
//app.Map("/error", (HttpContext httpContext) =>
//{
//    Exception? exception = httpContext.Features.Get<IExceptionHandlerFeature>()?.Error;

//    return Results.Problem();
//});

// app.UseHttpsRedirection();

// app.UseMiddleware<ErrorHandlingMiddleware>();

app.UseAuthorization();
app.UseAuthentication();

app.MapControllers();

app.Run();
