using System;
using DouceSody.Application.Common.Mappings;
using DouceSody.Domain;

namespace DouceSody.Application.Shop.Queries
{
	public class ProductDto : IMapFrom<Product>
    {
        public string? Name { get; set; }

        public decimal Price { get; set; }

        public decimal Quantity { get; set; }

        public decimal QuantityPurchased { get; set; }

        public string? Image { get; set; }

        public string? Currency { get; set; }
    }
}

