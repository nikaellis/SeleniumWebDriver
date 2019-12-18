using OpenQA.Selenium;
using System;

namespace SeleniumAdvanced
{

    class LoginPage
    {
        private IWebDriver driver;
      
        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        private IWebElement loginField 
        {
            get
            {
                return driver.FindElement(By.Id("Name"));
            }
        }

        private IWebElement passwordField
        {
            get
            {
                return driver.FindElement(By.Id("Password"));
            }
        }

       
        public LoginPage Login(String login, String passwod)
        {
            
            loginField.SendKeys(login);
            passwordField.SendKeys(passwod);
            passwordField.Submit();

            return new LoginPage(driver);
        }
    }
}
