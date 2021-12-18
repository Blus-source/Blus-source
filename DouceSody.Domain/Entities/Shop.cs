namespace DouceSody.Domain
{
    public sealed class Shop : Entity
    {
        public string Name { get; set; }

        public Address DeliveryAddres { get; private set; }

        public IList<Address> Addresses { get; }

        public IList<Product> Products { get; }

        public IList<BasketItem> Basket { get; }

        public decimal TotalPurchasingItems {
            get
            {

                return Basket.Count;
            }
        }

        public decimal TotalPricePurchasing
        {
            get
            {
                return GetTotalPricePurchasingItems();
            }
        }

        private decimal GetTotalPricePurchasingItems()
        {
            var total = decimal.Zero;
            foreach (var purchasedProduct in Basket)
            {
                var product = Products.SingleOrDefault(p => p.Name == purchasedProduct.ProductName);
                if (product is not null)
                {
                    total += (product.Price * purchasedProduct.Quantity);

                }
            }

            return total;
        }

        public Shop(string name)
        {
            Name = name;

            Basket = Enumerable.Empty<BasketItem>().ToList();

            Products = new List<Product>
            {
                new Product("Banana for Test", 1, 100, "", "EUR"),
                new Product("Tea for Test", 10, 100, "", "EUR"),
                new Product("Wine for Test", 100, 100, "", "EUR"),
                new Product("Computer for Test", 1000, 100, "", "EUR"),
                new Product("Plastic bag for Test", 0.1M, 100, "", "EUR"),
                new Product("Water for Test", 0.01M, 100, "", "EUR"),
            };

            Addresses = new List<Address>
            {
                new Address("Address1", " BP 500 Douala", "Cameroun"),
                new Address("Address2", " BP 500 Yaounde", "Cameroun"),
                new Address("Address3", " BP 500 Paris", "France")
            };
        }

        public void AddProduct(Product product)
        {
            if (Products.Any(p => p.Name == product.Name))
            {
                throw new InvalidOperationException();
            }

            Products.Add(product);
        }

        public void RemoveProduct(Product product)
        {
            if (!Products.Any(p => p.Name == product.Name))
            {
                throw new InvalidOperationException();
            }

            Products.Remove(product);
        }

        public void AddChart(string productName, decimal purchaseQuantity)
        {
            if (purchaseQuantity < 1)
            {
                return;
            }

            if (Basket.Any(p => p.ProductName == productName))
            {
                var chartItem = Basket.Single(s =>  s.ProductName == productName);
                chartItem.AddQuantity(purchaseQuantity);
            }
            else
            {
                var product = Products.SingleOrDefault(p => p.Name == productName);
                if (product is not null)
                {
                    Basket.Add(new BasketItem(productName, purchaseQuantity, product.Currency, product.Price));
                }
            }
        }

        public void ClearChart()
        {
            Basket.Clear();
        }

        public void RemoveProductFromChart(string name)
        {
            var product = Basket.SingleOrDefault(product => product.ProductName == name);
            if (product is not null)
            {
                Basket.Remove(product);
            }
        }

        public void SetDeliveryAddress(string selectedAdress)
        {
            DeliveryAddres = Addresses.Single(address => address.Code == selectedAdress);
        }
    }
}

