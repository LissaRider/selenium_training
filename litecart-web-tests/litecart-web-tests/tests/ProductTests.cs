using NUnit.Framework;
using System.Collections.Generic;
using Bogus;

namespace LitecartWebTests
{
    [TestFixture]
    public class ProductTests : AuthTestBase
    {
        [Test]
        public void AddNewProduct()
        {
            ProductData product = new ProductData(new Bogus.DataSets.Commerce().ProductName())
            {
                //GeneralData
                Code = new Randomizer().Replace("##############"),
                Category = "2",
                ProductGroup = "1-3",
                Quantity = new Bogus.DataSets.Finance().Amount().ToString(),
                QtyUnit = "1",
                DeliverySts = "1",
                SoldOutSts = "2",
                Image = "img\\MomDuck.jpg",
                DateValidFrom = "2018-08-01",
                DateValidTo = "2018-08-31",

                //InformationData
                ManufacturerId = "1",
                SupplierId = "",
                Keywords = new Bogus.DataSets.Lorem().Word(),
                SDescription = new Bogus.DataSets.Lorem().Sentence(),
                Description = new Bogus.DataSets.Lorem().Sentences(),
                HTitle = new Bogus.DataSets.Lorem().Word(),
                MDescription = new Bogus.DataSets.Lorem().Sentence(),

                //PricesData
                PPrice = new Bogus.DataSets.Commerce().Price().ToString(),
                PPCurrency = "USD",
                TaxClass = "",
                UPrice = new Bogus.DataSets.Commerce().Price().ToString(),
                EPrice = new Bogus.DataSets.Commerce().Price().ToString()
            };

            List<ProductData> oldProducts = app.Products.GetProductsList();

            app.Products.Create(product);

            List<ProductData> newProducts = app.Products.GetProductsList();
            oldProducts.Add(product);
            oldProducts.Sort();
            newProducts.Sort();
            Assert.AreEqual(oldProducts.Count, newProducts.Count);
        }
    }
}
