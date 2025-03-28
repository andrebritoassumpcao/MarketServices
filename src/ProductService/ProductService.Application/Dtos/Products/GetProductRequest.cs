﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductService.Application.Dtos.Products
{
    public class GetProductRequest
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public decimal? Price { get; set; }
        public int? Quantity { get; set; }
        public DateTime? ExpirationDate { get; set; }
    }
}
