using System;
using Microsoft.AspNetCore.Mvc;

namespace DouceSody.WebUI.Models
{
    public class ProductViewModel
    {
        public string? Name { get; set; }

        public decimal Price { get; set; }

        public decimal Quantity { get; set; }

        [BindProperty(SupportsGet =true, Name = "QuantityPurchased")]
        public decimal QuantityPurchased { get; set; }

        public string? Image { get;  set; }

        public string? Currency { get; set; }
    }
}

