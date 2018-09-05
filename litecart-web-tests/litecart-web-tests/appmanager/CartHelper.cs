using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace LitecartWebTests
{
    public class CartHelper : HelperBase
    {
        public WebDriverWait Wait { get; set; }

        public CartHelper(ApplicationManager manager) : base(manager) { }

        public void RemoveProductFromCart()
        {
            OpenCart();
            Remove();
            GoBackToMainStorePage();
            //Manager.Navigator.GoToMainStorePage();        
        }

        public void GoBackToMainStorePage()
        {
            Click(By.XPath(".//a[contains(text(),'Back') and @href]"));
        }

        public void OpenCart()
        {
            Click(By.CssSelector("#cart .link[href*=checkout]"));
        }

        public void Remove()
        {
            IWebElement cartProductItemRow = Driver.FindElement(By.CssSelector("table.dataTable tr:nth-of-type(2)"));
            while (IsElementPresent(By.Name("remove_cart_item")))
            {
                Click(By.Name("remove_cart_item"));
                Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
                Wait.Until(ExpectedConditions.StalenessOf(cartProductItemRow));
            }
        }
    }
}
