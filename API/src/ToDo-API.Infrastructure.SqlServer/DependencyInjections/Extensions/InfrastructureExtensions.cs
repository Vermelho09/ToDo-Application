using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Diagnostics.CodeAnalysis;
using ToDo_API.Application.Repositories;
using ToDo_API.Infrastructure.SqlServer.Repositories;

namespace ToDo_API.Infrastructure.SqlServer.DependencyInjections.Extensions
{
    [ExcludeFromCodeCoverage]
    public static class InfrastructureExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<ITaskRepository, TaskRepository>();

            return services;
        }

        public static IServiceCollection AddSqlServerHealthCheck(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHealthChecks()
                .AddSqlServer(
                    p => configuration.GetConnectionString("SqlConnectionString"),
                    "SELECT 1;",
                    configuration["DatabaseName"],
                    HealthStatus.Unhealthy,
                    new[] { "db", "sql", "sqlserver", "ready" },
                    TimeSpan.FromSeconds(1));

            return services;
        }
    }
}
