using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;
using System;

namespace LitecartWebTests
{
    [TestFixture]
    public class LoginTests
    {
        private IWebDriver ieDriver;
        private WebDriverWait wait;
        private string baseURL;

        [SetUp]
        public void Start()
        {

            InternetExplorerOptions options = new InternetExplorerOptions();
            options.IntroduceInstabilityByIgnoringProtectedModeSettings = true;
            options.IgnoreZoomLevel = true;
            ieDriver = new InternetExplorerDriver(options);
            ieDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            wait = new WebDriverWait(ieDriver, TimeSpan.FromSeconds(10));            

            ieDriver.Manage().Cookies.DeleteAllCookies();
            ieDriver.Manage().Window.Maximize();

            baseURL = "http://localhost";
        }

        [Test]
        public void LoginWithValidCredentials()
        {
            // Open admin login oage
            ieDriver.Navigate().GoToUrl(baseURL + "/litecart/admin/login.php");
            // Enter username
            ieDriver.FindElement(By.Name("username")).Clear();
            ieDriver.FindElement(By.Name("username")).SendKeys("admin");
            // Enter password
            ieDriver.FindElement(By.Name("password")).Clear();
            ieDriver.FindElement(By.Name("password")).SendKeys("admin");
            // Login
            ieDriver.FindElement(By.CssSelector("button[name=\"login\"]")).Click();
            // Logout
            ieDriver.FindElement(By.CssSelector("a[title='Logout']")).Click();
        }

        [TearDown]
        public void Stop()
        {
            try
            {
                ieDriver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
        }
    }
}
