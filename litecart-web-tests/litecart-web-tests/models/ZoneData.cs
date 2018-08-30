using System;

namespace LitecartWebTests

{
    public class ZoneData : IEquatable<ZoneData>, IComparable<ZoneData>
    {
        public string ZoneName { get; set; }

        public ZoneData(string zoneName)
        {
            ZoneName = zoneName;
        }

        public bool Equals(ZoneData other)
        {
            if (ReferenceEquals(other, null))
            {
                return false;
            }
            if (ReferenceEquals(this, other))
            {
                return true;
            }
            return ZoneName == other.ZoneName;
        }

        public override string ToString()
        {
            return $"{ZoneName}\n";
        }

        public int CompareTo(ZoneData other)
        {
            if (ReferenceEquals(other, null))
            {
                return 1;
            }
            return ZoneName.CompareTo(other.ZoneName);
        }
    }
}

