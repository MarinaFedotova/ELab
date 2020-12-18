using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using WebDriverBasic.po.page_components;

namespace WebDriverBasic.po
{
    class AllProductsPage
    {
        private IWebDriver driver;
        public NavBar navBar;

        public AllProductsPage(IWebDriver driver)
        {
            this.driver = driver;
            navBar = new NavBar(driver);
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

        public bool ProductInTable(int index)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//table//tr[" + index + "]")));
                return false;
            }
            catch (Exception){return true;}
        }

        public ProductPage ClickOnLinkProduct(int index)
        {
            driver.FindElement(By.XPath("//table//tr[" + index + "]/td[2]/a")).Click();
            return new ProductPage(driver);
        }

        public void ClickOnRemoveProduct(int index)
        {
            driver.FindElement(By.XPath("//table//tr[" + index + "]//a[text()=\"Remove\"]")).Click();
        }

        public void ClickOnYesPopUpWindow()
        {
            driver.SwitchTo().Alert().Accept();
        }
    }
}
