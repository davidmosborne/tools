using System;

namespace Domain
{
    public class Parent
    {
        private Child2 _child;

        public Parent(Child2 child)
        {
            _child = child ?? throw new ArgumentNullException(nameof(child));
        }

        public static Parent operator +(Parent a, Child2 b)
        {
            a._child = b;
            return a;

        }
    }

    public class Child2
    {
    }
}
