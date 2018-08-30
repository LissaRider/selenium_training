using NUnit.Framework;
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

        [Test]
        public void VerifyCountyZonesSortList()
        {
            app.Navigator.OpenCountriesPage();
            app.Countries.GoToEditCountryPage();

            List<CountryZoneData> countryZones = app.Countries.GetCountryZonesList();            
            List<CountryZoneData> sortedcountryZones = app.Countries.GetCountryZonesList();
            sortedcountryZones.Sort();

            Assert.AreEqual(sortedcountryZones, countryZones);            
        }      
    }
}