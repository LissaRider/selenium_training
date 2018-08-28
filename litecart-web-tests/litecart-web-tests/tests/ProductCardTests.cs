using NUnit.Framework;

namespace LitecartWebTests
{
    [TestFixture]
    public class ProductCardTests :TestBase
    {
        [Test]
        public void VerifyStickerPresence()
        {
            //Act            
            app.productCard.VerifyStickerPresence();
        }
    }
}