using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;


namespace SeleniumAdvanced
{
    class AllProductsPage
    {
        private IWebDriver driver;

        public AllProductsPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        private IWebElement createNewButton

        {
            get
            {
                return driver.FindElement(By.LinkText("Create new"));
            }
        }
        public AllProductsPage CreateNew()
        {

            createNewButton.Click();

            return new AllProductsPage(driver);
        }

    }
}
