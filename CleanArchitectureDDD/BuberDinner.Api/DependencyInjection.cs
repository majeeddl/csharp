

using BuberDinner.Api.Errors;
using BuberDinner.Api.Mapping;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace BuberDinner.Api;

public static class DependencyInjection{
    public static IServiceCollection AddAdapter(this IServiceCollection services)
    {
        services.AddSingleton<ProblemDetailsFactory, CustomProblemDetailsFactory>();
        services.AddControllers();

        services.AddMappings();
        return services;
    }
}