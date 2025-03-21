using System.ComponentModel.DataAnnotations;

namespace ProductService.Application.Dtos.Products
{
    public class AddProductRequest
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
