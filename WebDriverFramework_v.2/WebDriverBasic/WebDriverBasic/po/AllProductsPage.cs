using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using WebDriverBasic.business_objects;

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
        private IWebElement TableProduct => driver.FindElement(By.XPath("//table"));
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
                TableProduct.FindElement(By.XPath(".//tr[" + product.Index + "]"));
                return true;
            }
            catch (NoSuchElementException) { return false; }
        }

        public ProductPage ClickOnLinkProduct(Product product)
        {
            TableProduct.FindElement(By.XPath(".//tr[" + product.Index + "]/td[2]/a")).Click();
            return new ProductPage(driver);
        }

        public void ClickOnRemoveProduct(Product product)
        {
            TableProduct.FindElement(By.XPath(".//tr[" + product.Index + "]//td[12]/a")).Click();
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
