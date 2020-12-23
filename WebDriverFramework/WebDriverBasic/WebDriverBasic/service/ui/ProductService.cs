using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using WebDriverBasic.business_objects;
using WebDriverBasic.po;
using WebDriverBasic.po.page_components;

namespace WebDriverBasic.service.ui
{
    class ProductService
    {
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

        public static bool CompareProductInEdit(Product product, IWebDriver driver)
        {
            ProductPage productPage = new ProductPage(driver);
            if (product == null) return false;
            return product.ProductName == productPage.GetProductNameValue() &&
                product.CategoryName == productPage.GetCategoryNameText() &&
                product.SupplierName == productPage.GetSupplierNameText() &&
                product.UnitPrice == productPage.GetUnitPriceValue() &&
                product.QuantityPerUnit == productPage.GetQuantityPerUnitValue() &&
                product.UnitsInStock == productPage.GetUnitsInStockValue() &&
                product.UnitsOnOrder == productPage.GetUnitsOnOrderValue() &&
                product.ReorderLevel == productPage.GetReorderLevelValue() &&
                product.Discontinued == productPage.GetDiscontinuedValue();
        }

        public static void DeleteProduct(Product product, IWebDriver driver)
        {
            AllProductsPage allProductsPage = new AllProductsPage(driver);
            allProductsPage.ClickOnRemoveProduct(product);
            allProductsPage.ClickOnYesPopUpWindow();
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
