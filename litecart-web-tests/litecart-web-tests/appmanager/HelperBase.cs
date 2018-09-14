using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
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
            try
            {
                Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);
                return Driver.FindElements(locator).Count > 0;
            }
            finally
            {
                Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            }
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

        public void CheckLogs()
        {
            List<LogEntry> logs = Driver.Manage().Logs.GetLog(LogType.Browser).ToList();
            Assert.IsTrue(logs.Count == 0, "Warning! Browser log is not empty.");

            foreach (LogEntry log in logs)
            {
                Log(log.Message);
            }
        }

        public void Log(string value, params object[] values)
        {
            // allow indenting
            if (!string.IsNullOrEmpty(value) && value.Length > 0 && value.Substring(0, 1) != "*")
            {
                value = $"      { value}";
            }

            // write the log
            Console.WriteLine(string.Format(value, values));
        }
    }
}
