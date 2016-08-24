using System;
using System.Collections;
using System.Collections.Generic;

// ReSharper disable NonReadonlyMemberInGetHashCode

namespace Domain
{
    [Serializable]
    public abstract class Supertype<TKey, TEntity> : IEquatable<TEntity>, IComparable<TEntity>
        where TEntity : Supertype<TKey, TEntity>
    {
        private int? _currentHashCode;

        private static TKey UnsavedValue => default(TKey);

        public virtual TKey Id { get; protected set; }

        protected int Version { get; set; }

        public virtual int CompareTo(TEntity other)
        {
            if (other == null)
            {
                return 1;
            }

            var structuralComparableKey = Id as IStructuralComparable;

            if (structuralComparableKey != null)
            {
                return structuralComparableKey
                    .CompareTo(
                        other.Id,
                        StructuralComparisons.StructuralComparer);
            }

            return Comparer<TKey>.Default.Compare(Id, other.Id);
        }

        bool IEquatable<TEntity>.Equals(TEntity other)
        {
            return Equals(other);
        }

        public override int GetHashCode()
        {
            if (!_currentHashCode.HasValue)
            {
                // ReSharper disable once BaseObjectGetHashCodeCallInGetHashCode
                _currentHashCode =
                    Id.Equals(UnsavedValue)
                        ? base.GetHashCode()
                        : Id.GetHashCode();
            }

            return _currentHashCode.Value;
        }

        public override bool Equals(object obj)
        {
            var other = obj as TEntity;

            if (other == null)
            {
                return false;
            }

            if (EqualityComparer<TKey>.Default.Equals(Id, UnsavedValue)
                && EqualityComparer<TKey>.Default.Equals(other.Id, UnsavedValue))
            {
                return ReferenceEquals(this, other);
            }

            var structuralEquatableKey = Id as IStructuralEquatable;

            if (structuralEquatableKey != null)
            {
                return structuralEquatableKey
                    .Equals(
                        other.Id,
                        StructuralComparisons.StructuralEqualityComparer);
            }

            return EqualityComparer<TKey>.Default.Equals(Id, other.Id);
        }
    }
}