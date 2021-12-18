using System;
using DouceSody.Domain.Common;

namespace DouceSody.Domain
{
    public abstract class Entity : AuditableEntity
    {
        public long Id { get; private set; }

        public override bool Equals(object? obj)
        {
            if (obj is not Entity other)
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            if (GetType() != other.GetType())
            {
                return false;
            }

            if (Id == 0 || other.Id == 0)
            {
                return false;
            }

            return Id == other.Id;
        }

        public static bool operator ==(Entity entity, Entity entityB)
        {
            if (entity is null && entityB is null)
            {
                return true;
            }

            return entity is null || entityB is null || entity.Equals(entityB);
        }

        public static bool operator !=(Entity entity, Entity entityB)
        {

            return !(entity == entityB);
        }

        public override int GetHashCode()
        {
            return (GetType().ToString() + Id).GetHashCode();
        }
    }
}

