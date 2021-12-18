using DouceSody.Application.Shop.Queries;
using DouceSody.WebUIWithIdp.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DouceSody.WebUI.Controllers
{
    public class ShopController : ApiControllerBase
    {

        [HttpGet]
        public async Task<ActionResult<ShopDto>> Index()
        {
            return await Mediator.Send(new GetProductsQuery());
        }

        //public IActionResult Index()
        //{
        //    var products = mapper.Map<IEnumerable<ProductViewModel>>(shop.Products);
        //    return View(products);
        // }

        //public ActionResult AddProduct()
        //{
        //    return View(nameof(AddProduct));
        //}

        //public ActionResult ChartProduct()
        //{
        //    return View(nameof(ChartProduct), shop);
        //}

        //private IActionResult ChartPayment()
        //{
        //    return View(nameof(ChartPayment));
        //}

        //public IActionResult PaymentPaypal()
        //{
        //    return RedirectToAction("SuccessPurchase", "Message");
        //}


        //[HttpPost]
        //public ActionResult RemoveProductFromChart(string productName)
        //{
        //    shop.RemoveProductFromChart(productName);
        //    return View(nameof(ChartProduct), shop);
        //}

        //[HttpPost]
        //public ActionResult AddToChartProduct(string productName, string quantityPurchased)
        //{
        //    _ = int.TryParse(quantityPurchased, out int quantity);
        //    shop.AddChart(productName, quantity);
        //    return RedirectToAction(nameof(Index));
        //}

        //[HttpPost]
        //public ActionResult AddProduct(ProductDto productViewModel)
        //{
        //    var product = mapper.Map<Product>(productViewModel);
        //    shop.AddProduct(product);
        //    return RedirectToAction(nameof(Index));
        //}

        //[HttpPost]
        //public IActionResult ChartAddress()
        //{
        //    var addresses = mapper.Map<IEnumerable<AddressViewModel>>(shop.Addresses);
        //    var addressList = new SelectList(addresses, nameof(AddressViewModel.Code), nameof(AddressViewModel.Place));
        //    return View(addressList);
        //}

        //[HttpPost]
        //public ActionResult SelectDeliveryAddress()
        //{
        //    string deliveryAddress = Request.Form["addresses"].ToString();
        //    shop.SetDeliveryAddress(deliveryAddress);
        //    return View(nameof(ChartPayment));
        //}
    }
}

