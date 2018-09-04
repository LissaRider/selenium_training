using OpenQA.Selenium;

namespace LitecartWebTests
{
    public class RegistrationHelper : HelperBase
    {
        public RegistrationHelper(ApplicationManager manager) : base(manager) { }

        internal void Register(CustomerData customer)
        {
            Manager.Navigator.OpenMainStorePage();
            OpenRegistrationForm();
            FillRegistrationForm(customer);
            SubmitRegistration();
            Manager.Customer.Logout();
        }

        private void SubmitRegistration()
        {
            Driver.FindElement(By.Name("create_account")).Click();
        }

        private void FillRegistrationForm(CustomerData customer)
        {
            Type(By.Name("tax_id"), customer.TaxID);
            Type(By.Name("company"), customer.Company);
            Type(By.Name("firstname"), customer.FirstName);
            Type(By.Name("lastname"), customer.LastName);
            Type(By.Name("address1"), customer.MainAddress);
            Type(By.Name("address2"), customer.AddAddress);
            Type(By.Name("postcode"), customer.Postcode);
            Type(By.Name("city"), customer.City);
            SelectByValue(By.Name("country_code"), customer.Country);
            SelectByValue(By.CssSelector("select[name='zone_code']"), customer.State);
            Type(By.Name("email"), customer.Email);
            Type(By.Name("phone"), customer.Phone);
            Type(By.Name("password"), customer.Password);
            Type(By.Name("confirmed_password"), customer.Password);
        }

        private void OpenRegistrationForm()
        {
            Driver.FindElement(By.XPath("//a[@href='http://localhost/litecart/en/create_account']")).Click();
        }
    }
}

