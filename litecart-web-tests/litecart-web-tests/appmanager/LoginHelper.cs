using OpenQA.Selenium;

namespace LitecartWebTests
{
    public class LoginHelper: HelperBase
    {
        public LoginHelper(ApplicationManager manager) : base(manager)
        {
        }

        public void LoginInChrome(AccountData account)
        {
            TypeInChrome(By.Name("username"), account.Username);
            TypeInChrome(By.Name("password"), account.Password);
            ClickInChrome(By.CssSelector("button[name='login']"));
        }

        public void LogininIE(AccountData account)
        {
            TypeInIE(By.Name("username"), account.Username);
            TypeInIE(By.Name("password"), account.Password);
            ClickInIE(By.CssSelector("button[name='login']"));
        }

        public void LogoutInChrome()
        {
            if (IsLoggedInChrome())
            {
                ClickInChrome(By.CssSelector("a[title='Logout']"));
            }
        }

        public void LogoutInIE()
        {
            if (IsLoggedInIE())
            {
                ClickInIE(By.CssSelector("a[title='Logout']"));
            }
        }

        public bool IsLoggedInChrome()
        {
            return IsChromeElementPresent(By.CssSelector("a[title='Logout']"));
        }


        public bool IsLoggedInIE()
        {
            return IsIEElementPresent(By.CssSelector("a[title='Logout']"));
        }

        public bool IsLoggedInChrome(AccountData account)
        {
            return IsLoggedInChrome();              
        }

        public bool IsLoggedInIE(AccountData account)
        {
            return IsLoggedInIE();
        }
    }
}
