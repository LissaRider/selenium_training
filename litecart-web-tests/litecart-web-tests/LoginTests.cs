using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;

namespace LitecartWebTests
{
    [TestFixture]
    public class LoginTests
    {
        private IWebDriver firefoxDriver;
        private WebDriverWait wait;
        private string baseURL;

        [SetUp]
        public void Start()
        {

            // Firefox 61.0.2
            FirefoxOptions options = new FirefoxOptions
            {
                BrowserExecutableLocation = @"C:\Program Files\Mozilla Firefox\firefox.exe",
                UseLegacyImplementation = false,
                Proxy = new Proxy() { Kind = ProxyKind.Direct }
            };
            firefoxDriver = new FirefoxDriver(options);


            Console.WriteLine(((IHasCapabilities)firefoxDriver).Capabilities);

            firefoxDriver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(10);
            firefoxDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            wait = new WebDriverWait(firefoxDriver, TimeSpan.FromSeconds(10));
            firefoxDriver.Manage().Cookies.DeleteAllCookies();
            firefoxDriver.Manage().Window.Maximize();

            baseURL = "http://localhost";
        }

        [Test]
        public void LoginWithValidCredentials()
        {
            // Open admin login oage
            firefoxDriver.Navigate().GoToUrl(baseURL + "/litecart/admin/login.php");
            // Enter username
            firefoxDriver.FindElement(By.Name("username")).Clear();
            firefoxDriver.FindElement(By.Name("username")).SendKeys("admin");
            // Enter password
            firefoxDriver.FindElement(By.Name("password")).Clear();
            firefoxDriver.FindElement(By.Name("password")).SendKeys("admin");
            // Login
            firefoxDriver.FindElement(By.CssSelector("button[name=\"login\"]")).Click();
            // Logout
            wait.Until((driver) => 
            {
                return driver.FindElement(By.CssSelector("a[title='Logout']"));
            });
            firefoxDriver.FindElement(By.CssSelector("a[title='Logout']")).Click();
        }

        [TearDown]
        public void Stop()
        {
            try
            {
                firefoxDriver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
        }
    }
}
