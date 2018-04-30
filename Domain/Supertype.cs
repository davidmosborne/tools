using System;

namespace Domain
{
	[Serializable]
	public abstract class Supertype<T> : IEquatable<T>, IComparable<T> where T : Supertype<T>
	{
	    public const int UnsavedValue = 0;

		#region Properties
		private int _id = UnsavedValue;

		public virtual int Id
		{
			get => _id;
		    protected set => _id = value;
		}

		protected int Version { get; set; }
		#endregion

		#region HashCode
		private int? _currentHashCode;

		public override int GetHashCode()
		{
			if (!_currentHashCode.HasValue)
			{
			    _currentHashCode = Id == UnsavedValue ? base.GetHashCode() : Id.GetHashCode();
			}

			return _currentHashCode.Value;
		}
		#endregion

		#region Equality
		bool IEquatable<T>.Equals(T other)
		{
			return Equals(other);
		}

		public override bool Equals(object obj)
		{
		    if (!(obj is T other)) return false;

			if (Id == UnsavedValue && other.Id == UnsavedValue) return ReferenceEquals(this, other);

			return Id.Equals(other.Id);
		}
		#endregion

		#region Comparison
		public virtual int CompareTo(T other)
		{
		    return other == null ? 1 : Id.CompareTo(other.Id);
		}
		#endregion

	}
}
