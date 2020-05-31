﻿using Frameworks.business_object;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace PageObjects
{
    class NewProducts
    {
        private IWebDriver driver;
        public NewProducts(IWebDriver driver)
        {
            this.driver = driver;
        }


        private IWebElement linkAllProducts => driver.FindElement(By.XPath("//a[contains(text(), 'All Products')]")); // ссылка "All Products"
        private IWebElement buttonCreateNew => driver.FindElement(By.XPath("//a[contains(text(), 'Create new')]")); // Кнопка "создать новый продукт"
        private IWebElement sendKeyProductName => driver.FindElement(By.Id("ProductName")); // Поле ввода названия продукта
        private IWebElement selectCategoryId => driver.FindElement(By.Id("CategoryId"));  // Поле выбора категории продукта        
        private IWebElement selectSupplierId => driver.FindElement(By.Id("SupplierId")); // Поле выбора поставщика...
        private IWebElement sendKeyUnitPrice => driver.FindElement(By.Id("UnitPrice"));
        private IWebElement sendKeyQuantityPerUnit => driver.FindElement(By.Id("QuantityPerUnit"));
        private IWebElement sendKeyUnitsInStock => driver.FindElement(By.Id("UnitsInStock"));
        private IWebElement sendKeyUnitsOnOrder => driver.FindElement(By.Id("UnitsOnOrder"));
        private IWebElement sendKeyReorderLevel => driver.FindElement(By.Id("ReorderLevel"));
        private IWebElement checkboxDiscontinued => driver.FindElement(By.Id("Discontinued"));
        private IWebElement buttonSend => driver.FindElement(By.XPath("//input[@type=\"submit\"]"));
        private IWebElement productEditingPage => driver.FindElement(By.CssSelector("h2"));   // страница Product Editing        

        // СОЗДАЕМ МЕТОДЫ
        public void ClickLinkAllProducts() { linkAllProducts.Click(); }  // Переходим по ссылкам All Products => Create New=> Создаем новое имя продукта

        public void ClickButtonCreateNew() { buttonCreateNew.Click(); }  // Переходим по ссылкам All Products => Create New=> Создаем новое имя продукта

        public void CreateNewProductsName(Product product) { sendKeyProductName.SendKeys(product.SendKeysProductName); } // Переходим по ссылкам All Products => Create New=> Создаем новое имя продукта
        public string CheckProductEditingPage() { return productEditingPage.Text; }
        public void SelectNewCategoryId(Product product) { new SelectElement(selectCategoryId).SelectByText(product.SelectCategoryId); } // Выбираем категорию для нового продукта...
        public void SelectNewSupplierId(Product product) { new SelectElement(selectSupplierId).SelectByText(product.SelectSupplierId); }
        public void SendKeyNewUnitPrice(Product product) { sendKeyUnitPrice.SendKeys(product.SendKeysUnitPrice); }
        public void SendKeyNewQuantityPerUnit(Product product) { sendKeyQuantityPerUnit.SendKeys(product.SendKeysQuantityPerUnit); }
        public void SendKeyNewUnitsInStock(Product product) { sendKeyUnitsInStock.SendKeys(product.SendKeysUnitsInStock); }
        public void SendKeyNewUnitsOnOrder(Product product) { sendKeyUnitsOnOrder.SendKeys(product.SendKeysUnitsOnOrder); }

        public void SendKeyNewReorderLevel(Product product) 
        {    
            new Actions(driver).Click(sendKeyReorderLevel).SendKeys(product.SendKeysReorderLevel).Build().Perform(); 
        }

        public void CheckboxDiscontinued()  { new Actions(driver).Click(checkboxDiscontinued).Build().Perform(); } // отмечаем скидку


        public void ClickSendButton() // нажимаем "отправить"
        {           
            new Actions(driver).Click(buttonSend).SendKeys(Keys.Enter).Build().Perform();
        }
        public string SearchNewProductName(Product product) // Проверка, что новый продукт есть в списке
        { 
            return driver.FindElement(By.XPath($"//a[contains(text(), '{product.SendKeysProductName}')]")).Text; 
        }
    }
}

