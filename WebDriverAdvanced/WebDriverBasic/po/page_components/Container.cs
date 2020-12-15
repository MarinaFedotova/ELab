using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebDriverBasic.po.page_components
{
    class Container
    {
        private IWebDriver driver;

        public Container(IWebDriver driver)
        {
            this.driver = driver;
        }

        IWebElement TitlePage => driver.FindElement(By.XPath("//h2"));

        public string GetTitlePage()
        {
            return TitlePage.Text;
        }
    }
}
