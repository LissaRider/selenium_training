using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;

namespace LitecartWebTests
{
    public class WindowHelper : HelperBase
    {
        public WindowHelper(ApplicationManager manager) : base(manager) { }

        public WebDriverWait Wait { get; private set; }

        internal void VerifyLinkOpenInNewWindow(By locator)
        {
            IList<IWebElement> links = Driver.FindElements(locator);
            foreach (IWebElement link in links)
            {
                string mainWindow = Driver.CurrentWindowHandle;
                ICollection<string> oldWindows = Driver.WindowHandles;
                link.Click();
                Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
                string newWindow = Wait.Until(ThereIsWindowOtherThan(oldWindows));
                Driver.SwitchTo().Window(newWindow);
                Driver.Close();
                Driver.SwitchTo().Window(mainWindow);
            }

            Func<IWebDriver, string> ThereIsWindowOtherThan(ICollection<string> oldWindows)
            {
                return driver =>
                {
                    List<string> newWindows = new List<string>();
                    ICollection<string> newWindowsReadOnly = driver.WindowHandles;
                    foreach (string handle in newWindowsReadOnly) newWindows.Add(handle);    
                    foreach (string handle in oldWindows) newWindows.Remove(handle);
                    return (newWindows.Count > 0) ? newWindows[0] : null;             
                };
            }
        }
    }
}
