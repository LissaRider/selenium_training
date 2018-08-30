using System;

namespace LitecartWebTests

{
    public class CountryData : IEquatable<CountryData>, IComparable<CountryData>
    {
        public string CountryName { get; set; }

        public CountryData(string countryName)
        {
            CountryName = countryName;
        }

        public bool Equals(CountryData other)
        {
            if (object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (object.ReferenceEquals(this, other))
            {
                return true;
            }
            return CountryName == other.CountryName;
        }
              
        public override string ToString()
        {
            return $"{CountryName}\n";
        }

        public int CompareTo(CountryData other)
        {
            if (object.ReferenceEquals(other, null))
            {
                return 1;
            }
            return CountryName.CompareTo(other.CountryName);
        }
    }
}

