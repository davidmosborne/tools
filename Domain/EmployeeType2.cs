namespace Domain
{
    public abstract class EmployeeType2 : Enumeration
    {
        public static readonly EmployeeType2 Manager = new ManagerType();

        protected EmployeeType2()
        {
        }

        protected EmployeeType2(int value, string displayName) : base(value, displayName)
        {
        }

        public abstract decimal BonusSize { get; }

        private class ManagerType : EmployeeType2
        {
            public ManagerType() : base(0, "Manager")
            {
            }

            public override decimal BonusSize => 1000m;
        }
    }
}