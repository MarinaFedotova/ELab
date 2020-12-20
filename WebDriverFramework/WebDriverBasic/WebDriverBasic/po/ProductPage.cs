using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Text;
using WebDriverBasic.business_objects;
using WebDriverBasic.po.page_components;

namespace WebDriverBasic.po
{
    class ProductPage
    {
        private IWebDriver driver;

        public ProductPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        private IWebElement FieldProductName => driver.FindElement(By.Id("ProductName"));
        private IWebElement FieldCategoryId => driver.FindElement(By.Id("CategoryId"));
        private IWebElement FieldSupplierId => driver.FindElement(By.Id("SupplierId"));
        private IWebElement FieldPriceUnit => driver.FindElement(By.Id("UnitPrice"));
        private IWebElement FieldQuantityPerUnit => driver.FindElement(By.Id("QuantityPerUnit"));
        private IWebElement FieldUnitsInStock => driver.FindElement(By.Id("UnitsInStock"));
        private IWebElement FieldUnitsOnOrder => driver.FindElement(By.Id("UnitsOnOrder"));
        private IWebElement FieldReorderLevel => driver.FindElement(By.Id("ReorderLevel"));
        private IWebElement CheckBoxDiscontinued => driver.FindElement(By.Id("Discontinued"));
        private IWebElement SendNewProductButton => driver.FindElement(By.CssSelector(".btn"));

        public string GetProductNameValue()
        {
            return FieldProductName.GetAttribute("value");
        }

        public string GetCategoryNameText()
        {
            return FieldCategoryId.FindElement(By.XPath("./option[@selected=\"selected\"]")).Text;
        }

        public string GetSupplierNameText()
        {
            return FieldSupplierId.FindElement(By.XPath("./option[@selected=\"selected\"]")).Text;
        }

        public string GetUnitPriceValue()
        {
            string unitPrice = FieldPriceUnit.GetAttribute("value");
            return unitPrice.Substring(0, unitPrice.Length - 5);
        }

        public string GetQuantityPerUnitValue()
        {
            return FieldQuantityPerUnit.GetAttribute("value");
        }

        public string GetUnitsInStockValue()
        {
            return FieldUnitsInStock.GetAttribute("value");
        }

        public string GetUnitsOnOrderValue()
        {
            return FieldUnitsOnOrder.GetAttribute("value");
        }

        public string GetReorderLevelValue()
        {
            return FieldReorderLevel.GetAttribute("value");
        }

        public string GetDiscontinuedValue()
        {
            if (String.Compare(CheckBoxDiscontinued.GetAttribute("checked"), "true") == 0) return "True";
            else return "False";
        }

        public void InputProductName(Product product)
        {
            new Actions(driver).SendKeys(FieldProductName, product.ProductName).Build().Perform();
        }

        public void InputCategoryName(Product product)
        {
            new Actions(driver).Click(FieldCategoryId).SendKeys(product.CategoryName).Build().Perform();
        }

        public void InputSupplierName(Product product)
        {
            new Actions(driver).Click(FieldSupplierId).SendKeys(product.SupplierName).Build().Perform();
        }

        public void InputUnitPrice(Product product)
        {
            new Actions(driver).SendKeys(FieldPriceUnit, product.UnitPrice).Build().Perform();
        }

        public void InputQuantityPerUnit(Product product)
        {
            new Actions(driver).SendKeys(FieldQuantityPerUnit, product.QuantityPerUnit).Build().Perform();
        }

        public void InputUnitsInStock(Product product)
        {
            new Actions(driver).SendKeys(FieldUnitsInStock, product.UnitsInStock.ToString()).Build().Perform();
        }

        public void InputUnitsOnOrder(Product product)
        {
            new Actions(driver).SendKeys(FieldUnitsOnOrder, product.UnitsOnOrder).Build().Perform();
        }

        public void InputReorderLevel(Product product)
        {
            new Actions(driver).SendKeys(FieldReorderLevel, product.ReorderLevel).Build().Perform();
        }

        public void ClickOnDiscontinued(Product product)
        {
            if (String.Compare(product.Discontinued, "True") == 0)
            new Actions(driver).Click(CheckBoxDiscontinued).Build().Perform();
        }

        public AllProductsPage ClickOnSendNewProduct()
        {
            new Actions(driver).Click(SendNewProductButton).Build().Perform();
            return new AllProductsPage(driver);
        }
    }
}
