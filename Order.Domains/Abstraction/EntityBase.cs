using System;
using System.Collections.Generic;
using System.Text;

namespace Order.Domain.Abstraction
{
    public abstract class EntityBase : IAuditable
    {
        public long Id { get; set; }

        public EntityAuditInfo EntityModificationInfo { get; set; }

        public bool IsTransient()
        {
            return Id == default;
        }

        public override int GetHashCode()
        {
            if (!IsTransient())
            {
                return Id.GetHashCode();
            }

            return base.GetHashCode();
        }

        public static bool operator ==(EntityBase left, EntityBase right)
        {
            if (Equals(left, null))
                return (Equals(right, null));
            return left.Equals(right);
        }

        public static bool operator !=(EntityBase left, EntityBase right)
        {
            return !(left == right);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is EntityBase))
                return false;

            if (ReferenceEquals(this, obj))
                return true;

            if (GetType() != obj.GetType())
                return false;

            var item = (EntityBase)obj;

            if (item.IsTransient() || IsTransient())
                return false;

            return item.Id == Id;
        }
    }

}
