using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebDriverBasic.po.page_components
{
    class NavBar
    {
        private IWebDriver driver;

        public NavBar(IWebDriver driver)
        {
            this.driver = driver;
        }

        IWebElement ProductsLink => driver.FindElement(By.XPath("//li//a[text()=\"Products\"]"));
        IWebElement LogoutLink => driver.FindElement(By.LinkText("Logout"));

        public MainPage ClickOnLinkLogout()
        {
            new Actions(driver).Click(LogoutLink).Build().Perform();
            return new MainPage(driver);
        }

        public AllProductsPage ClickOnLinkProducts()
        {
            new Actions(driver).Click(ProductsLink).Build().Perform();
            return new AllProductsPage(driver);
        }
    }
}
