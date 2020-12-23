using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using WebDriverBasic.business_objects;
using WebDriverBasic.po;
using WebDriverBasic.service.ui;
using WebDriverBasic.tests;

namespace WebDriverBasic
{
    public class ProductTests : BaseTest
    {
        private MainPage mainPage;
        private LoggedPage loggedPage;
        private AllProductsPage allProductsPage;
        private readonly Product myTea = new Product("Tea", "Beverages", "Tokyo Traders", 100, "10", 200, 20, 10, true);
        private readonly User myUser = new User("user", "user");

        [Test, Order(1)]
        public void CheckLogin()
        {
            loggedPage = UserService.Login(myUser, driver);
            Assert.AreEqual(loggedPage.container.GetTitlePage(), "Home page");
        }

        [Test, Order(2)]
        public void TestNewProduct()
        {
            allProductsPage = ProductService.CreateNewProduct(myTea, driver);
            Assert.IsFalse(allProductsPage.IsElementPresent(allProductsPage.ByFormCreate));
            Assert.IsTrue(allProductsPage.IsElementPresent(allProductsPage.SearchByProductInTable(myTea)));
        }

        [Test, Order(3)]
        public void TestOpenNewProduct()
        {
            ProductService.OpenProduct(myTea, driver);
            Product productTea = ProductService.CreateProductFromFields(driver);
            Assert.AreEqual(myTea, productTea);
        }

        [Test, Order(4)]
         public void TestDeleteNewProduct()
        {
            allProductsPage = ProductService.OpenTableProducts(driver);
            allProductsPage = ProductService.DeleteProduct(myTea, driver);
            Assert.IsFalse(allProductsPage.IsElementPresent(allProductsPage.SearchByProductInTable(myTea)));
        }

        [Test, Order(5)]
        public void TestLogout()
        {
            mainPage = UserService.SignOut(driver);
            Assert.IsTrue(mainPage.SearchFormLogin());
        }
    }
}