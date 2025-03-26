using ProductService.Application.DependencyInjection;
using ProductService.Application.Mapper;
using ProductService.Infraestructure.DependencyInjection;

namespace ProductService.Presentation;
public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);


        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddAutoMapper(typeof(MapperDtoEntityConfigure));
        builder.Services.AddInfraestructureService(builder.Configuration);
        builder.Services.AddApplicationService(builder.Configuration);

        var app = builder.Build();

        app.UseInfraestructurePolicy();
        app.UseSwagger();
        app.UseSwaggerUI();
        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();

        app.Run();
    }
}
