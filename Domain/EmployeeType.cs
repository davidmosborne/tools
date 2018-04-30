﻿namespace Domain
{
    public class EmployeeType : Enumeration
    {
        public static readonly EmployeeType Manager
            = new EmployeeType(0, "Manager");

        public static readonly EmployeeType Servant
            = new EmployeeType(1, "Servant");

        public static readonly EmployeeType AssistantToTheRegionalManager
            = new EmployeeType(2, "Assistant to the Regional Manager");

        private EmployeeType()
        {
        }

        private EmployeeType(int value, string displayName) : base(value, displayName)
        {
        }
    }
}