using System;
namespace DouceSody.Domain
{
    public class BasketItem
    {
        public BasketItem(string productName, decimal purchaseQuantity, string currency, decimal price)
        {
            ProductName = productName;
            Quantity = purchaseQuantity;
            Currency = currency;
            Currency = currency;
            Price = price;
        }

        public string ProductName { get; }
        public decimal Quantity { get; private set; }
        public string Currency { get; }
        public decimal Price { get;}

        public void AddQuantity(decimal quantity)
        {
            Quantity += quantity;
        }

        public void RemoveQuantity(int removeQuantity)
        {
            Quantity -= removeQuantity;

            if (Quantity < 0)
            {
                Quantity = 0;
            }
        }
    }
}

