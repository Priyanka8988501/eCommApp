using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace eCommApp.Tests
{
    public class ProductTests
    {
        // Test cases for ProductID
        [Test]
        public void VerifyProductIDWithinLowRange()
        {
            // Arrange
            var product = new Product(2, "Test Product", 10, 5);

            //Act
            var actual = product.ProductID;

            //Assert
            Assert.That(actual, Is.EqualTo(2));
        }

        [Test]
        public void VerifyProductIDWithinHighRange()
        {
            // Arrange
            var product = new Product(999, "Test Product", 10, 5);

            //Act
            var actual = product.ProductID;

            //Assert
            Assert.That(actual, Is.EqualTo(999));
        }

        [Test]
        public void VerifyProductIDWithinMidRange()
        {
            //Arrange
            var product = new Product(750, "Test Product", 10, 5);

            //Act
            var actual = product.ProductID;

            //Assert
            Assert.That(actual, Is.EqualTo(750));
        }

        // Test cases for ProductName
        [Test]
        public void VerifyProductNameIsSetCorrectly()
        {
            // Arrange
            var product = new Product(1, "Test Product", 10, 5);

            //Act
            var actual = product.ProductName;

            //Assert
            Assert.That(actual, Is.EqualTo("Test Product"));
        }

        [Test]
        public void VerifyProductNameAllowsSingleCharacter()
        {
            //Arrange
            var product = new Product(1, "A", 10, 5);

            //Act
            var actual = product.ProductName;

            //Assert
            Assert.That(actual, Is.EqualTo("A"));
        }

        [Test]
        public void VerifyProductNameAllowsLongString()
        {
            //Arrange
            var product = new Product(1, "This is a very long product name", 10, 5);

            //Act
            var actual = product.ProductName;

            //Assert
            Assert.That(actual, Is.EqualTo("This is a very long product name"));
        }

        // Test cases for Price
        [Test]
        public void VerifyPriceWithinLowRange()
        {
            //Arrange
            var product = new Product(1, "Sample Test Product", 1, 5);

            //Act
            var actual = product.Price;

            //Assert
            Assert.That(actual, Is.InRange(1, 5000));
        }

        [Test]
        public void VerifyPriceWithinHighRange()
        {
            //Arrange
            var product = new Product(1, "Test Product", 4999, 5);

            //Act
            var actual = product.Price;

            //Assert
            Assert.That(actual, Is.EqualTo(4999));
        }

        [Test]
        public void VerifyPriceWithinMidRange()
        {
            //Arrange
            var product = new Product(1, " Test Product", 2501, 5);

            //Act
            var actual = product.Price;

            //Assert
            Assert.That(actual, Is.EqualTo(2501));
        }

        // Test cases for Stock
        [Test]
        public void VerifyStockWithinLowRange()
        {
            //Arrange
            var product = new Product(1, "Test Product", 10, 2);

            //Act
            var actual = product.Stock;

            //Assert
            Assert.That(actual, Is.InRange(1, 1000));
        }

        [Test]
        public void VerifyStockWithinHighRange()
        {
            //Arrange
            var product = new Product(1, "Test Product", 10, 999);

            //Act
            var actual = product.Stock;

            //Assert
            Assert.That(actual, Is.EqualTo(999));
        }

        [Test]
        public void VerifyStockWithinMidRange()
        {
            //Arrange
            var product = new Product(1, "Test Product", 10, 750);

            //Act
            var actual = product.Stock;

            //Assert
            Assert.That(actual, Is.EqualTo(750));
        }

        // Test cases for Increase method

        [Test]
        public void VerifyIncreaseStockMethod()
        {
            //Arrange
            var product = new Product(1, "Test Product", 10, 5);

            //Act
            product.IncreaseStock(10);

            //Assert
            Assert.That(product.Stock, Is.EqualTo(15));
        }

        [Test]
        public void VerifyIncreaseStockMethodHandlesZeroIncrease()
        {
            //Arrange
            var product = new Product(1, "Test Product", 10, 5);

            //Act
            product.IncreaseStock(0);
            var actual = product.Stock;

            //Assert
            Assert.That(actual, Is.EqualTo(5));
        }

        [Test]
        public void VerifyIncreaseStockMethodThrowsExceptionWhenOutOfStock()
        {
            //Arange and Act
            var product = new Product(1, "Test Product", 20.0m, 50);
            
            //Assert
            Assert.That(() => product.IncreaseStock(1000), Throws.TypeOf<ArgumentOutOfRangeException>(), "Stock did not throw exception when exceeding max limit.");
        }

        // Test cases for Decrease method

        [Test]
        public void VerifyDecreaseStockMethod()
        {
            //Arrange
            var product = new Product(1, "Test Product", 10, 10);

            //Act
            product.DecreaseStock(5);

            //Assert
            Assert.That(product.Stock, Is.EqualTo(5));
        }

        [Test]
        public void VerifyDecreaseStockMethodHandlesZeroDecrease()
        {
            //Arrange
            var product = new Product(1, "Test Product", 10, 5);

            //Act
            product.DecreaseStock(0);
            var actual = product.Stock;

            //Assert
            Assert.That(actual, Is.EqualTo(5));
        }

        [Test]
        public void VerifyDecreaseStockMethodThrowsExceptionWhenStockIsZero()
        {
            //Arrange
            Product product = new Product(1, "Test Product", 10, 0);

            //Act and Assert
            Assert.Throws<InvalidOperationException>(() => product.DecreaseStock(1));
        }

    }

}
