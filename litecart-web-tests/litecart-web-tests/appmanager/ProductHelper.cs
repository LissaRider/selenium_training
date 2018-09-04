using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;

namespace LitecartWebTests
{
    public class ProductHelper : HelperBase
    {  
        public ProductHelper(ApplicationManager manager) : base(manager) { }

        internal ProductHelper Create(ProductData product)
        {
            Manager.Navigator.OpenCatalogPage();
            
            InitNewProductCreation();
            FillProductForm(product);
            SubmitProductCreation();
           
            return this;
        }

        private void SubmitProductCreation()
        {
            Click(By.Name("save"));
        }

        private void FillProductForm(ProductData product)
        {
            FillGeneralData(product);
            FillInformationData(product);
            FillPricesData(product);
        }

        private void FillGeneralData(ProductData product)
        {
            OpenTab("general");
            SelectOneofTwoRadioBtns(By.Name("status"));
            Type(By.CssSelector("input[name^=name]"), product.Name);
            Type(By.CssSelector("input[name=code]"), product.Code);
            IsChecked(By.CssSelector($"[name='categories[]']"), product.Category);
            SelectByValue(By.CssSelector("select[name='default_category_id']"), product.Category);
            IsChecked(By.CssSelector($"[name='product_groups[]']"), product.ProductGroup);
            Type(By.CssSelector("input[name=quantity]"), product.Quantity);
            SelectByValue(By.CssSelector("select[name=quantity_unit_id]"), product.QtyUnit);
            SelectByValue(By.CssSelector("select[name=delivery_status_id]"), product.DeliverySts);
            SelectByValue(By.CssSelector("select[name=sold_out_status_id]"), product.SoldOutSts);
            Driver.FindElement(By.CssSelector("input[name='new_images[]']"))
                .SendKeys($"{Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\"))}{product.Image}");
            ExecuteJavaScript($"$(\"[name='date_valid_from']\").val('{product.DateValidFrom}')");
            ExecuteJavaScript($"$(\"[name='date_valid_to']\").val('{product.DateValidTo}')");
        }

        internal double GetProductsCount()
        {
            return Driver.FindElements(By.CssSelector("table[class=dataTable] tr.row")).Count;
        }

        private void FillInformationData(ProductData product)
        {
            OpenTab("information");
            SelectByValue(By.CssSelector("select[name=manufacturer_id]"), product.ManufacturerId);
            SelectByValue(By.CssSelector("select[name=supplier_id]"), product.SupplierId);
            Type(By.Name("keywords"), product.Keywords);
            Type(By.CssSelector("input[name^=short_description]"), product.SDescription); 
            Type(By.ClassName("trumbowyg-editor"), product.Description);  
            Type(By.CssSelector("input[name^=head_title]"), product.HTitle);
            Type(By.CssSelector("input[name^=meta_description]"), product.MDescription);           
        }

        private void FillPricesData(ProductData product)
        {
            OpenTab("prices");
            Type(By.Name("purchase_price"), product.PPrice);
            SelectByValue(By.CssSelector("select[name=purchase_price_currency_code]"), product.PPCurrency);      
            SelectByValue(By.CssSelector("select[name=tax_class_id]"), product.TaxClass);    
            TypeByindex(By.CssSelector("input[name^=prices]"), 0, product.UPrice);
            TypeByindex(By.CssSelector("input[name^=prices]"), 1, product.EPrice);
        }

        private void OpenTab(string tabName)
        {
            Click(By.CssSelector($".index a[href='#tab-{tabName}']"));
        }

        private void InitNewProductCreation()
        {
            Click(By.XPath(".//a[@class='button' and contains(@href,'edit_product')]"));
        }

        public List<ProductData> GetProductsList()
        {
            List<ProductData> products = new List<ProductData>();
            Manager.Navigator.OpenCatalogPage();
            ICollection<IWebElement> elements = Driver.FindElements(By.CssSelector("table[class=dataTable] tr.row"));
            foreach (IWebElement element in elements)
            {
                products.Add(new ProductData(element.FindElement(By.XPath(".//td[3]")).Text));               
            }
            return products;
        }
    }
}