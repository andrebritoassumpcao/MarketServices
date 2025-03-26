using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProductService.Application.UseCases;

namespace ProductService.Application.DependencyInjection
{
    public static class ServiceContainer
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<AddProductUseCase>();
            services.AddScoped<UpdateProductUseCase>();
            services.AddScoped<DeleteProductUseCase>();

            return services;
        }
    }
}
