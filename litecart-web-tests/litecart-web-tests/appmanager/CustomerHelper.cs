using OpenQA.Selenium;

namespace LitecartWebTests
{
    public class CustomerHelper : HelperBase
    {
        public CustomerHelper(ApplicationManager manager) : base(manager) { }

        internal void Login(CustomerData customer)
        {
            if (IsLoggedIn())
            {
                if (IsLoggedIn(customer))
                {
                    return;
                }

                Logout();
            }
            Type(By.CssSelector("form[name='login_form'] input[name='email']"), customer.Email);
            Type(By.CssSelector("form[name='login_form'] input[name='password']"), customer.Password);
            Click(By.CssSelector("form[name='login_form'] button[name='login']"));
        }

        public bool IsLoggedIn() => IsElementPresent(By.XPath(".//div[@id='box-account']//a[contains(@href,'logout')]"));

        internal void Logout()
        {
            if (IsLoggedIn())
            {
                Click(By.XPath(".//div[@id='box-account']//a[contains(@href,'logout')]"));
            }
        }        

        public bool IsLoggedOut()
        {
            return IsElementPresent(By.CssSelector("form[name='login_form']")) && Driver.FindElement(By.CssSelector(".notice.success")).Text
                == "You are now logged out.";
        }

        public bool IsLoggedIn(CustomerData customer)
        {
            return IsLoggedIn()
                && Driver.FindElement(By.CssSelector(".notice.success")).Text
                == $"You are now logged in as {customer.FirstName} {customer.LastName}.";
        }

    }
}

