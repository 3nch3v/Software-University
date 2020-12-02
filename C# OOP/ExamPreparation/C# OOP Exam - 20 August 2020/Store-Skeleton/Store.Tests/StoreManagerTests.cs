using System;
using System.Linq;
using NUnit.Framework;

namespace Store.Tests
{
    public class StoreManagerTests
    {
        private StoreManager storeManager;

        [SetUp]
        public void Setup()
        {
            storeManager = new StoreManager();
        }

        [Test]
        public void NotNuull()
        {
           Assert.IsNotNull(storeManager);
        }

        [Test]
        public void ProductsRepositoryShouldBeIntialized()
        {
            var products = storeManager.Products;
            Assert.IsNotNull(products);
        }

        [Test]
        public void CountSholdReturnTheProductsCount()
        {
            int actualReuslt = storeManager.Count;
            int expectedResult = 0;

            Assert.AreEqual(expectedResult, actualReuslt);
        }

        [Test]
        public void ProductShouldNotBeNullWhenAdd()
        {
            Product product = null;
            Assert.Throws<ArgumentNullException>(() => storeManager.AddProduct(product));
        }

        [Test]
        public void ProductQtyShouldNotBeZero()
        {
            Product product = new Product("Nokia", 0, 100);
            Assert.Throws<ArgumentException>(() => storeManager.AddProduct(product));
        }

        [Test]
        public void ProductQtyShouldNotBeLessThanZero()
        {
            Product product = new Product("Nokia", -2, 100);
            Assert.Throws<ArgumentException>(() => storeManager.AddProduct(product));
        }

        [Test]
        public void AddProduct()
        {
            Product product = new Product("Nokia", 1, 100);
            storeManager.AddProduct(product);

            int actualReuslt = storeManager.Count;
            int expectedResult = 1;

            Assert.AreEqual(expectedResult, actualReuslt);
        }

        [Test]
        public void BuyProductShouldNotBeNull()
        {
            Assert.Throws<ArgumentNullException>(() => storeManager.BuyProduct("Ivan", 1000));
        }

        [Test]
        public void BuyProductQtyShouldNotLassThanTheAvaileble()
        {
            Product product = new Product("Nokia", 1, 100);
            storeManager.AddProduct(product);

            Assert.Throws<ArgumentException>(() => storeManager.BuyProduct("Nokia", 2));
        }

        [Test]
        public void BuyProductQtyShouldDecreseWhenBougth()
        {
            Product product = new Product("Nokia", 2, 100);
            storeManager.AddProduct(product);
            storeManager.BuyProduct("Nokia", 1);

            int actual = storeManager.Products.First(p => p.Name == "Nokia").Quantity;
            int expected = 1;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void finalPrice()
        {
            Product product = new Product("Nokia", 3, 100);
            storeManager.AddProduct(product);
            storeManager.BuyProduct("Nokia", 2);

            decimal actual = storeManager.Products.First(p => p.Name == "Nokia").Price * 2;
            int expected = 200;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetTheMostExpensiveProduct()
        {
            Product product1 = new Product("Nokia3310", 3, 200);
            Product product2 = new Product("Nokia", 3, 100);
            storeManager.AddProduct(product1);
            storeManager.AddProduct(product2);

            var product = storeManager.GetTheMostExpensiveProduct();
            var expected = product1;

            Assert.AreEqual(expected, product);
        }

        [Test]
        public void GetTheMostExpensiveProductNull()
        {

            var product = storeManager.GetTheMostExpensiveProduct();
            Product expected = null;

            Assert.AreEqual(expected, product);
        }

    }
}