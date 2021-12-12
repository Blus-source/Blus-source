using System;
using DouceSody.Domain;
using FluentAssertions;
using NUnit.Framework;

namespace DouceSody.Tests
{
    [TestFixture]
    public class ShopTests
    {
        [Test]
        public void Should_Add_Product_To_Shop_When_Product_IsValid()
        {
            // Arrange
            var shop = new Shop("Test");
            var product = new Product("ProductA", 10, 10, "ImageA", "EUR");

            // Act
            shop.AddProduct(product);

            // Assert
            shop.Products.Should().ContainSingle(p => p == product);
        }

        [Test]
        public void Should_Remove_Product_From_Shop_When_ProductsOfShop_Contains_Product_To_Remove()
        {
            // Arrange
            var shop = new Shop("Test");
            var productA = new Product("ProductA", 10, 10, "ImageA", "EUR");
            var productB = new Product("ProductB", 10, 10, "ImageB", "EUR");

            // Act
            shop.AddProduct(productA);
            shop.AddProduct(productB);
            shop.RemoveProduct(productA);

            // Assert
            shop.Products.Should().ContainSingle(p => p == productB);
            shop.Products.Should().NotContain(p => p == productA);
        }

        [Test]
        public void Should_Returns_Exception_When_Product_Already_Exits_In_ProductsOfShop()
        {
            // Arrange
            var shop = new Shop("Test");
            var productA = new Product("ProductA", 10, 10, "ImageA", "EUR");
            var productB = new Product("ProductA", 10, 10, "ImageA", "EUR");

            // Act
            shop.AddProduct(productA);
      
            Action action = () => shop.AddProduct(productB) ;

            // Assert
            action.Should().Throw<InvalidOperationException>();
        }

        [Test]
        public void Should_Returns_Exception_When_Product_Not_Exits_In_ProductsOfShop()
        {
            // Arrange
            var shop = new Shop("Test");
            var productA = new Product("ProductA", 10, 10, "ImageA", "EUR");

            // Act
            Action action = () => shop.RemoveProduct(productA);

            // Assert
            action.Should().Throw<InvalidOperationException>();
        }

        [Test]
        public void Should_Add_Product_To_Cart_When_Product_IsSelected_Except_BasketToBeFullFill_By_SelectedProduct()
        {
            // Arrange
            var shop = new Shop("Test");
            var product = new Product("ProductA", 10, 10, "ImageA", "EUR");
            var purchaseQuantity = 5;

            // Act
            shop.AddProduct(product);
            shop.AddChart(product.Name, purchaseQuantity);

            // Assert
            shop.Basket.Should().ContainSingle(p => p.ProductName == product.Name
            && p.Quantity == purchaseQuantity);
        }

        [Test]
        public void Should_Add_Quantity_To_Correct_Product_When_Product_Already_In_Cart_Except_Quantity_Of_Product_In_Cart_ToIncrease()
        {
            // Arrange
            var shop = new Shop("Test");
            var productA = new Product("ProductA", 10, 10, "ImageA", "EUR");
            var productB = new Product("ProductB", 10, 10, "ImageB", "EUR");
            var firstPurchaseQuantity = 5;
            var secondPurchaseQuantity = 1;

            // Act
            shop.AddProduct(productA);
            shop.AddProduct(productB);
            shop.AddChart(productA.Name, firstPurchaseQuantity);
            shop.AddChart(productB.Name, firstPurchaseQuantity);
            shop.AddChart(productB.Name, secondPurchaseQuantity);


            // Assert
            shop.Basket.Should().ContainSingle(p => p.ProductName == productB.Name
            && p.Quantity == 6);
        }

        [Test]
        public void Should_Return_Empty_Basket_When_Cart_Contains_Products_And_ClearMethod_Is_Called_Except_BasketToBeEmpty()
        {
            // Arrange
            var shop = new Shop("Test");
            var product = new Product("ProductA", 10, 10, "ImageA", "EUR");
            var purchaseQuantity = 5;

            // Act
            shop.AddProduct(product);
            shop.AddChart(product.Name, purchaseQuantity);
            shop.ClearChart();

            // Assert
            shop.Basket.Should().BeEmpty();
        }

        [Test]
        public void Should_Return_Products_Numbers_In_Cart_When_Cart_Contains_Products_Except_Two()
        {
            // Arrange
            var shop = new Shop("Test");
            var productA = new Product("ProductA", 10, 10, "ImageA", "EUR");
            var productB = new Product("ProductB", 10, 10, "ImageB", "EUR");
            var firstPurchaseQuantity = 2;
            var secondPurchaseQuantity = 3;

            // Act
            shop.AddProduct(productA);
            shop.AddProduct(productB);
            shop.AddChart(productA.Name, firstPurchaseQuantity);
            shop.AddChart(productB.Name, secondPurchaseQuantity);

            // Assert
            shop.TotalPurchasingItems.Should().Be(2);
        }

        [Test]
        public void Should_Return_Total_Products_Quantity_In_Cart_When_Cart_Contains_Products_Except_Fifty()
        {
            // Arrange
            var shop = new Shop("Test");
            var productA = new Product("ProductA", 10, 10, "ImageA", "EUR");
            var productB = new Product("ProductB", 10, 10, "ImageB", "EUR");
            var firstPurchaseQuantity = 2;
            var secondPurchaseQuantity = 3;

            // Act
            shop.AddProduct(productA);
            shop.AddProduct(productB);
            shop.AddChart(productA.Name, firstPurchaseQuantity);
            shop.AddChart(productB.Name, secondPurchaseQuantity);

            // Assert
            shop.TotalPricePurchasing.Should().Be(50);
        }

        [Test]
        public void Purchasing_Product_Should_Have_Same_Currency_In_Chart_And_In_Products()
        {
            // Arrange
            var shop = new Shop("Test");
            var productA = new Product("ProductA", 10, 10, "ImageA", "USD");
            var productB = new Product("ProductB", 10, 10, "ImageB", "EUR");
            var firstPurchaseQuantity = 2;
            var secondPurchaseQuantity = 3;

            // Act
            shop.AddProduct(productA);
            shop.AddProduct(productB);
            shop.AddChart(productA.Name, firstPurchaseQuantity);
            shop.AddChart(productB.Name, secondPurchaseQuantity);

            // Assert
            shop.Basket.Should().ContainSingle(a => a.ProductName == "ProductA" && a.Currency == "USD");
            shop.Basket.Should().ContainSingle(a => a.ProductName == "ProductB" && a.Currency == "EUR");
        }

        [Test]
        public void Purchasing_Product_Should_Have_Same_Price_In_Chart_And_In_Products()
        {
            // Arrange
            var shop = new Shop("Test");
            var productA = new Product("ProductA", 10, 10, "ImageA", "USD");
            var productB = new Product("ProductB", 20, 10, "ImageB", "EUR");
            var firstPurchaseQuantity = 2;
            var secondPurchaseQuantity = 3;

            // Act
            shop.AddProduct(productA);
            shop.AddProduct(productB);
            shop.AddChart(productA.Name, firstPurchaseQuantity);
            shop.AddChart(productB.Name, secondPurchaseQuantity);

            // Assert
            shop.Basket.Should().ContainSingle(a => a.ProductName == "ProductA" &&  a.Price == 10);
            shop.Basket.Should().ContainSingle(a => a.ProductName == "ProductB" &&  a.Price == 20);
        }

        [Test]
        public void Delete_Product_From_Chart()
        {
            // Arrange
            var shop = new Shop("Test");
            var productA = new Product("ProductA", 10, 10, "ImageA", "USD");
            var productB = new Product("ProductB", 20, 10, "ImageB", "EUR");
            var firstPurchaseQuantity = 2;
            var secondPurchaseQuantity = 3;

            // Act
            shop.AddProduct(productA);
            shop.AddProduct(productB);
            shop.AddChart(productA.Name, firstPurchaseQuantity);
            shop.AddChart(productB.Name, secondPurchaseQuantity);
            shop.RemoveProductFromChart(productA.Name);

            // Assert
            shop.Basket.Should().NotContain(a => a.ProductName == "ProductA");
            shop.Basket.Should().ContainSingle(a => a.ProductName == "ProductB");
        }

        [Test]
        public void Cannot_Add_Product_Without_Any_Purchased_Quantity_In_Chart()
        {
            // Arrange
            var shop = new Shop("Test");
            var productA = new Product("ProductA", 10, 10, "ImageA", "USD");
            var firstPurchaseQuantity = 0;

            // Act
            shop.AddProduct(productA);
            shop.AddChart(productA.Name, firstPurchaseQuantity);

            // Assert
            shop.Basket.Should().BeEmpty();
        }

        [Test]
        public void Should_Set_Delivery_Address_To_Shop_When_Product_IsValid_Except_DeliveryAddressToBeFullFill()
        {
            // Arrange
            var shop = new Shop("Test");
            var selectedAdress = "Address2";

            // Act
            shop.SetDeliveryAddress(selectedAdress);

            // Assert
            shop.Addresses.Should().ContainSingle(address => address.Code == selectedAdress);
            shop.DeliveryAddres.Code.Should().Be(selectedAdress);
        }
    }
}

