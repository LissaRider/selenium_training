using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;

namespace LitecartWebTests
{
    [TestClass]
    public class TestBase
    {
        protected ApplicationManager app;

        [SetUp]
        public void SetupApplicationManager()
        {
            app = ApplicationManager.GetInstance();
        }
    }
}
