using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebDriverBasic.po
{
    class ProductPage
    {
        private IWebDriver driver;

        public ProductPage(IWebDriver driver)
        {
            this.driver = driver;
        }
    }
}
