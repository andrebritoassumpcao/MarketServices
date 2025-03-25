using AutoMapper;
using Market.SharedLibrary.Responses;
using ProductService.Application.Dtos.Products;
using ProductService.Application.Interfaces.Repositories;
using ProductService.Domain.Entities;

namespace ProductService.Application.UseCases
{
    public class UpdateProductUseCase
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public UpdateProductUseCase(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        public async Task<Response> Execute(ProductDTO request)
        {
            var product = _mapper.Map<Product>(request);
            return await _productRepository.UpdateAsync(product);
        }
    }
}
