using System;
using DouceSody.Domain;
using FluentAssertions;
using NUnit.Framework;

namespace DouceSody.Tests
{
    [TestFixture]
    public class ProductTests
    {
        [Test]
        public void Add_Quantity_To_Product()
        {
            // Arrange
            var product = new Product("ProductA", 1, 10, "ImageA", "EUR");
            var quantityToAdd = 1;

            // Act
            product.AddQuantity(quantityToAdd);

            // Assert
            product.Quantity.Should().Be(11);
        }

        [Test]
        public void Remove_Quantity_To_Product()
        {
            // Arrange
            var product = new Product("ProductA", 1, 10, "ImageA", "EUR");
            var quantityToAdd = 5;
            var quantityToRemove = 3;

            // Act
            product.AddQuantity(quantityToAdd);
            product.RemoveQuantity(quantityToRemove);

            // Assert
            product.Quantity.Should().Be(12);
        }

        [Test]
        public void Cannot_Remove_More_Than_Remain_Quantity_In_Product()
        {
            // Arrange
            var product = new Product("ProductA", 1, 0, "ImageA", "EUR");
            var quantityToAdd = 5;
            var quantityToRemove = 6;

            // Act
            product.AddQuantity(quantityToAdd);
            Action action = () => product.RemoveQuantity(quantityToRemove);

            // Assert
            action.Should().Throw<InvalidOperationException>();
        }
    }
}

