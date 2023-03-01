using System.Reflection;
using BuberDinner.Application.Authentication.Commands.Register;
using BuberDinner.Application.Common.Behaviors;
using BuberDinner.Application.Services.Authentication.Commands;
using BuberDinner.Application.Services.Authentication.Common;
using BuberDinner.Application.Services.Authentication.Queries;
using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;


namespace BuberDinner.Application;

public static class DependencyInjection{
    public static IServiceCollection AddApplication(this IServiceCollection services){
        // services.AddScoped<IAuthenticationCommandService, AuthenticationCommandService>();
        // services.AddScoped<IAuthenticationQueryService, AuthenticationQueryService>();


        services.AddMediatR(typeof(DependencyInjection).Assembly);

        services
            .AddScoped(
                typeof(IPipelineBehavior<,>),
                typeof(ValidateBehavior<,>)
                );

        //services.AddScoped<IValidator<RegisterCommand>, RegisterCommandValidator>();
        // because of using FluentValidation ASP.NET Core integration we don't need to add validators manually
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        return services;
    }
}