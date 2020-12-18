using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebDriverBasic.po
{
    class MainPage
    {
        private IWebDriver driver;

        public MainPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        private IWebElement FieldName => driver.FindElement(By.Id("Name"));
        private IWebElement FieldPassword => driver.FindElement(By.Id("Password"));
        private IWebElement InputButton => driver.FindElement(By.CssSelector(".btn"));

        public LoggedPage ClickOnInputLogin(string name, string password)
        {
            new Actions(driver).SendKeys(FieldName, name).SendKeys(FieldPassword, password).Build().Perform();
            new Actions(driver).SendKeys(InputButton, Keys.Enter).Build().Perform();
            return new LoggedPage(driver);
        }

        public bool SearchFormLogin()
        {
            return driver.FindElement(By.XPath("//form[@action=\"/Account/Login\"]")).Displayed;
        }   
    }
}
