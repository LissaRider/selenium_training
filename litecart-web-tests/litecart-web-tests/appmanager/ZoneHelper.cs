using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LitecartWebTests
{
    public class ZoneHelper : HelperBase
    {
        public ZoneHelper(ApplicationManager manager) : base(manager) { }       

        public List<ZoneData> GetZonesList()
        {
            List<ZoneData> zones = new List<ZoneData>();
            ICollection<IWebElement> elements = Driver.FindElements(
                By.XPath(".//table[@id='table-zones']//tr[not(@class='header')][position()<last()]"));
            foreach (IWebElement element in elements)
            {
                element.FindElement(By.XPath("./td[3]")).GetAttribute("textContent");
            }
            return zones;            
        }

        public void GoToEditGeoZonePageAndVerifyZonesSortList()
        {            
            List<IWebElement> rows = Driver.FindElements(By.CssSelector(".dataTable tr.row")).ToList();
            foreach (IWebElement row in rows)
            {
                Manager.Navigator.OpenInNewWindow(row.FindElement(
                    By.CssSelector("td:nth-child(5)>a[title='Edit']")).GetAttribute("href"));
                Driver.SwitchTo().Window(Driver.WindowHandles[1]);
                VerifyZonesSortList();
                Driver.Close();
                Driver.SwitchTo().Window(Driver.WindowHandles[0]);
            }
        }

        public void VerifyZonesSortList()
        {
            List<ZoneData> zones = GetZonesList();
            List<ZoneData> sortedZones = GetZonesList();
            sortedZones.Sort();
            Assert.AreEqual(zones, sortedZones);
        }
    }    
}

