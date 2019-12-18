using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumAdvanced
{
    class MainPage
    {
        private IWebDriver driver;
       

        public MainPage(IWebDriver driver)
        {
            this.driver = driver;
            
        }

        public bool isLoginSuccessfull() 
        {
            bool isLoginSuccessfull = false;
            try
            {
                IWebElement homePageLabel = driver.FindElement(By.XPath(".//*[text()='Home page']"));
                isLoginSuccessfull = homePageLabel.Displayed;
            }
            catch (NoSuchElementException)
            {
                isLoginSuccessfull = false;
            }
            return isLoginSuccessfull;
        }

    }
}