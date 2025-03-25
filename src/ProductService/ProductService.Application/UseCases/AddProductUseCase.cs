using AutoMapper;
using ProductService.Application.Dtos.Products;
using ProductService.Application.Interfaces.Repositories;
using ProductService.Domain.Entities;
using Market.SharedLibrary.Responses;

namespace ProductService.Application.UseCases;

public class AddProductUseCase
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public AddProductUseCase(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<Response> Execute(ProductDTO request)
    {
        var product = _mapper.Map<Product>(request);
        return await _productRepository.CreateAsync(product);
    }
}
