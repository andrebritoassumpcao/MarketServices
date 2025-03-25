using AutoMapper;
using Market.SharedLibrary.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductService.Application.Dtos.Products;
using ProductService.Application.Interfaces.Repositories;
using ProductService.Application.Mapper;
using ProductService.Application.UseCases;

namespace ProductService.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController(IProductRepository productInterface, IMapper mapper) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetProducts()
        {
            var products = await productInterface.GetAllAsync();
            if (!products.Any())
                return NotFound("No products detected in the database.");

            var list = mapper.Map<IEnumerable<ProductDTO>>(products);

            return list!.Any() ? Ok(list) : NotFound("No product found.");
        } 

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ProductDTO>> GetProduct(int id)
        {
            var product = await productInterface.FindByIdAsync(id);

            if (product is null)
                return NotFound("Product requested not found.");

            var productDto = mapper.Map<ProductDTO>(product);

            return productDto is not null ? Ok(productDto) : NotFound("Product not found.");
        }

        [HttpPost]
        public async Task<ActionResult<ProductDTO>> CreateProduct([FromServices] AddProductUseCase addProduct,ProductDTO product)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var response = await addProduct.Execute(product);

            return response.Flag is true ? Ok(response) : BadRequest(response); 
        }
        [HttpPut]
        public async Task<ActionResult<Response>> UpdateProduct([FromServices] UpdateProductUseCase updateProduct, ProductDTO product)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var response = await updateProduct.Execute(product);

            return response.Flag is true ? Ok(response) : BadRequest(response);
        }

        [HttpDelete]
        public async Task<ActionResult<Response>> DeleteProduct([FromServices] DeleteProductUseCase deleteProduct, ProductDTO product)
        {
            var response = await deleteProduct.Execute(product);

            return response.Flag is true ? Ok(response) : BadRequest(response);
        }
    }
}
