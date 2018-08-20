using Newtonsoft.Json;
using NUnit.Framework;
using System.Collections.Generic;
using System.IO;

namespace LitecartWebTests
{
    [TestFixture]
    public class LoginTests : TestBase
    {
        public static IEnumerable<AccountData> ValidCredentials()
        {
            return JsonConvert.DeserializeObject<List<AccountData>>(
                File.ReadAllText(@"E:\GitHub\Source\Repos\selenium_training\litecart-web-tests\litecart-web-tests\data\validCredentials.json"));
        }

        public static IEnumerable<AccountData> InvalidCredentials()
        {
            return JsonConvert.DeserializeObject<List<AccountData>>(
                File.ReadAllText(@"E:\GitHub\Source\Repos\selenium_training\litecart-web-tests\litecart-web-tests\data\invalidCredentials.json"));
        }


        [Test, TestCaseSource("ValidCredentials")]
        //[Parallelizable(ParallelScope.Self)]
        public void LoginWithValidCredentials(AccountData account)
        {
            //AccountData account = new AccountData("admin", "admin");

            app.Navigator.OpenAdminLoginPageinChrome();  
            app.Auth.LoginInChrome(account);
            Assert.IsTrue(app.Auth.IsLoggedInChrome(account));
            app.Auth.LogoutInChrome();

            app.Navigator.OpenAdminLoginPageInIE();    
            app.Auth.LogininIE(account);
            Assert.IsTrue(app.Auth.IsLoggedInIE(account));
            app.Auth.LogoutInIE();
        }

        [Test, TestCaseSource("InvalidCredentials")]
        //[Parallelizable(ParallelScope.Self)]
        public void LoginWithInvalidCredentials(AccountData account)
        {
            //AccountData account = new AccountData("qwerty", "qwerty");

            app.Navigator.OpenAdminLoginPageinChrome();           
            app.Auth.LoginInChrome(account);
            Assert.IsFalse(app.Auth.IsLoggedInChrome(account));

            app.Navigator.OpenAdminLoginPageInIE();
            app.Auth.LogininIE(account);            
            Assert.IsFalse(app.Auth.IsLoggedInIE(account));
        }
    }
}