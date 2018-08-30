using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;

namespace LitecartWebTests
{
    [TestFixture]
    public class CountriesTests : AuthTestBase
    {
        [Test]
        public void VerifySortListsForCountries()
        {
            app.Countries.VerifyCountrySortList();
            app.Countries.MoveToEditCountry();
        }
    }
}