using OpenQA.Selenium;

namespace LitecartWebTests
{
    public class HelperBase
    {
        protected ApplicationManager manager { get; set; }
        protected IWebDriver driver { get; set; }

        public HelperBase(ApplicationManager manager)
        {            
            this.manager = manager;
            driver = manager.Driver;
        }

        public void Type(By locator, string text)
        {
            if (text != null)
            {
                driver.FindElement(locator).Clear();
                driver.FindElement(locator).SendKeys(text);
            }
        }

        public void Click(By locator)
        {
            driver.FindElement(locator).Click();
        }
        
        public void NavigateToInChrome(string text)
        {
            driver.Navigate().GoToUrl(text);
        }
        
        public bool IsElementPresent(By locator)
        {
            return driver.FindElements(locator).Count > 0;
        }
    }
}
