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
            ICollection<IWebElement> elements = Driver.FindElements(By.CssSelector(".data-table>tbody>tr"));
            foreach (IWebElement element in elements)
            {
                string country = element.FindElement(By.CssSelector("td:nth-child(5)")).GetAttribute("textContent");
                countries.Add(new CountryData(country));
                Console.WriteLine(new CountryData(country));
            }
            return countries;
        }      
    }
}

