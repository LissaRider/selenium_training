using NUnit.Framework;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace LitecartWebTests
{
    [TestFixture]
    public class CartTests : TestBase
    {        
        [Test]
        public void AddToCartAndRemoveFromCart()
        {
            for (int i = 0; i < 3; i++)
            {
                app.ProductCard.OpenProductCard();
                app.ProductCard.AddProductToCart();                
            }
            app.Cart.RemoveProductFromCart();
        }     
    }
}
