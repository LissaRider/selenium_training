using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace LitecartWebTests
{
    public class HelperBase
    {
        protected ApplicationManager Manager { get; set; }
        protected IWebDriver Driver { get; set; }

        public HelperBase(ApplicationManager manager)
        {            
            this.Manager = manager;
            Driver = manager.Driver;
        }

        public void Type(By locator, string text)
        {
            if (text != null)
            {
                Driver.FindElement(locator).Clear();
                Driver.FindElement(locator).SendKeys(text);
            }
        }

        public void Click(By locator)
        {
            Driver.FindElement(locator).Click();
        }
        
        public void NavigateTo(string text)
        {
            Driver.Navigate().GoToUrl(text);
        }
        
        public bool IsElementPresent(By locator)
        {
            return Driver.FindElements(locator).Count > 0;
        }

        public void Select(By locator, string value)
        {
            new SelectElement(Driver.FindElement(locator)).SelectByValue(value);
        }
    }
}
