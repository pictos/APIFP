using System;

namespace APIFP.Model
{
    public readonly struct Position : IEquatable<Position>
    {
        public double Latitude  { get; }
        public double Longitude { get; }

        internal Position(double latitude, double longitude)
        {
            Latitude  = latitude;
            Longitude = longitude;
        }

        public override bool Equals(object obj) =>
            (obj is Position position) && Equals(position);

        public static bool operator == (Position left, Position right) => Equals(left, right);

        public static bool operator !=(Position left, Position right) => !Equals(left, right);

        public bool Equals(Position other) => (Latitude, Longitude) == (other.Latitude, other.Longitude);

        public override int GetHashCode() => (Latitude, Longitude).GetHashCode();
    }
}
