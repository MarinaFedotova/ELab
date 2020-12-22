using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using WebDriverBasic.business_objects;

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
        private IWebElement FormAccountLogin => driver.FindElement(By.CssSelector("form[action='/Account/Login']"));

        public LoggedPage ClickOnInputLogin(User user)
        {
            new Actions(driver).SendKeys(FieldName, user.UserName).SendKeys(FieldPassword, user.UserPassword).Build().Perform();
            new Actions(driver).SendKeys(InputButton, Keys.Enter).Build().Perform();
            return new LoggedPage(driver);
        }

        public void InputLogin(string name, string password)
        {
            FieldName.SendKeys(name);
            FieldPassword.SendKeys(password);
        }

        public void ClickOnSendButton()
        {
            InputButton.Click();
        }

        public bool SearchFormLogin()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector("form[action='/Account/Login']")));
            return FormAccountLogin.Displayed;
        }   
    }
}
