using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace LitecartWebTests
{
    [TestFixture]
    public class CountriesTests : AuthTestBase
    {

        [Test]
        public void VerifyCountiesSortList()
        {
            app.Navigator.OpenCountriesPage();

            List<CountryData> countries = app.Countries.GetCountriesList();
            List<CountryData> sortedCountries = app.Countries.GetCountriesList();
            sortedCountries.Sort();            

            Assert.AreEqual(countries, sortedCountries);            
        }
    }
}