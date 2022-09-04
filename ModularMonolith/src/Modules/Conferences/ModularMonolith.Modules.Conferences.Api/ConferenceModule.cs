
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

[assembly:InternalsVisibleTo(assemblyName:"ModularMonolith.Bootstrapper")]
namespace ModularMonolith.Modules.Conferences.Api;

internal static class ConferenceModule
{
    public static IServiceCollection AddConferencesModule(this IServiceCollection services)
    {
        return services;
    }

    public static IApplicationBuilder UseConferencesModule(this IApplicationBuilder app)
    {
        return app;
    }
}