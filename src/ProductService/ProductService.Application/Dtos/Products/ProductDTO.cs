using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductService.Application.Dtos.Products
{
    public class ProductDTO
    {
        [Required(ErrorMessage = "The Name is mandatory!", AllowEmptyStrings = false)]
        public string Name { get; set; } = string.Empty;

        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than zero!")]
        public decimal Price { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be at least 1!")]
        public int Quantity { get; set; }
        public DateTime? ExpirationDate { get; set; }
    }
}
