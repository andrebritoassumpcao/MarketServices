using AutoMapper;
using ProductService.Application.Dtos.Products;
using ProductService.Domain.Entities;

namespace ProductService.Application.Mapper
{
    public class MapperDtoEntityConfigure : Profile
    {
        public MapperDtoEntityConfigure()
        {
            CreateMap<Product, ProductDTO>().ReverseMap();

        }

    }
}
