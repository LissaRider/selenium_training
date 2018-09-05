using NUnit.Framework;

namespace LitecartWebTests
{
    [TestFixture]
    public class CountriesTests : AuthTestBase
    {
        [Test]
        public void VerifySortListsForCountries()
        {
            app.Navigator.OpenCountriesPage();
            app.Countries.VerifyCountriesSortList();
            app.Countries.GoToEditCountryPageAndVerifyZonesSortList();
        }

        [Test]
        public void VerifySortListsForGeoZones()
        {
            app.Navigator.OpenGeoZonesPage();
            app.Zones.GoToEditGeoZonePageAndVerifyZonesSortList();
        }

        [Test]
        public void VerifyHelpLinkOpenInNewWindow()
        {
            app.Navigator.OpenCountriesPage();
            app.Countries
                .InitNewCountryCreation()
                .VerifyHelpLinks();
        }
    }
}