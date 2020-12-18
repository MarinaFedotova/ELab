using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Text;
using WebDriverBasic.po.page_components;

namespace WebDriverBasic.po
{
    class ProductPage
    {
        private IWebDriver driver;
        public NavBar navBar;

        public ProductPage(IWebDriver driver)
        {
            this.driver = driver;
            navBar = new NavBar(driver);
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
            return FieldPriceUnit.GetAttribute("value");
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
            return CheckBoxDiscontinued.GetAttribute("value");
        }

        public void InputProductName(string name)
        {
            new Actions(driver).SendKeys(FieldProductName, name).Build().Perform();
        }

        public void InputCategoryName(string name)
        {
            new Actions(driver).Click(FieldCategoryId).SendKeys(name).Build().Perform();
        }

        public void InputSupplierName(string name)
        {
            new Actions(driver).Click(FieldSupplierId).SendKeys(name).Build().Perform();
        }

        public void InputUnitPrice(int price)
        {
            new Actions(driver).SendKeys(FieldPriceUnit, price.ToString()).Build().Perform();
        }

        public void InputQuantityPerUnit(string quantity)
        {
            new Actions(driver).SendKeys(FieldQuantityPerUnit, quantity).Build().Perform();
        }

        public void InputUnitsInStock(int unit)
        {
            new Actions(driver).SendKeys(FieldUnitsInStock, unit.ToString()).Build().Perform();
        }

        public void InputUnitsOnOrder(int unit)
        {
            new Actions(driver).SendKeys(FieldUnitsOnOrder, unit.ToString()).Build().Perform();
        }

        public void InputReorderLevel(int level)
        {
            new Actions(driver).SendKeys(FieldReorderLevel, level.ToString()).Build().Perform();
        }

        public void ClickOnDiscontinued()
        {
            new Actions(driver).Click(CheckBoxDiscontinued).Build().Perform();
        }

        public AllProductsPage ClickOnSendNewProduct()
        {
            new Actions(driver).Click(SendNewProductButton).Build().Perform();
            return new AllProductsPage(driver);
        }

        public bool SearchNotFormCreate()
        {
            try
            {
                driver.FindElement(By.CssSelector("form[action='/Product/Create']"));
                return true;
            }
            catch(NoSuchElementException) {return false;}
        }
    }
}
