using System;

namespace LitecartWebTests
{
    public class ProductData : IEquatable<ProductData>, IComparable<ProductData>
    {
        public ProductData(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
        public string Code { get; set; }
        public string Category { get; set; }
        public string Quantity { get; set; }
        public string ProductGroup { get; set; }
        public string QtyUnit { get; set; }
        public string DeliverySts { get; set; }
        public string SoldOutSts { get; set; }
        public string DateValidFrom { get; set; }
        public string DateValidTo { get; set; }
        public string Image { get;  set; }
        public string PPCurrency { get; set; }
        public string SupplierId { get; set; }
        public string Keywords { get; set; }
        public string Description { get; set; }
        public string SDescription { get; set; }
        public string MDescription { get; set; }
        public string HTitle { get; set; }
        public string PPrice { get; set; }
        public string TaxClass { get; set; }
        public string UPrice { get; set; }
        public string EPrice { get; set; }
        public string ManufacturerId { get; set; }

        public int CompareTo(ProductData other)
        {
            if (object.ReferenceEquals(other, null))
            {
                return 1;
            }
            return Name.CompareTo(other.Name);
        }

        public override string ToString()
        {
            return "name=" + Name;
        }

        public bool Equals(ProductData other)
        {
            if (object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (object.ReferenceEquals(this, other))
            {
                return true;
            }
            return Name == other.Name;
        }
    }
}
