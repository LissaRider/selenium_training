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
            Manager.Navigator.OpenCountriesPage();
            List<CountryData> countries = new List<CountryData>();            
            ICollection<IWebElement> elements = Driver.FindElements(By.CssSelector(".dataTable tr.row"));
            foreach (IWebElement element in elements)
            {
                string country = element.FindElement(By.CssSelector("td:nth-child(5)")).GetAttribute("textContent");
                //Console.WriteLine($"Country to compare: {country}");
            }
            return countries;
        }

        public List<CountryZoneData> GetCountryZonesList()
        {
            //string countryName = Driver.FindElement(By.XPath(".//td/input[@name='name']")).GetAttribute("value");
            List<CountryZoneData> countryZones = new List<CountryZoneData>();
            ICollection<IWebElement> elements = Driver.FindElements(By.XPath(".//table[@id='table-zones']//tr[not(@class='header')][position()<last()]"));
            foreach (IWebElement element in elements)
            {
                string countryZone = element.FindElement(By.XPath("./td[3]")).GetAttribute("textContent");
                //Console.WriteLine($"{countryZone} is a zone for {countryName}.");
            }
            return countryZones;            
        }

        public void MoveToEditCountry()
        {            
            List<IWebElement> rows = Driver.FindElements(By.CssSelector(".dataTable tr.row")).ToList();
            foreach (IWebElement row in rows)
            {                
                string zoneQuantity = row.FindElement(By.CssSelector("td:nth-child(6)")).GetAttribute("textContent");
                //string country = row.FindElement(By.CssSelector("td:nth-child(5)")).GetAttribute("textContent");
                //Console.WriteLine($"Zones for {country}: {zoneQuantity}");
                if (int.Parse(zoneQuantity) != 0)
                {
                    string link = row.FindElement(By.CssSelector("td:nth-child(5)>a")).GetAttribute("href");
                    //Console.WriteLine($"Zones found оn {link}!");
                    OpenInNewWindow(link);                    
                    Driver.SwitchTo().Window(Driver.WindowHandles[1]);
                    VerifyCountryZoneSortList();
                    Driver.Close();
                    Driver.SwitchTo().Window(Driver.WindowHandles[0]);
                }                
            }
        }      

        public void OpenInNewWindow(string url)
        {
            ((IJavaScriptExecutor)Driver).ExecuteScript("window.open(arguments[0])", url);
        }

        private void VerifyCountryZoneSortList()
        {
            List<CountryZoneData> countryZones = Manager.Countries.GetCountryZonesList();
            List<CountryZoneData> sortedcountryZones = Manager.Countries.GetCountryZonesList();
            sortedcountryZones.Sort();
            Assert.AreEqual(countryZones, sortedcountryZones);
        }

        public void VerifyCountrySortList()
        {
            List<CountryData> countries = Manager.Countries.GetCountriesList();
            List<CountryData> sortedCountries = Manager.Countries.GetCountriesList();
            sortedCountries.Sort();
            Assert.AreEqual(countries, sortedCountries);
        }  
    }    
}

