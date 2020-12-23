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

        public static Product CreateProductFromFields(IWebDriver driver)
        {
            ProductPage productPage = new ProductPage(driver);
            string name = productPage.GetProductNameValue();
            string category = productPage.GetCategoryNameText();
            string supplier = productPage.GetSupplierNameText();
            int price = Convert.ToInt32(productPage.GetUnitPriceValue());
            string quantity = productPage.GetQuantityPerUnitValue();
            int stock = Convert.ToInt32(productPage.GetUnitsInStockValue());
            int order = Convert.ToInt32(productPage.GetUnitsOnOrderValue());
            int level = Convert.ToInt32(productPage.GetReorderLevelValue());
            bool discontinued = productPage.GetDiscontinuedValue();
            Product product = new Product(name, category, supplier, price, quantity, stock, order, level, discontinued);
            return product;
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
