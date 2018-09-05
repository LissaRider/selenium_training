using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LitecartWebTests
{
    public class ProductCardHelper : HelperBase
    {
        public WebDriverWait Wait { get; set; }

        public ProductCardHelper(ApplicationManager manager) : base(manager) { }

        public void VerifyStickerPresence()
        {
            List<IWebElement> items = Driver.FindElements(By.CssSelector(".product")).ToList();
            if (items.Count > 0)
            {
                foreach (IWebElement item in items)
                {
                    if (item.FindElements(By.CssSelector(".sticker")).Count == 1)
                    {
                        return;
                    }
                    else
                    {
                        throw new ArgumentException("Warning! Number of stickers is not equal to 1 for item: " + item.Text);
                    }
                }
            }
            else
            {
                throw new ArgumentException("Warning! There is no items!");
            }
        }

        public void OpenProductCard()
        {
            Click(By.CssSelector(".product"));
        }

        public void AddProductToCart()
        {
            OpenProductCard();
            InitProductAddingToСart();
            GetProductQuantity();
            Manager.Navigator.GoToMainStorePage();
            //Manager.Navigator.OpenMainStorePage();
            //Driver.Navigate().Back();
        }

        public void InitProductAddingToСart()
        {
            if (IsElementPresent(By.CssSelector("select[name^=options]")))
            {
                new SelectElement(Driver.FindElement(By.CssSelector("select[name^=options]"))).SelectByIndex(1);
            }
            Click(By.Name("add_cart_product"));            
        }

        private void GetProductQuantity()
        {
            IWebElement qty = Driver.FindElement(By.CssSelector("#cart span.quantity"));
            string expQty = (int.Parse(qty.GetAttribute("textContent")) + 1).ToString();
            Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(1.5));
            Wait.Until(driver => qty.GetAttribute("textContent").Equals(expQty));
        }
    }
}
