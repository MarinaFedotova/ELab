using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;
using WebDriverBasic.po;

namespace WebDriverBasic.step_definitions
{
    [Binding]
    class ProductSteps
    {
        public int index;
        private IWebDriver driver; 
        [Given(@"I open ""(.+)"" url")]
        public void GivenIOpenMainPage(string url)
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl(url);
        }

        [When(@"I log into with username ""(.+)"" and password ""(.+)""")]
        public void WhenILogIntoWithUsernameAndPassword(string name, string password)
        {
            new MainPage(driver).InputLogin(name, password);
        }

        [When(@"I click on send button")]
        public void WhenIClickOnSendButton()
        {
            new MainPage(driver).ClickOnSendButton();
        }

        [Then(@"I should be at the home page")]
        public void ThenIShouldBeAtTheHomePage()
        {
            Assert.AreEqual(new LoggedPage(driver).container.GetTitlePage(), "Home page");
        }

        [When(@"I click on the all products link")]
        public void ThenIClickOnTheAllProductsLink()
        {
            new LoggedPage(driver).ClickOnAllProducts();
        }

        [When(@"I click on create new button")]
        public void ThenIClickOnCreateNewButton()
        {
            AllProductsPage allProductsPage = new AllProductsPage(driver);
            index = allProductsPage.GetCountProducts() + 1;
            allProductsPage.ClickOnCreateNew();

        }

        [When(@"I create a product with fields ""(.*)"", ""(.*)"", ""(.*)"", ""(.*)"", (.*), (.*), (.*), (.*), ""(.*)""")]
        public void WhenICreateAProductWithFields(string name, string category, string supplier, string quantity, int price, int stock, int order, int level, string discontinued)
        {
            ProductPage productPage = new ProductPage(driver);
            productPage.InputProductName(name);
            productPage.InputCategoryName(category);
            productPage.InputSupplierName(supplier);
            productPage.InputUnitPrice(price);
            productPage.InputQuantityPerUnit(quantity);
            productPage.InputUnitsInStock(stock);
            productPage.InputUnitsOnOrder(order);
            productPage.InputReorderLevel(level);
            productPage.ClickOnDiscontinued(discontinued);
        }

        [When(@"I click on send button product")]
        public void WhenIClickOnSendButtonProduct()
        {
            new ProductPage(driver).ClickOnSendNewProduct();
        }

        [Then(@"The form of creation disappeared")]
        public void ThenTheFormOfCreationDisappeared()
        {
            AllProductsPage allProductsPage = new AllProductsPage(driver);
            Assert.IsFalse(allProductsPage.IsElementPresent(allProductsPage.ByFormCreate));
        }

        [Then(@"The product should be on all products page")]
        public void ThenTheProductShouldBeOnAllProductsPage()
        {
            AllProductsPage allProductsPage = new AllProductsPage(driver);
            Assert.IsTrue(allProductsPage.IsElementPresent(allProductsPage.SearchByProductInTable(index)));
        }

        [AfterScenario]
        public void CloseDriver()
        {
            driver.Close();
            driver.Quit();
        }
    }
}
