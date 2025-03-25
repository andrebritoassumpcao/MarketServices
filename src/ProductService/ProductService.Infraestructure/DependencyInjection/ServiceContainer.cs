using Market.SharedLibrary.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProductService.Application.Interfaces.Repositories;
using ProductService.Infraestructure.Data;
using ProductService.Infraestructure.Repositories;

namespace ProductService.Infraestructure.DependencyInjection;

public static class ServiceContainer
{
    public static IServiceCollection AddInfraestructureService(this IServiceCollection services, IConfiguration configuration)
    {
        SharedServiceContainer.AddSharedServices<ProductDbContext>(services, configuration, configuration["MySerilog:FileName"]);

        services.AddScoped<IProductRepository, ProductRepository>();

        return services;
    }

    public static IApplicationBuilder UseInfraestructurePolicy(this IApplicationBuilder app) 
    {
        SharedServiceContainer.UseSharedPolices(app);

        return app; 
        
    }
}
