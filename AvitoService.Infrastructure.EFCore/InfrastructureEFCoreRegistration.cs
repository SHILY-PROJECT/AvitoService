using AvitoService.Core.Common.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AvitoService.Infrastructure.EFCore;

public static class InfrastructureEfCoreRegistration
{
    public static IServiceCollection AddInfrastructureEfCore(this IServiceCollection services)
    {
        services.AddDbContext<AvitoDbContext>((context, options) =>
        {
            var cfg = context.GetRequiredService<AvitoServiceConfiguration>();
            options.UseSqlServer(cfg.AvitoDbContextConnection);
        });
        
        return services;
    }
}