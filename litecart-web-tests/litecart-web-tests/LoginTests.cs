using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace LitecartWebTests
{
    [TestFixture]
    public class LoginTests
    {
        private IWebDriver driver;
        private WebDriverWait wait;
        private string baseURL;

        [SetUp]
        public void Start()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            baseURL = "http://localhost";
        }

        [Test]
        public void LoginWithValidCredentials()
        {
            // Open admin login oage
            driver.Navigate().GoToUrl(baseURL + "/litecart/admin/login.php");
            // Enter username
            driver.FindElement(By.Name("username")).Clear();
            driver.FindElement(By.Name("username")).SendKeys("admin");
            // Enter password
            driver.FindElement(By.Name("password")).Clear();
            driver.FindElement(By.Name("password")).SendKeys("admin");
            // Login
            driver.FindElement(By.CssSelector("button[name=\"login\"]")).Click();
            // Logout
            driver.FindElement(By.CssSelector("i.fa.fa-sign-out.fa-lg")).Click();
        }

        [TearDown]
        public void Stop()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
        }
    }
}
