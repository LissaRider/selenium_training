using System;

namespace LitecartWebTests

{
    public class CountryZoneData : IEquatable<CountryZoneData>, IComparable<CountryZoneData>
    {
        public string CountryZoneName { get; set; }

        public CountryZoneData(string countryZoneName)
        {
            CountryZoneName = countryZoneName;
        }

        public bool Equals(CountryZoneData other)
        {
            if (object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (object.ReferenceEquals(this, other))
            {
                return true;
            }
            return CountryZoneName == other.CountryZoneName;
        }

        public override string ToString()
        {
            return $"{CountryZoneName}\n";
        }

        public int CompareTo(CountryZoneData other)
        {
            if (object.ReferenceEquals(other, null))
            {
                return 1;
            }
            return CountryZoneName.CompareTo(other.CountryZoneName);
        }
    }
}

