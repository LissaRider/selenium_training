using Bogus;
using NUnit.Framework;

namespace LitecartWebTests
{
    [TestFixture]
    public class AccountCreationTests : TestBase
    {     
        [Test]        
        public void TestAccountRegistration()
        {
            CustomerData customer = new CustomerData()
            {
                TaxID = new Randomizer().Replace("##########"),
                Company = new Bogus.DataSets.Company().CompanyName(),
                FirstName = new Bogus.DataSets.Name().FirstName(),
                LastName = new Bogus.DataSets.Name().LastName(),
                MainAddress = new Bogus.DataSets.Address().StreetAddress(),
                AddAddress = new Bogus.DataSets.Address().StreetAddress(),
                Postcode = new Bogus.DataSets.Address().ZipCode("#####"),
                City = new Bogus.DataSets.Address().City(),
                Country = "US",
                Email = new Bogus.DataSets.Internet().Email(),
                State = "TX",
                Phone = new Bogus.DataSets.PhoneNumbers().PhoneNumber("+1 ###-##-##"),
                Password = new Bogus.DataSets.Internet().Password()
            };

            app.Reg.Register(customer);
            app.Customer.Login(customer);
            Assert.IsTrue(app.Customer.IsLoggedIn(customer));
            app.Customer.Logout();
            Assert.IsTrue(app.Customer.IsLoggedOut());
        }
    }
}
