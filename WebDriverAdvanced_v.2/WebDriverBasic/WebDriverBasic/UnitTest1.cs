using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;
using WebDriverBasic.po;

namespace WebDriverBasic
{
    public class Tests
    {
        private IWebDriver driver;
        private MainPage mainPage;
        private LoggedPage loggedPage;
        private AllProductsPage allProductsPage;
        private ProductPage productPage;
        public int index;

        [OneTimeSetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://localhost:5000");
        }

        [Test, Order(1)]
        public void CheckLogin()
        {
            mainPage = new MainPage(driver);
            loggedPage = mainPage.ClickOnInputLogin("user", "user");
            Assert.AreEqual(loggedPage.container.GetTitlePage(), "Home page");
        }

        [Test, Order(2)]
        public void TestNewProduct()
        {
            allProductsPage = loggedPage.ClickOnAllProducts();
            int indexStarting = allProductsPage.GetCountProducts();
            productPage = allProductsPage.ClickOnCreateNew();
            
            productPage.InputProductName("Tea");
            productPage.InputCategoryName("Beverages");
            productPage.InputSupplierName("Tokyo Traders");
            productPage.InputUnitPrice(100);
            productPage.InputQuantityPerUnit("10");
            productPage.InputUnitsInStock(200);
            productPage.InputUnitsOnOrder(20);
            productPage.InputReorderLevel(10);
            productPage.ClickOnDiscontinued();
            
            allProductsPage = productPage.ClickOnSendNewProduct();
            index = allProductsPage.GetCountProducts();

            Assert.IsFalse(productPage.SearchNotFormCreate());
            Assert.AreEqual(indexStarting + 1, index);
            Assert.IsTrue(allProductsPage.ProductOnTable(index));
        }

        [Test, Order(3)]
        public void TestOpenNewProduct()
        {
            productPage = allProductsPage.ClickOnLinkProduct(index);
            Assert.AreEqual("Tea", productPage.GetProductNameValue());
            Assert.AreEqual("Beverages", productPage.GetCategoryNameText());
            Assert.AreEqual("Tokyo Traders", productPage.GetSupplierNameText());
            Assert.AreEqual("100,0000", productPage.GetUnitPriceValue());
            Assert.AreEqual("10", productPage.GetQuantityPerUnitValue());
            Assert.AreEqual("200", productPage.GetUnitsInStockValue());
            Assert.AreEqual("20", productPage.GetUnitsOnOrderValue());
            Assert.AreEqual("10", productPage.GetReorderLevelValue());
            Assert.AreEqual("true", productPage.GetDiscontinuedValue());
        }

        [Test, Order(4)]
        public void TestDeleteNewProduct()
        {
            allProductsPage = productPage.navBar.ClickOnLinkProducts();
            allProductsPage.ClickOnRemoveProduct(index);
            allProductsPage.ClickOnYesPopUpWindow();
            Thread.Sleep(1000);
            Assert.IsFalse(allProductsPage.ProductOnTable(index));
        }

        [Test, Order(5)]
        public void TestLogout()
        {
            mainPage = allProductsPage.navBar.ClickOnLinkLogout();
            Assert.IsTrue(mainPage.SearchFormLogin());
        }

        [OneTimeTearDown]
        public void CloseDriver()
        {
            driver.Close();
            driver.Quit();
        }
    }
}