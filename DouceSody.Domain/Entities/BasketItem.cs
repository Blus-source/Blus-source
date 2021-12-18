using System;
namespace DouceSody.Domain
{
    public class BasketItem : ValueObject<BasketItem>
    {
        public BasketItem(string productName, decimal purchaseQuantity, string currency, decimal price)
        {
            ProductName = productName;
            Quantity = purchaseQuantity;
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

        public override bool Equals(object? obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public void RemoveQuantity(int removeQuantity)
        {
            Quantity -= removeQuantity;

            if (Quantity < 0)
            {
                Quantity = 0;
            }
        }

        public override string? ToString()
        {
            return base.ToString();
        }

        protected override bool EqualsCore(BasketItem other)
        {
            return (other.Price == Price &&
                other.ProductName == ProductName &&
                other.Quantity == Quantity &&
                other.Currency == Currency);
        }

        protected override int GetHashCodeCore()
        {
            return ((int)(Price * Convert.ToDecimal(ProductName) * Quantity * Convert.ToDecimal(Currency)));
        }
    }
}

