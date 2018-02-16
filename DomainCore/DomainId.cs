using System;

namespace DomainCore
{
    public class DomainId<T> : IEquatable<DomainId<T>>
    {
        public DomainId(int id)
        {
            ID = id;
        }

        public int ID { get; }

        public bool Equals(DomainId<T> other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return ID == other.ID;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((DomainId<T>) obj);
        }

        public override int GetHashCode()
        {
            return ID;
        }
    }
}