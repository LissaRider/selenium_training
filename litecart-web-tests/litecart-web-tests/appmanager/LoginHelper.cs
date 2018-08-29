using OpenQA.Selenium;

namespace LitecartWebTests
{
    public class LoginHelper: HelperBase
    {
        public LoginHelper(ApplicationManager manager) : base(manager) { }

        public void LoginIn(AccountData account)
        {
            Manager.Navigator.OpenAdminLoginPage();

            if (IsLoggedIn())
            {
                return;
            }

            Type(By.Name("username"), account.Username);
            Type(By.Name("password"), account.Password);
            Click(By.CssSelector("button[name='login']"));
        }

        public void Logout()
        {
            if (IsLoggedIn())
            {
                Click(By.CssSelector("a[title='Logout']"));
            }
        }

        public bool IsLoggedIn() =>  IsElementPresent(By.CssSelector("a[title='Logout']"));
    }
}
