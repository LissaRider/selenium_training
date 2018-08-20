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
        private IWebDriver chromeDriver;
        private WebDriverWait wait;
        private string baseURL;

        [SetUp]
        public void Start()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("start-maximized");
            chromeDriver = new ChromeDriver(options);
            chromeDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            wait = new WebDriverWait(chromeDriver, TimeSpan.FromSeconds(10));
            baseURL = "http://localhost";
        }

        [Test]
        public void LoginWithValidCredentials()
        {
            // Open admin login oage
            chromeDriver.Navigate().GoToUrl(baseURL + "/litecart/admin/login.php");
            // Enter username
            chromeDriver.FindElement(By.Name("username")).Clear();
            chromeDriver.FindElement(By.Name("username")).SendKeys("admin");
            // Enter password
            chromeDriver.FindElement(By.Name("password")).Clear();
            chromeDriver.FindElement(By.Name("password")).SendKeys("admin");
            // Login
            chromeDriver.FindElement(By.CssSelector("button[name=\"login\"]")).Click();
            // Logout
            chromeDriver.FindElement(By.CssSelector("a[title='Logout']")).Click();
        }

        [TearDown]
        public void Stop()
        {
            try
            {
                chromeDriver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
        }
    }
}
