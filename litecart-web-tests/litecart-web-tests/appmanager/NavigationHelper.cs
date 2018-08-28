using OpenQA.Selenium;

namespace LitecartWebTests
{
    public class NavigationHelper : HelperBase
    {
        protected string baseURL { get; set; }

        public NavigationHelper(ApplicationManager manager, string baseURL) : base(manager)
        {
            this.baseURL = baseURL;
        }

        public void OpenAdminLoginPage()
        {
            if (driver.Url == $"{baseURL}/litecart/admin/login.php")
            {
                return;
            }
            NavigateToInChrome($"{baseURL}/litecart/admin/login.php");
        }
        
        public void OpenMainStorePage()
        {
            if (driver.Url == $"{baseURL}/litecart/en/")
            {
                return;
            }
            NavigateToInChrome($"{baseURL}/litecart/");
        }
    }
}
