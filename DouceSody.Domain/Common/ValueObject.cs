using System;
namespace DouceSody.Domain
{
    public abstract class ValueObject<T> where T : ValueObject<T>
    {
        public override bool Equals(object? obj)
        {
            if (obj is not T valueObject)
            {
                return false;
            }

            return EqualsCore(valueObject);
        }

        protected abstract bool EqualsCore(T valueObject);

        public override int GetHashCode()
        {
            return GetHashCodeCore();
        }

        protected abstract int GetHashCodeCore();

        public static bool operator ==(ValueObject<T> entity, ValueObject<T> entityB)
        {
            if (entity is null && entityB is null)
            {
                return true;
            }

            return entity is null || entityB is null || entity.Equals(entityB);
        }

        public static bool operator !=(ValueObject<T> entity, ValueObject<T> entityB)
        {

            return !(entity == entityB);
        }
    }
}

