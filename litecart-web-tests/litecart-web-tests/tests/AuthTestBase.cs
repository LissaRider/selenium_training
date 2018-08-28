using NUnit.Framework;

namespace LitecartWebTests

{
    public class AuthTestBase : TestBase
    {
        [SetUp]
        public void SetupLogin()
        {
            app.Auth.LoginIn(new AccountData("admin", "admin"));
        }
    }
}