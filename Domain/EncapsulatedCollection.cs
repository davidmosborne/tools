using System.Collections.Generic;

namespace Domain
{
    internal class EncapsulatedCollection
    {
        private readonly HashSet<Child> _children = new HashSet<Child>();

        public virtual IReadOnlyCollection<Child> Sessions => _children;

        public virtual void AddSession(Child child)
        {
            child.Parent = this;

            _children.Add(child);
        }
    }

    internal class Child
    {
        public EncapsulatedCollection Parent { get; set; }
    }
}