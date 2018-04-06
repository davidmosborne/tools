using System;

namespace Domain
{
    /// <summary>
    /// http://blog.ploeh.dk/2018/03/26/the-maybe-functor/
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public sealed class Maybe<T>
    {
        public Maybe()
        {
            HasItem = false;
        }

        public Maybe(T item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            HasItem = true;
            Item = item;
        }

        internal bool HasItem { get; }
        internal T Item { get; }

        public Maybe<TResult> Select<TResult>(Func<T, TResult> selector)
        {
            if (selector == null)
            {
                throw new ArgumentNullException(nameof(selector));
            }

            return HasItem ? new Maybe<TResult>(selector(Item)) : new Maybe<TResult>();
        }

        public T GetValueOrFallback(T fallbackValue)
        {
            if (fallbackValue == null)
            {
                throw new ArgumentNullException(nameof(fallbackValue));
            }

            return HasItem ? Item : fallbackValue;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Maybe<T> other))
            {
                return false;
            }
                
            return Equals(Item, other.Item);
        }

        public override int GetHashCode()
        {
            return HasItem ? Item.GetHashCode() : 0;
        }
    }
}