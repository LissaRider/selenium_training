using System;

namespace LitecartWebTests

{
    public class CountryData : IEquatable<CountryData>, IComparable<CountryData>
    {
        public string Name { get; set; }

        public CountryData(string name)
        {
            Name = name;
        }

        public bool Equals(CountryData other)
        {
            if (ReferenceEquals(other, null))
            {
                return false;
            }
            if (ReferenceEquals(this, other))
            {
                return true;
            }
            return Name == other.Name;
        }
              
        public override string ToString()
        {
            return $"{Name}\n";
        }

        public int CompareTo(CountryData other)
        {
            if (ReferenceEquals(other, null))
            {
                return 1;
            }
            return Name.CompareTo(other.Name);
        }
    }
}

