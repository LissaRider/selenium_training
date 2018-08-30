using OpenQA.Selenium;

namespace LitecartWebTests
{
    public class NavigationHelper : HelperBase
    {
        protected string BaseURL { get; set; }

        public NavigationHelper(ApplicationManager manager, string baseURL) : base(manager)
        {
            this.BaseURL = baseURL;
        }

        public void OpenAdminLoginPage()
        {
            if (Driver.Url == $"{BaseURL}/litecart/admin/login.php")
            {
                return;
            }
            NavigateTo($"{BaseURL}/litecart/admin/login.php");
        }
        
        public void OpenMainStorePage()
        {
            if (Driver.Url == $"{BaseURL}/litecart/en/")
            {
                return;
            }
            NavigateTo($"{BaseURL}/litecart/");
        }

        public void OpenCountriesPage()
        {
            if (Driver.Url == $"{BaseURL}/litecart/admin/?app=countries&doc=countries")
            {
                return;
            }
            Click(By.XPath(".//li[@id='app-']/a[contains(@href,'?app=countries&doc=countries')]"));
        }
    }
}
