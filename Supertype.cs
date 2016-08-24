using System;

namespace Vindicative.Core.Model
{
	[Serializable]
	public abstract class Supertype<T> : IEquatable<T>, IComparable<T> where T : Supertype<T>
	{
		const int UnsavedValue = 0;

		#region Properties
		private int _id = UnsavedValue;

		public virtual int Id
		{
			get { return _id; }
			protected set { _id = value; }
		}

		protected int Version { get; set; }
		#endregion

		#region HashCode
		private int? _currentHashCode;

		public override int GetHashCode()
		{
			if (!_currentHashCode.HasValue)
			{
				if (Id == UnsavedValue)
				{
					_currentHashCode = base.GetHashCode();
				}
				else
				{
					_currentHashCode = Id.GetHashCode();
				}
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
			var other = obj as T;
			if (other == null) return false;

			if (Id == UnsavedValue && other.Id == UnsavedValue) return ReferenceEquals(this, other);

			return Id.Equals(other.Id);
		}
		#endregion

		#region Comparison
		public virtual int CompareTo(T other)
		{
			if (other == null) return 1;

			return Id.CompareTo(other.Id);
		}
		#endregion

	}
}
