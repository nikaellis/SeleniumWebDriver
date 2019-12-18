using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;


namespace SeleniumAdvanced
{
    class HomePage
    {
        private IWebDriver driver;

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        private IWebElement allProductsField
        {
            get
            {
                return driver.FindElement(By.LinkText("All Products"));
            }
        }
        public HomePage AllProducts()
        {

            allProductsField.Click();

            return new HomePage(driver);
        }
    }
}

