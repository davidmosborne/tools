using System;

namespace Domain
{
    public static class InterestExtensions
    {
        public static decimal CalculateCompoundInterest(
            this decimal principal,
            double interestRate,
            int periods)
        {
            var factor = Math.Pow(1d + interestRate, periods);

            return principal * Convert.ToDecimal(factor);

        }
    }
}
