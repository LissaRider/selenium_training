using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using System.Linq;

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

        public void TypeByindex(By locator, int i, string text)
        {
            if (text != null)
            {
                Driver.FindElements(locator)[i].Clear();
                Driver.FindElements(locator)[i].SendKeys(text);
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

        public void SelectByValue(By locator, string value)
        {
            if (!Driver.FindElement(locator).GetAttribute("value").Equals(value))
            {
                new SelectElement(Driver.FindElement(locator)).SelectByValue(value);
            }  
        }       

        public void IsChecked(By locator, string value)
        {
            IList<IWebElement> checkBox = Driver.FindElements(locator);
            int size = checkBox.Count;
            for (int i = 0; i < size; i++)
            {
                string item = checkBox.ElementAt(i).GetAttribute("value");
                if (item.Equals(value))
                {
                    checkBox.ElementAt(i).Click();
                }
            }
        }

        public void SelectOneofTwoRadioBtns(By locator)
        {
            IList<IWebElement> radioBtn = Driver.FindElements(locator);
            bool value = false;
            value = radioBtn.ElementAt(0).Selected;
            if (value == true)
            {
                radioBtn.ElementAt(1).Click();
            }
            else
            {
                radioBtn.ElementAt(0).Click();
            }
        }

        public object ExecuteJavaScript(string script)
        {
            return ((IJavaScriptExecutor)Driver).ExecuteScript(script);
        }
    }
}
