using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LitecartWebTests
{
    public class LeftMenuHelper : HelperBase
    {
        public LeftMenuHelper(ApplicationManager manager) : base(manager) { }

        public LeftMenuHelper GetCategoryList()
        {
            List<IWebElement> category = Driver.FindElements(By.CssSelector("#app-")).ToList();
            for (int cat = 0; cat < category.Count; cat++)
            {
                Driver.FindElements(By.CssSelector("#app->a"))[cat].Click();
                GetSubcategoryList();
            }
            return this;
        }

        private void GetSubcategoryList()
        {
            List<IWebElement> subcategory = Driver.FindElements(By.CssSelector(".docs>li")).ToList();
            for (int scat = 0; scat < subcategory.Count; scat++)
            {
                Driver.FindElements(By.CssSelector(".docs>li"))[scat].Click();
                IsPageTitlePresence();
            }
        }

        private void IsPageTitlePresence()
        {
            string title = Driver.FindElement(By.CssSelector("#main>h1")).GetAttribute("innerText");
            if (title.Length == 0)
            {
                throw new ArgumentException("Warning! No page title!");
            }
        }
    }
}
