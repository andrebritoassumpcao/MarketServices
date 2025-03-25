using Microsoft.EntityFrameworkCore;
using ProductService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductService.Infraestructure.Data
{
    public class ProductDbContext(DbContextOptions<ProductDbContext> options) : DbContext
    {
        public DbSet<Product> Products { get; set; }
    }
}
