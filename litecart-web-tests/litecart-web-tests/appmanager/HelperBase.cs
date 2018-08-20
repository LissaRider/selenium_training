using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace LitecartWebTests
{
    public class HelperBase
    {
        protected ApplicationManager manager;
        protected IWebDriver chromeDriver;
        protected IWebDriver ieDriver;
        protected WebDriverWait wait;

        public HelperBase(ApplicationManager manager)
        {            
            this.manager = manager;
            chromeDriver = manager.Chrome;
            ieDriver = manager.IE;
        }

        public void TypeInChrome(By locator, string text)
        {
            if (text != null)
            {
                chromeDriver.FindElement(locator).Clear();
                chromeDriver.FindElement(locator).SendKeys(text);
            }
        }

        public void TypeInIE(By locator, string text)
        {
            if (text != null)
            {
                ieDriver.FindElement(locator).Clear();
                ieDriver.FindElement(locator).SendKeys(text);
            }
        }

        public void ClickInChrome(By locator)
        {
            //wait.Until((driver) => { return chromeDriver.FindElement(locator); });
            chromeDriver.FindElement(locator).Click();
        }

        public void ClickInIE(By locator)
        {
            //wait.Until((driver) => { return ieDriver.FindElement(locator); });
            ieDriver.FindElement(locator).Click();
        }      

        public void NavigateToInChrome(string text)
        {
            chromeDriver.Navigate().GoToUrl(text);
        }

        public void NavigateToInIE(string text)
        {
            ieDriver.Navigate().GoToUrl(text);
        }

        public bool IsChromeElementPresent(By by)
        {
            try
            {
                chromeDriver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
        public bool IsIEElementPresent(By by)
        {
            try
            {
                ieDriver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    }
}
