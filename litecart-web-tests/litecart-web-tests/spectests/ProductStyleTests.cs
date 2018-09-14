using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;
using System;
using System.Drawing;
using System.Globalization;
using System.Text.RegularExpressions;

namespace SpecialSeparateTests
{
    [TestFixture]
    public class ProductStyleTests
    {
        public IWebDriver Driver { get; set; }
        public WebDriverWait Wait { get; set; }

        [Test]
        public void ProductStyleTestInChrome()
        {
            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("start-maximized");
            Driver = new ChromeDriver(chromeOptions);

            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1.5);
            Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            Driver.Manage().Cookies.DeleteAllCookies();

            ProductStyleTest(Driver, Wait);
        }
        
        [Test]
        public void ProductStyleTestInFireFox()
        {
            FirefoxOptions options = new FirefoxOptions
            {
                BrowserExecutableLocation = @"C:\Program Files\Mozilla Firefox ESR\firefox.exe",
                UseLegacyImplementation = true,
                Proxy = new Proxy() { Kind = ProxyKind.Direct }
            };
            Driver = new FirefoxDriver(options);

            Driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(1.5);
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            Driver.Manage().Cookies.DeleteAllCookies();
            Driver.Manage().Window.Maximize();

            ProductStyleTest(Driver, Wait);
        }

        [Test]
        public void ProductStyleTestInInternetExplorer()
        {
            InternetExplorerOptions options = new InternetExplorerOptions();
            options.IntroduceInstabilityByIgnoringProtectedModeSettings = true;
            options.IgnoreZoomLevel = true;
            Driver = new InternetExplorerDriver(options);

            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1.5);
            Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            Driver.Manage().Cookies.DeleteAllCookies();
            Driver.Manage().Window.Maximize();

            ProductStyleTest(Driver, Wait);
        }

        [TearDown]
        public void Stop()
        {
            try
            {
                Driver.Quit();
                Driver = null;
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
        }

        private void ProductStyleTest(IWebDriver driver, WebDriverWait wait)
        {
            // Open main page
            driver.Url = "http://localhost/litecart/en/";
            wait.Until((Driver) => { return driver.Title.Contains("Online Store | My Store"); });

            // Find first item in Campaigns block on main page
            IWebElement item = driver.FindElement(By.CssSelector("#box-campaigns li.product"));
            
            // Find regular price on main page
            IWebElement mainRegPrice = item.FindElement(By.CssSelector(".regular-price"));

            // Get properties for regular price on main page
            string mainRegPriceValue = mainRegPrice.GetAttribute("textContent");
            string mainRegPriceFontStyle = mainRegPrice.GetCssValue("text-decoration");
            Color mainRegPriceColor = ColorHelper.ParseColor(mainRegPrice.GetCssValue("color"));
            Size mainRegPriceSize = mainRegPrice.Size;
            
            // Find promotion price on main page
            IWebElement mainPromoPrice = item.FindElement(By.CssSelector("strong.campaign-price"));

            // Get properties for promotion price on main page
            string mainPromoPriceValue = mainPromoPrice.GetAttribute("textContent");
            Color mainPromoPriceColor = ColorHelper.ParseColor(mainPromoPrice.GetCssValue("color"));
            Size mainPromoPriceSize = mainPromoPrice.Size;

            // Find product title on main page
            string mainTitle = item.FindElement(By.CssSelector("a.link")).GetAttribute("title");

            // Go to Item Page
            item.Click();
            wait.Until((Driver) => { return driver.Title.Contains("Yellow Duck | Subcategory | Rubber Ducks | My Store"); });

            // Find product card on product page
            IWebElement product = driver.FindElement(By.CssSelector("#box-product"));

            // Find promotion price on product page
            IWebElement prodPromoPrice = product.FindElement(By.CssSelector("strong.campaign-price"));

            // Find regular price on product page
            IWebElement prodRegPrice = driver.FindElement(By.CssSelector("#box-product .regular-price"));

            // Find product title on product page        
            string prodTitle = driver.FindElement(By.CssSelector("#box-product .title")).GetAttribute("textContent");

            // Get properties for regular price on main page
            string prodRegPriceValue = prodRegPrice.GetAttribute("textContent");
            string prodRegPriceFontStyle = prodRegPrice.GetCssValue("text-decoration");
            Color prodRegPriceColor = ColorHelper.ParseColor(prodRegPrice.GetCssValue("color"));
            Size prodRegPriceSize = prodRegPrice.Size;

            // Get properties for promotion price on product page
            string prodPromoPriceValue = prodPromoPrice.GetAttribute("textContent");
            Color prodPromoPriceColor = ColorHelper.ParseColor(prodPromoPrice.GetCssValue("color"));
            Size prodPromoPriceSize = prodPromoPrice.Size;


            // а) на главной странице и на странице товара совпадает текст названия товара
            Assert.AreEqual(mainTitle, prodTitle);

            // б) на главной странице и на странице товара совпадают цены (обычная и акционная)
            Assert.AreEqual(mainPromoPriceValue, prodPromoPriceValue);
            Assert.AreEqual(mainRegPriceValue, prodRegPriceValue);

            // в) обычная цена зачёркнутая и серая (можно считать, что "серый" цвет это такой, 
            // у которого в RGBa представлении одинаковые значения для каналов R, G и B)
            Assert.AreEqual(Regex.IsMatch(mainRegPriceFontStyle, "line-through"), true);  
            Assert.AreEqual((mainRegPriceColor.B == mainRegPriceColor.G) && (mainRegPriceColor.B == mainRegPriceColor.R), true);

            // Verify fontstyle and color (grey) for regular price on product page
            Assert.AreEqual(Regex.IsMatch(prodRegPriceFontStyle, "line-through"), true);
            Assert.AreEqual((prodRegPriceColor.B == prodRegPriceColor.G) && (prodRegPriceColor.B == prodRegPriceColor.R), true);

            // г) акционная жирная и красная (можно считать, что "красный" цвет это такой, 
            // у которого в RGBa представлении каналы G и B имеют нулевые значения)
            // (цвета надо проверить на каждой странице независимо, при этом цвета на разных страницах могут не совпадать)                        
            // выделение акционной цены жирным проверяется при поиске элемента с использованием тега strong
            Assert.AreEqual((mainPromoPriceColor.B == 0) && (mainPromoPriceColor.G == 0) && (mainPromoPriceColor.R > 0), true);            
            Assert.AreEqual((prodPromoPriceColor.B == 0) && (prodPromoPriceColor.G == 0) && (prodPromoPriceColor.R > 0), true);

            // д) акционная цена крупнее, чем обычная (это тоже надо проверить на каждой странице независимо)
            Assert.AreEqual((mainRegPriceSize.Height < mainPromoPriceSize.Height) && (mainRegPriceSize.Width < mainPromoPriceSize.Width), true);            
            Assert.AreEqual((prodRegPriceSize.Height < prodPromoPriceSize.Height) && (prodRegPriceSize.Width < prodPromoPriceSize.Width), true);
        }
    }

    public static class ColorHelper
    {
        public static Color ParseColor(string cssColor)
        {
            cssColor = cssColor.Trim();

            if (cssColor.StartsWith("#"))
            {
                return ColorTranslator.FromHtml(cssColor);
            }
            else if (cssColor.StartsWith("rgb")) //rgb or argb
            {
                int left = cssColor.IndexOf('(');
                int right = cssColor.IndexOf(')');

                if (left < 0 || right < 0)
                    throw new FormatException("rgba format error");
                string noBrackets = cssColor.Substring(left + 1, right - left - 1);

                string[] parts = noBrackets.Split(',');

                int r = int.Parse(parts[0], CultureInfo.InvariantCulture);
                int g = int.Parse(parts[1], CultureInfo.InvariantCulture);
                int b = int.Parse(parts[2], CultureInfo.InvariantCulture);

                if (parts.Length == 3)
                {
                    return Color.FromArgb(r, g, b);
                }
                else if (parts.Length == 4)
                {
                    float a = float.Parse(parts[3], CultureInfo.InvariantCulture);
                    return Color.FromArgb((int)(a * 255), r, g, b);
                }
            }
            throw new FormatException("Not rgb, rgba or hexa color string");
        }       
    }
}