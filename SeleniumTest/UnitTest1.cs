using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;

namespace SeleniumTest
{
    [TestClass]
    public class UnitTest1
    {
        private TestContext testContextInstance;
        private IWebDriver driver;
        private string appURL;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        [TestInitialize()]
        public void SetupTest()
        {
            appURL = "https://pp-edwin-webapp.azurewebsites.net";

            string browser = "Chrome";
            switch (browser)
            {
                case "Edge":
                    this.driver = new EdgeDriver();
                    break;
                case "Chrome":
                    driver = new ChromeDriver();
                    break;
                case "Firefox":
                    driver = new FirefoxDriver();
                    break;
                case "IE":
                    driver = new InternetExplorerDriver();
                    break;
                default:
                    driver = new ChromeDriver();
                    break;
            }

        }

        [TestCleanup()]
        public void MyTestCleanup()
        {
            driver.Quit();
        }

        [TestMethod]
        public void Login()
        {
            driver.Navigate().GoToUrl(appURL + "/");
            driver.FindElement(By.Name("username")).SendKeys("demo");
            driver.FindElement(By.Name("password")).SendKeys("geheim");
            driver.FindElement(By.XPath("//div[@id='root']/div/div/div/form/div[3]/button/span")).Click();            
        }
    }
}
