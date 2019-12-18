using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;

namespace SeleniumAdvanced
{   
    [TestClass]
    public class UnitTest1
    {
        
        [TestMethod]
        public void Test1LoginTrue()

        {
            IWebDriver driver = new ChromeDriver();
            driver.Url = "http://localhost:5000";
            LoginPage Login = new LoginPage(driver);
            Login.Login("user", "user");
         

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
            Assert.IsTrue(isLoginSuccessfull, "Login failed");
            driver.Close();
        }

        [TestMethod]
        public void Test4LoginFalse()

        {
            IWebDriver driver = new ChromeDriver();
            driver.Url = "http://localhost:5000";
 
           
            LoginPage Login = new LoginPage(driver);
            Login.Login("user", "userrrr");
           

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
            Assert.IsFalse(isLoginSuccessfull, "SECURITY ALERT!");
            driver.Close();
        }


        [TestMethod]
        public void Test2AddProduct()

        {
            IWebDriver driver = new ChromeDriver();
            driver.Url = "http://localhost:5000";
            LoginPage Login = new LoginPage(driver);
            Login.Login("user", "user");
            HomePage AllProducts = new HomePage(driver);
            AllProducts.AllProducts();
            AllProductsPage CreateNew = new AllProductsPage(driver);
            CreateNew.CreateNew();
            CreateNewPage CreateNewProduct = new CreateNewPage(driver);
            CreateNewProduct.CreateNewProduct();

            //Проверка введенных значений
            driver.FindElement(By.LinkText("Test Product")).Click();
            //получаем значения
            string valueProductName = driver.FindElement(By.Id("ProductName")).GetAttribute("value");
            string elementCategoryId = driver.FindElement(By.CssSelector("#CategoryId > option:nth-child(9)")).GetAttribute("text");
            string elementSupplierId = driver.FindElement(By.CssSelector("#SupplierId > option:nth-child(20)")).GetAttribute("text");
            string valueUnitPrice = driver.FindElement(By.Id("UnitPrice")).GetAttribute("value");
            string valueQuantityPerUnit = driver.FindElement(By.Id("QuantityPerUnit")).GetAttribute("value");
            string valueUnitsInStock = driver.FindElement(By.Id("UnitsInStock")).GetAttribute("value");
            string valueUnitsOnOrder = driver.FindElement(By.Id("UnitsOnOrder")).GetAttribute("value");
            string valueReorderLevel = driver.FindElement(By.Id("ReorderLevel")).GetAttribute("value");

            //проверяем значения
            Assert.AreEqual(valueProductName, "Test Product");
            Assert.AreEqual(elementCategoryId, "Seafood");
            Assert.AreEqual(elementSupplierId, "New England Seafood Cannery");
            Assert.AreEqual(valueUnitPrice, "15,0000");
            Assert.AreEqual(valueQuantityPerUnit, "1kg");
            Assert.AreEqual(valueUnitsInStock, "15");
            Assert.AreEqual(valueUnitsOnOrder, "100");
            Assert.AreEqual(valueReorderLevel, "0");
            driver.Close();
        }

    

        [TestMethod]
        public void Test3Logout()

        {
            IWebDriver driver = new ChromeDriver();
            driver.Url = "http://localhost:5000";
            LoginPage Login = new LoginPage(driver);
            Login.Login("user", "user");
            IWebElement logoutField = driver.FindElement(By.LinkText("Logout"));
            logoutField.Click();
            bool isLogoutSuccessfull = false;
            try
            {
                IWebElement homePageLabel = driver.FindElement(By.XPath(".//*[text()='Home page']"));
                isLogoutSuccessfull = homePageLabel.Displayed;
            }
            catch (NoSuchElementException)
            {
                isLogoutSuccessfull = false;
            }
            Assert.IsFalse (isLogoutSuccessfull, "Logout failed");
            driver.Close();
        }
         /* [TestCleanup]
           /* public void closeBrowser()
            {

            driver.Close();
                
            }*/
    }
}
