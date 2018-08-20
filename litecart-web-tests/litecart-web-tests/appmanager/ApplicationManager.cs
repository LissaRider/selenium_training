using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
//using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace LitecartWebTests
{
    public class ApplicationManager
    {
        protected IWebDriver chromeDriver;
        protected IWebDriver ieDriver;
        //protected IWebDriver driver;
        protected WebDriverWait wait;
        protected string baseURL;

        protected LoginHelper loginHelper;
        protected NavigationHelper navigator;

        private static ThreadLocal<ApplicationManager> app = new ThreadLocal<ApplicationManager>();

        private ApplicationManager()
        {
           
            // Chrome
            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("start-maximized");
            chromeDriver = new ChromeDriver(chromeOptions);
            

            // Internet Explorer
            InternetExplorerOptions ieOptions = new InternetExplorerOptions();
            ieOptions.IntroduceInstabilityByIgnoringProtectedModeSettings = true;
            ieOptions.IgnoreZoomLevel = true;
            ieOptions.RequireWindowFocus = true;
            ieDriver = new InternetExplorerDriver(ieOptions);    

            /*
            // Firefox 61.0.2
            FirefoxOptions options = new FirefoxOptions
            {
                BrowserExecutableLocation = @"C:\Program Files\Mozilla Firefox\firefox.exe",
                UseLegacyImplementation = false,
                Proxy = new Proxy() { Kind = ProxyKind.Direct }
            };
            driver = new FirefoxDriver(options);
            */

            /*
            // Firefox ESR 52.9.0
            FirefoxOptions options = new FirefoxOptions
            {
                BrowserExecutableLocation = @"C:\Program Files\Mozilla Firefox ESR\firefox.exe",
                UseLegacyImplementation = true,
                Proxy = new Proxy() { Kind = ProxyKind.Direct }
            };
            driver = new FirefoxDriver(options);
            */

            /*
            // Firefox Nightly 63.0a1
            FirefoxOptions options = new FirefoxOptions
            {                
                BrowserExecutableLocation = @"C:\Program Files\Firefox Nightly\firefox.exe",
                Proxy = new Proxy() { Kind = ProxyKind.Direct }
            };
            driver = new FirefoxDriver(options);
            */

            // options fo Chrome
            Console.WriteLine(((IHasCapabilities)chromeDriver).Capabilities);             
            //chromeDriver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(10);
            chromeDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            wait = new WebDriverWait(chromeDriver, TimeSpan.FromSeconds(10));
            chromeDriver.Manage().Cookies.DeleteAllCookies();

            // options fo IE
            Console.WriteLine(((IHasCapabilities)ieDriver).Capabilities);
            //ieDriver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(10);
            ieDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);            
            wait = new WebDriverWait(ieDriver, TimeSpan.FromSeconds(10));
            ieDriver.Manage().Cookies.DeleteAllCookies();
            ieDriver.Manage().Window.Maximize();

            baseURL = "http://localhost";

            loginHelper = new LoginHelper(this);
            navigator = new NavigationHelper(this, baseURL);
        }

        public static ApplicationManager GetInstance()
        {
            if (!app.IsValueCreated)
            {
                ApplicationManager newInstance = new ApplicationManager();
                newInstance.Navigator.OpenMainStorePageInChrome();
                newInstance.Navigator.OpenMainStorePageInIE();
                app.Value = newInstance;
            }
            return app.Value;
        }

        public IWebDriver Chrome
        {
            get
            {
                return chromeDriver;
            }
        }

        public IWebDriver IE
        {
            get
            {
                return ieDriver;
            }
        }

        public LoginHelper Auth
        {
            get
            {
                return loginHelper;
            }
        }

        public NavigationHelper Navigator
        {
            get
            {
                return navigator;
            }
        }

        ~ApplicationManager()
        {
            try
            {
                chromeDriver.Quit();
                chromeDriver = null;
                ieDriver.Quit();
                ieDriver = null;
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }

        }
    }
}
