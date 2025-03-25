using Market.SharedLibrary.Logs;
using Market.SharedLibrary.Responses;
using Microsoft.EntityFrameworkCore;
using ProductService.Application.Interfaces.Repositories;
using ProductService.Domain.Entities;
using ProductService.Infraestructure.Data;
using System.Linq.Expressions;

namespace ProductService.Infraestructure.Repositories;
internal class ProductRepository(ProductDbContext context) : IProductRepository
{
    public async Task<Response> CreateAsync(Product entity)
    {
        try
        {
            var getProduct = await GetByAsync(_ => _.Name!.Equals(entity.Name));

            if (getProduct is not null && !string.IsNullOrEmpty(getProduct.Name))
                return new Response(false, $"{entity.Name} already exists.");

            var currentEntity = context.Products.Add(entity).Entity;
            await context.SaveChangesAsync();

            if (currentEntity is not null && currentEntity.Id > 0)
                return new Response(true, $"{entity.Name} added to database successfully.");
            else
                return new Response(false, $"An error ocurred while adding {entity.Name}");
        }
        catch (Exception ex)
        {
            LogException.LogExceptions(ex);

            return new Response(false, "Error adding new product");
        }
    }

    public async Task<Response> DeleteAsync(Product entity)
    {
        try
        {
            var product = await FindByIdAsync(entity.Id);

            if (product is null)
                return new Response(false, $"{entity.Name} not found.");

            context.Products.Remove(product);
            await context.SaveChangesAsync();
            return new Response(true, $"{entity.Name} is deleted successfully");
        }
        catch (Exception ex)
        {
            LogException.LogExceptions(ex);

            return new Response(false, "Error deleting the product");
        }
    }

    public async Task<Product> FindByIdAsync(int id)
    {
        try
        {
            var product = await context.Products.FindAsync(id);

            return product is not null ? product : null!;
        }
        catch (Exception ex)
        {
            LogException.LogExceptions(ex);

            throw new Exception("Error ocurred retrieving product");
        }
    }

    public async Task<IEnumerable<Product>> GetAllAsync()
    {
        try
        {
            var products = await context.Products.AsNoTracking().ToListAsync();

            return products is not null ? products : null!;
        }
        catch (Exception ex)
        {
            LogException.LogExceptions(ex);

            throw new InvalidOperationException("Error ocurred retrieving product");
        }
    }

    public async Task<Product> GetByAsync(Expression<Func<Product, bool>> predicate)
    {
        try
        {
            var product = await context.Products.Where(predicate).FirstOrDefaultAsync();

            return product is not null ? product : null!;
        }
        catch (Exception ex)
        {
            LogException.LogExceptions(ex);

            throw new InvalidOperationException("Error ocurred retrieving product");
        }
    }

    public async Task<Response> UpdateAsync(Product entity)
    {
        try
        {
            var product = await FindByIdAsync(entity.Id);

            if (product is null)
                return new Response(false, $"{entity.Name} not found");

            context.Entry(product).State = EntityState.Detached;
            context.Products.Update(entity);
            await context.SaveChangesAsync();

            return new Response(true, $"{entity.Name} is updated successfully");
        }
        catch (Exception ex)
        {
            LogException.LogExceptions(ex);

            return new Response(false, "An error ocurred updating the product.");
        }

    }
}