using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using WebDriverBasic.business_objects;
using WebDriverBasic.po;
using WebDriverBasic.po.page_components;

namespace WebDriverBasic.service.ui
{
    class ProductService
    {
        private static WebDriverWait wait;
        public static AllProductsPage CreateNewProduct(Product product, IWebDriver driver)
        {
            LoggedPage loggedPage = new LoggedPage(driver);
            AllProductsPage allProductsPage = loggedPage.ClickOnAllProducts();
            int index = allProductsPage.GetCountProducts() + 1;
            ProductPage productPage = allProductsPage.ClickOnCreateNew();
            product.Index = index;
            productPage.InputProductName(product);
            productPage.InputCategoryName(product);
            productPage.InputSupplierName(product);
            productPage.InputUnitPrice(product);
            productPage.InputQuantityPerUnit(product);
            productPage.InputUnitsInStock(product);
            productPage.InputUnitsOnOrder(product);
            productPage.InputReorderLevel(product);
            productPage.ClickOnDiscontinued(product);
            return productPage.ClickOnSendNewProduct();
        }

        public static AllProductsPage DeleteProduct(Product product, IWebDriver driver)
        {
            AllProductsPage allProductsPage = new AllProductsPage(driver);
            allProductsPage.ClickOnRemoveProduct(product);
            allProductsPage.ClickOnYesPopUpWindow();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//table//tr[" + product.Index + "]")));
            return allProductsPage;
        }

        public static ProductPage OpenProduct(Product product, IWebDriver driver)
        {
            AllProductsPage allProductsPage = new AllProductsPage(driver);
            return allProductsPage.ClickOnLinkProduct(product);
        }

        public static AllProductsPage OpenTableProducts(IWebDriver driver)
        {
            NavBar navBar = new NavBar(driver);
            return navBar.ClickOnLinkProducts();
        }
    }
}
