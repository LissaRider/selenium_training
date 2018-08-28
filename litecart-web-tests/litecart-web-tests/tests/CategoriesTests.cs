using NUnit.Framework;
using System.Threading;

namespace LitecartWebTests
{
    [TestFixture]
    public class CategoriesTests: AuthTestBase
    {
        [Test]
        public void VerifyPageTitles()
        {
            //Act
            Thread.Sleep(5000);
            app.LeftMenu.GetCategoryList();
        }
    }
}