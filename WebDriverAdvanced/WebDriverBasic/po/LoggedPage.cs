using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebDriverBasic.po
{
    class LoggedPage
    {
        private IWebDriver driver;

        public LoggedPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        IWebElement LinkAllProducts => driver.FindElement(By.XPath("//div/child::a[@href=\"/Product\"]"));

        public AllProductsPage ClickOnAllProducts()
        {
            new Actions(driver).SendKeys(LinkAllProducts, Keys.Enter).Build().Perform();
            return new AllProductsPage(driver);
        }
    }
}