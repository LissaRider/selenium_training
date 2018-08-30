using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace LitecartWebTests
{
    public class CountryHelper : HelperBase
    {
        public CountryHelper(ApplicationManager manager) : base(manager) { }

        public List<CountryData> GetCountriesList()
        {
            List<CountryData> countries = new List<CountryData>();
            Manager.Navigator.OpenCountriesPage();
            ICollection<IWebElement> elements = Driver.FindElements(By.CssSelector(".table>tbody>tr"));
            foreach (IWebElement element in elements)
            {
                string country = element.FindElement(By.CssSelector("td:nth-child(5)")).GetAttribute("textContent");
                countries.Add(new CountryData(country));
            }
            return countries;
        }

        public List<CountryZoneData> GetCountryZonesList()
        {
            List<CountryZoneData> countryZones = new List<CountryZoneData>();
            ICollection<IWebElement> elements = Driver.FindElements(By.CssSelector(".table>tbody>tr"));
            foreach (IWebElement element in elements)
            {
                string countryZone = element.FindElement(By.CssSelector("td:nth-child(3)>input")).GetAttribute("value");
                countryZones.Add(new CountryZoneData(countryZone));
            }
            return countryZones;            
        }

        public void GoToEditCountryPage()
        {
            // temporary method
            Click(By.XPath(".//a[contains(@href,'code=CA') and @title='Edit']"));
        }
    }    
}

