﻿using System;
using System.Collections;
using System.Collections.Generic;

namespace Domain
{
    [Serializable]
    public abstract class Supertype<TKey, TEntity>
        : IEquatable<TEntity>,
            IComparable<TEntity>
        where TEntity : Supertype<TKey, TEntity>
    {
        private int? _currentHashCode;

        private static readonly TKey UnsavedValue = default(TKey);

        public virtual TKey Id { get; protected set; }

        protected int Version { get; set; }

        public virtual int CompareTo(TEntity other)
        {
            if (other == null)
            {
                return 1;
            }

            if (Id is IStructuralComparable structuralComparableKey)
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
                if (EqualityComparer<TKey>.Default.Equals(Id, UnsavedValue))
                {
                    _currentHashCode = base.GetHashCode();
                }
                    
                if (Id is IStructuralEquatable structuralEquatableKey)
                {
                    _currentHashCode =
                        structuralEquatableKey.GetHashCode(
                            StructuralComparisons.StructuralEqualityComparer);
                }
                else
                {
                    _currentHashCode = Id.GetHashCode();
                }
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

            if (Id is IStructuralEquatable structuralEquatableKey)
            {
                return structuralEquatableKey
                    .Equals(
                        other.Id,
                        StructuralComparisons.StructuralEqualityComparer);
            }

            return EqualityComparer<TKey>.Default.Equals(Id, other.Id);
        }

        public static bool operator ==(Supertype<TKey, TEntity> left, Supertype<TKey, TEntity> right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Supertype<TKey, TEntity> left, Supertype<TKey, TEntity> right)
        {
            return !Equals(left, right);
        }
    }
}