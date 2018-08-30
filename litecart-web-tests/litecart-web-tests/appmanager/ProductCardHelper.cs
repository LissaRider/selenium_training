﻿using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LitecartWebTests
{
    public class ProductHelper : HelperBase
    {
        public ProductHelper(ApplicationManager manager) : base(manager) { }

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
    }
}