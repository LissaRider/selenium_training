using NUnit.Framework;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

namespace LitecartWebTests
{
    public class CountryHelper : HelperBase
    {
        public CountryHelper(ApplicationManager manager) : base(manager) { }

        public List<CountryData> GetCountriesList()
        {
            List<CountryData> countries = new List<CountryData>();            
            ICollection<IWebElement> elements = Driver.FindElements(By.CssSelector(".dataTable tr.row"));
            foreach (IWebElement element in elements)
            {
                element.FindElement(By.CssSelector("td:nth-child(5)")).GetAttribute("textContent");
            }
            return countries;
        }

        public void GoToEditCountryPageAndVerifyZonesSortList()
        {            
            List<IWebElement> rows = Driver.FindElements(By.CssSelector(".dataTable tr.row")).ToList();
            foreach (IWebElement row in rows)
            {                
                if (int.Parse(row.FindElement(By.CssSelector("td:nth-child(6)")).GetAttribute("textContent")) != 0)
                {
                    Manager.Navigator.OpenInNewWindow(
                        row.FindElement(By.CssSelector("td:nth-child(5)>a")).GetAttribute("href"));                    
                    Driver.SwitchTo().Window(Driver.WindowHandles[1]);
                    Manager.Zones.VerifyZonesSortList();
                    Driver.Close();
                    Driver.SwitchTo().Window(Driver.WindowHandles[0]);
                }                
            }
        }      

        public void VerifyCountriesSortList()
        {
            List<CountryData> countries = GetCountriesList();
            List<CountryData> sortedCountries = GetCountriesList();
            sortedCountries.Sort();
            Assert.AreEqual(countries, sortedCountries);
        }  
    }    
}

