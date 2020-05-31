using Frameworks.business_object;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using PageObjects;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace Frameworks.step_definition
{
    [Binding]
    class AddProductSteps
    {

        IWebDriver driver = new ChromeDriver();

        [Given(@"I open ""(.*)"" url")]
        public void GivenIOpenUrl(string url)
        {
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(url);
        }


        [Then(@"I should be at the ""(.*)"" Login page")] // Проверяем, что мы на нужной странице Login
        public void ThenLoginPageShouldBe(string LoginPageName)
        {
            Login login = new Login(driver);
            Assert.AreEqual(LoginPageName, login.PageAutorization());
        }

        [When(@"I type the value ""(.*)"" Name")] // Вводим имя пользователя
        public void WhenISendKeyUsername(string username)
        {
            new MainPage(driver).LoginEnter(new LoginValue(username, null));
        }

        [When(@"I type the value ""(.*)"" Password")] // Вводим пароль пользователя
        public void WhenISendKeyPassword(string password)
        {
            new MainPage(driver).PasswordEnter(new LoginValue(null, password));
        }

        [When(@"I click the login button")] // Подтверждаем ввод данных авторизации
        public void WhenIClickOnLoginButton()
        {
            new MainPage(driver).Autorization();
        }

        [Then(@"I should be at the ""(.*)"" Home page")] // Проверяем, что мы на нужной странице Home Page
        public void ThenHomePageShouldBe(string HomePageName)
        {
            Login login = new Login(driver);
            Assert.AreEqual(HomePageName, login.PageAutorization());
        }

        [When(@"I click on the link All Products")]  // кликаем на ссылку All Products
        public void WhenIClickOnLinkAllProducts()
        {
            new NewProducts(driver).ClickLinkAllProducts();
        }

        [When(@"I click the Create new button")]  // кликаем на кнопку "Create new"
        public void WhenIClickOnCreateNewButton()
        {
            new NewProducts(driver).ClickButtonCreateNew();
        }


        [Then(@"I should be at the ""(.*)"" Product editing page")]  // Проверяем, что мы на нужной странице ProductEditing
        public void ThenProductEditingShouldBe(string ecpectedProductEditing)
        {
            NewProducts newproduct = new NewProducts(driver);
            Assert.AreEqual(ecpectedProductEditing, newproduct.CheckProductEditingPage());
        }

        // Вносим данные в карточку продукта
        [When(@"I type the value ""(.*)"" ProductName")]
        public void WhenITypeValueProductName(string ProductName)
        {
            new NewProducts(driver).CreateNewProductsName(new Product(ProductName, null, null, null, null, null, null, null, null));
        }


        [When(@"I select ""(.*)"" Category")]
        public void WhenITypeValueCategoryID(string CategoryID)
        {
            new NewProducts(driver).SelectNewCategoryId(new Product(null, CategoryID, null, null, null, null, null, null, null));
        }

        [When(@"I select ""(.*)"" Supplier")]
        public void WhenITypeValueSupplier(string Supplier)
        {
            new NewProducts(driver).SelectNewSupplierId(new Product(null, null, Supplier, null, null, null, null, null, null));
        }

        [When(@"I type the value ""(.*)"" UnitPrice")]
        public void WhenITypeValueUnitPrice(string UnitPrice)
        {
            new NewProducts(driver).SendKeyNewUnitPrice(new Product(null, null, null, UnitPrice, null, null, null, null, null));
        }


        [When(@"I type the value ""(.*)"" QuantityPerUnit")]
        public void WhenITypeValueQuantityPerUnit(string QuantityPerUnit)
        {
            new NewProducts(driver).SendKeyNewQuantityPerUnit(new Product(null, null, null, null, QuantityPerUnit, null, null, null, null));
        }


        [When(@"I type the value ""(.*)"" UnitsInStock")]
        public void WhenITypeValueUnitsInStock(string UnitsInStock)
        {
            new NewProducts(driver).SendKeyNewUnitsInStock(new Product(null, null, null, null, null, UnitsInStock, null, null, null));
        }

        [When(@"I type the value ""(.*)"" UnitsOnOrder")]
        public void WhenITypeValueUnitsOnOrder(string UnitsOnOrder)
        {
            new NewProducts(driver).SendKeyNewUnitsOnOrder(new Product(null, null, null, null, null, null, UnitsOnOrder, null, null));
        }

        [When(@"I type the value ""(.*)"" ReorderLevel")]
        public void WhenITypeValueReorderLevel(string ReorderLevel)
        {
            new NewProducts(driver).SendKeyNewReorderLevel(new Product(null, null, null, null, null, null, null, ReorderLevel, null));
        }


        [When(@"I click the Send button")]
        public void WhenIClickOnSendButton()
        {
            new NewProducts(driver).ClickSendButton();
        }

        [Then(@"Product Name schould be ""(.*)""")]
        public void ThenProductNameShouldBe(string ProductName)
        {
            NewProducts newproduct = new NewProducts(driver);
            Assert.AreEqual(ProductName, newproduct.SearchNewProductName(new Product(ProductName, null, null, null, null, null, null, null, null)));
        }

        [When(@"I close the application")]
        public void WhenICloseApp()
            { driver.Quit(); }
    }
}
    
