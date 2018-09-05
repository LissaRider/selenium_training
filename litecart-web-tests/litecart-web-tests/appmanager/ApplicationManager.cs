using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace LitecartWebTests
{
    public class ApplicationManager
    {
        public IWebDriver Driver { get; set; }
        public WebDriverWait Wait { get; set; }
        public LoginHelper Auth { get; }
        public NavigationHelper Navigator { get; }        
        public LeftMenuHelper LeftMenu { get; }
        public ProductCardHelper ProductCard { get; }
        public CountryHelper Countries { get; }
        public ZoneHelper Zones { get; }
        public RegistrationHelper Reg { get; }
        public CustomerHelper Customer { get; }
        public ProductHelper Products { get; }
        public CartHelper Cart { get; }
        public WindowHelper Window { get; }

        protected string BaseURL => "http://localhost";

        private static ThreadLocal<ApplicationManager> app = new ThreadLocal<ApplicationManager>();

        private ApplicationManager()
        {
           
            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("start-maximized");
            Driver = new ChromeDriver(chromeOptions);            
            
            //Console.WriteLine(((IHasCapabilities)Driver).Capabilities);             
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1.5);
            Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            Driver.Manage().Cookies.DeleteAllCookies();

            Auth = new LoginHelper(this);
            Navigator = new NavigationHelper(this, BaseURL);
            LeftMenu = new LeftMenuHelper(this);
            ProductCard = new ProductCardHelper(this);
            Countries = new CountryHelper(this);
            Zones = new ZoneHelper(this);
            Reg = new RegistrationHelper(this);
            Customer = new CustomerHelper(this);
            Products = new ProductHelper(this);
            Cart = new CartHelper(this);
            Window = new WindowHelper(this);
        }

        public static ApplicationManager GetInstance()
        {
            if (!app.IsValueCreated)
            {
                ApplicationManager newInstance = new ApplicationManager();
                newInstance.Navigator.OpenMainStorePage();
                app.Value = newInstance;
            }
            return app.Value;
        }
                
        ~ApplicationManager()
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
    }
}
