using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;
using ToDo_API.Application.Services.Tasks;

namespace ToDo_API.Application.Extensions
{
    [ExcludeFromCodeCoverage]
    public static class ApplicationExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<ITaskService, TaskService>();

            return services;
        }
    }
}
