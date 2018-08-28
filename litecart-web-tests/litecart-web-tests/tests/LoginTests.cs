using NUnit.Framework;

namespace LitecartWebTests
{
    [TestFixture]
    public class LoginTests : TestBase
    {
        [Test]
        public void LoginWithValidCredentials()
        {
            //Arrange
            app.Auth.Logout();

            //Act
            app.Auth.LoginIn(new AccountData("admin", "admin"));

            //Assert
            Assert.IsTrue(app.Auth.IsLoggedIn());            
        }

        [Test]
        public void LoginWithInvalidCredentials()
        {
            //Arrange
            app.Auth.Logout();

            //Act
            app.Auth.LoginIn(new AccountData("qwerty", "qwerty"));

            //Assert
            Assert.IsFalse(app.Auth.IsLoggedIn());
        }
    }
}