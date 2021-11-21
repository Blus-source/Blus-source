using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DouceSody.Domain;
using DouceSody.WebUI.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DouceSody.WebUI.Controllers
{
    public class ShopController : Controller
    {
        private readonly Shop shop;

        public ShopController(Shop shop)
        {
            this.shop = shop;
        }

        public IActionResult Index()
        {
            var products = shop.Products;

            var productConverted = new List<ProductViewModel>();


            foreach (var product in products)
            {
                productConverted.Add(new ProductViewModel
                {
                    Currency = product.Currency,
                    Image = product.Image,
                    Name = product.Name,
                    Price = product.Price,
                    Quantity = product.Quantity

                });
            }

            return View(productConverted);
        }

        public ActionResult AddProduct()
        {
            return View(nameof(AddProduct));
        }

        public ActionResult ChartProduct()
        {
            return View(nameof(ChartProduct), shop);
        }

        [HttpPost]
        public ActionResult RemoveProductFromChart(string productName)
        {
            shop.RemoveProductFromChart(productName);
            return View(nameof(ChartProduct), shop);
        }

        [HttpPost]
        public ActionResult AddToChartProduct(string productName, string quantityPurchased)
        {            
            int.TryParse(quantityPurchased, out int quantity);
            shop.AddChart(productName, quantity);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public ActionResult AddProduct(ProductViewModel product)
        {
            shop.AddProduct(new Product(product.Name, product.Price, product.Quantity, product.Image, product.Currency));
            return RedirectToAction(nameof(Index));
        }
    }
}

