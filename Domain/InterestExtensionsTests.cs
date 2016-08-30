using Xunit;

namespace Domain
{
    public class InterestExtensionsTests
    {
        [Fact]
        public void TestThisOut()
        {
            var accrued = 1000M.CalculateCompoundInterest(0.1, 5);


        }
    }
}
