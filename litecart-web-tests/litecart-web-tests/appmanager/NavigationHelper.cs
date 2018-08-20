namespace LitecartWebTests
{
    public class NavigationHelper : HelperBase
    {
        private string baseURL;

        public NavigationHelper(ApplicationManager manager, string baseURL) : base(manager)
        {
            this.baseURL = baseURL;
        }

        public void OpenAdminLoginPageinChrome()
        {
            if (chromeDriver.Url == baseURL + "/litecart/admin/login.php")
            {
                return;
            }
            NavigateToInChrome(baseURL + "/litecart/admin/login.php");
        }

        public void OpenAdminLoginPageInIE()
        {
            if (ieDriver.Url == baseURL + "/litecart/admin/login.php")
            {
                return;
            }
            NavigateToInIE(baseURL + "/litecart/admin/login.php");
        }

        public void OpenMainStorePageInChrome()
        {
            if (chromeDriver.Url == baseURL + "/litecart/en/")
            {
                return;
            }
            NavigateToInChrome(baseURL + "/litecart/");
        }
        public void OpenMainStorePageInIE()
        {
            if (chromeDriver.Url == baseURL + "/litecart/en/")
            {
                return;
            }
            NavigateToInIE(baseURL + "/litecart/");
        }
    }
}
