using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
namespace SeleniumAdvanced
{
    class CreateNewPage
    {
        private IWebDriver driver;

        public CreateNewPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        private IWebElement productNamefield

        {
            get
            {
                return driver.FindElement(By.Id("ProductName"));
            }
        }
        private IWebElement categoryfield

        {
            get
            {
                return driver.FindElement(By.Id("CategoryId"));
            }
        }
        private IWebElement supplierfield

        {
            get
            {
                return driver.FindElement(By.Id("SupplierId"));
            }
        }
        private IWebElement unitpricefield

        {
            get
            {
                return driver.FindElement(By.Id("UnitPrice"));
            }
        }
        private IWebElement quantityperunitfield

        {
            get
            {
                return driver.FindElement(By.Id("QuantityPerUnit"));
            }
        }
        private IWebElement unitsinstockfield

        {
            get
            {
                return driver.FindElement(By.Id("UnitsInStock"));
            }
        }
        private IWebElement unitsonorderfield

        {
            get
            {
                return driver.FindElement(By.Id("UnitsOnOrder"));
            }
        }
        private IWebElement reorderlevelfield

        {
            get
            {
                return driver.FindElement(By.Id("ReorderLevel"));
            }
        }
        private IWebElement sendbutton

        {
            get
            {
                return driver.FindElement(By.XPath("//input[@type='submit']"));
            }
        }

        public CreateNewPage CreateNewProduct() //создание тестового продукта
        {
            productNamefield.SendKeys("Test Product");
            categoryfield.Click();

            {
                var dropdown = categoryfield;
                dropdown.FindElement(By.XPath("//option[. = 'Seafood']")).Click();
            }
            categoryfield.Click();
            supplierfield.Click();
            {
                var dropdown = supplierfield;
                dropdown.FindElement(By.XPath("//option[. = 'New England Seafood Cannery']")).Click();
            }
            supplierfield.Click();
            Actions actions = new Actions(driver);
            actions
                .SendKeys(unitpricefield, "15")
                .SendKeys(quantityperunitfield, "1kg")
                .SendKeys(unitsinstockfield, "15")
                .SendKeys(unitsonorderfield, "100")
                .SendKeys(reorderlevelfield, "0")
                .Click(sendbutton)
                .Build()
                .Perform();

            return new CreateNewPage(driver);
        }
        
    }
}