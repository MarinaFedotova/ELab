using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using WebDriverBasic.business_objects;
using WebDriverBasic.po.page_components;

namespace WebDriverBasic.po
{
    class AllProductsPage
    {
        private IWebDriver driver;

        public AllProductsPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        private int CountProducts => driver.FindElements(By.XPath("//table//tr")).Count;
        private IWebElement CreateNewButton => driver.FindElement(By.LinkText("Create new"));

        public int GetCountProducts()
        {
            return CountProducts;
        }

        public ProductPage ClickOnCreateNew()
        {
            new Actions(driver).SendKeys(CreateNewButton, Keys.Enter).Build().Perform();
            return new ProductPage(driver);
        }

        public bool ProductInTable(Product product)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//table//tr[" + product.Index + "]")));
                return false;
            }
            catch (Exception){return true;}
        }

        public ProductPage ClickOnLinkProduct(Product product)
        {
            driver.FindElement(By.XPath("//table//tr[" + product.Index + "]/td[2]/a")).Click();
            return new ProductPage(driver);
        }

        public void ClickOnRemoveProduct(Product product)
        {
            driver.FindElement(By.XPath("//table//tr[" + product.Index + "]//td[12]/a")).Click();
        }

        public void ClickOnYesPopUpWindow()
        {
            driver.SwitchTo().Alert().Accept();
        }

        public bool SearchNotFormCreate()
        {
            try
            {
                driver.FindElement(By.CssSelector("form[action='/Product/Create']"));
                return true;
            }
            catch (NoSuchElementException) { return false; }
        }
    }
}
