using System;
namespace DouceSody.Domain
{
    public sealed class Product : Entity
    {
        public string Name { get; private set; }

        public decimal Price { get; private set; }

        public decimal Quantity { get; private set; }

        public string Image { get; private set; }

        public string Currency { get; private set; }


        public Product()
        {
            
        }

        public Product(string name,
            decimal price,
            decimal quantity,
            string image,
            string currency):this()
        {
            Name = name;
            Price = price;
            Quantity = quantity;
            Image = image;
            Currency = currency;
        }

        public void AddQuantity(decimal quantityToAdd)
        {
            Quantity += quantityToAdd;
        }

        public void RemoveQuantity(decimal quantityToRemove)
        {
            if (quantityToRemove > Quantity)
            {
                throw new InvalidOperationException();
            }

            Quantity -= quantityToRemove;
        }
    }
}

