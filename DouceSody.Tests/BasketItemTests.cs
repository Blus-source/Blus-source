using System;
using DouceSody.Domain;
using FluentAssertions;
using NUnit.Framework;

namespace DouceSody.Tests
{
    [TestFixture]
    public class BasketItemTests
    {
        [Test]
        public void Increment_Quantity_To_CharItem()
        {
            // Arrange
            var chartItem = new BasketItem("ProductA", 1, "EUR", 1) ;
            var quantity = 2;

            // Act
            chartItem.AddQuantity(quantity);

            // Assert
            chartItem.Quantity.Should().Be(3M);
        }

        [Test]
        public void Decrement_Quantity_To_CharItem()
        {
            // Arrange
            var chartItem = new BasketItem("ProductA", 1, "USD", 1);
            var quantity = 2;
            var removeQuantity = 1;

            // Act
            chartItem.AddQuantity(quantity);
            chartItem.RemoveQuantity(removeQuantity);

            // Assert
            chartItem.Quantity.Should().Be(2M);
        }

        [Test]
        public void Cannot_Decrement_Quantity_More_Available_Quantity_To_CharItem()
        {
            // Arrange
            var chartItem = new BasketItem("ProductA", 1, "EUR", 1);
            var quantity = 2;
            var removeQuantity = 4;

            // Act
            chartItem.AddQuantity(quantity);
            chartItem.RemoveQuantity(removeQuantity);

            // Assert
            chartItem.Quantity.Should().Be(0M);
        }
    }
}

