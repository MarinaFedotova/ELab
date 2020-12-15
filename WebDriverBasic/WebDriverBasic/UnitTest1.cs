using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;

namespace WebDriverBasic
{
    public class Tests
    {
        private IWebDriver driver;
        public static int count;
        [OneTimeSetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://localhost:5000");
        }

        [Test, Order(1)]
        public void CheckLogin()
        {
            driver.FindElement(By.Id("Name")).SendKeys("user");
            driver.FindElement(By.Id("Password")).SendKeys("user");
            driver.FindElement(By.CssSelector(".btn")).Click();
            string text = driver.FindElement(By.XPath("//h2")).Text;
            Assert.AreEqual(text, "Home page");
        }

        [Test, Order(2)]
        public void TestNewProduct()
        {
            driver.FindElement(By.XPath("//div/child::a[@href=\"/Product\"]")).Click();
            count = driver.FindElements(By.XPath("//table//tr")).Count;
            driver.FindElement(By.LinkText("Create new")).Click();
            driver.FindElement(By.Id("ProductName")).SendKeys("Tea");
            driver.FindElement(By.XPath("//select[@name=\"CategoryId\"]/option[@value=1]")).Click();
            driver.FindElement(By.XPath("//select[@name=\"SupplierId\"]/option[@value=7]")).Click();
            driver.FindElement(By.Id("UnitPrice")).SendKeys("1245");
            driver.FindElement(By.Id("QuantityPerUnit")).SendKeys("100");
            driver.FindElement(By.Id("UnitsInStock")).SendKeys("54");
            driver.FindElement(By.Id("UnitsOnOrder")).SendKeys("14");
            driver.FindElement(By.Id("ReorderLevel")).SendKeys("7");
            driver.FindElement(By.Id("Discontinued")).Click();

            driver.FindElement(By.CssSelector(".btn")).Click();
            Assert.IsEmpty(driver.FindElements(By.XPath("//form[@action=\"/Product/Create\"]")));
            count++;
            Assert.IsTrue(driver.FindElement(By.XPath("//table//tr[" + count + "]")).Displayed);
        }
        
        [Test, Order(3)]
        public void TestOpenNewProduct()
        {
            driver.FindElement(By.XPath("//table//tr[" + count + "]/td[2]/a")).Click();
            Assert.AreEqual("Tea", driver.FindElement(By.XPath("//input[@id=\"ProductName\"]")).GetAttribute("value"));
            Assert.AreEqual("1", driver.FindElement(By.Id("CategoryId")).GetAttribute("value"));
            Assert.AreEqual("7", driver.FindElement(By.Id("SupplierId")).GetAttribute("value"));
            Assert.AreEqual("1245,0000", driver.FindElement(By.Id("UnitPrice")).GetAttribute("value"));
            Assert.AreEqual("100", driver.FindElement(By.Id("QuantityPerUnit")).GetAttribute("value"));
            Assert.AreEqual("54", driver.FindElement(By.Id("UnitsInStock")).GetAttribute("value"));
            Assert.AreEqual("14", driver.FindElement(By.Id("UnitsOnOrder")).GetAttribute("value"));
            Assert.AreEqual("7", driver.FindElement(By.Id("ReorderLevel")).GetAttribute("value"));
            Assert.AreEqual("true", driver.FindElement(By.Id("Discontinued")).GetAttribute("value"));
        }

        [Test, Order(4)]
        public void TestDeleteNewProduct()
        {
            driver.FindElement(By.XPath("//li//a[text()=\"Products\"]")).Click();
            driver.FindElement(By.XPath("//table//tr[" + count + "]//a[text()=\"Remove\"]")).Click();
            driver.SwitchTo().Alert().Accept();

             Assert.AreEqual("Tea", driver.FindElement(By.XPath("//table//tr["+count+"]//a[text()=\"Tea\"]")).Text);
        }
        

        [Test, Order(5)]
        public void TestLogout()
        {
            driver.FindElement(By.LinkText("Logout")).Click();
            IWebElement element = driver.FindElement(By.XPath("//form[@action=\"/Account/Login\"]"));
            Assert.IsTrue(element.Displayed);
        }
        
        [OneTimeTearDown]
        public void CloseDriver()
        {
            driver.Close();
            driver.Quit();
        }
    }
}