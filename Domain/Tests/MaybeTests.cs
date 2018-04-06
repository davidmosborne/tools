using Xunit;

namespace Domain.Tests
{
    public class MaybeTests
    {
        [Fact]
        public void Maybe()
        {
            var m = new Maybe<int>(42);

            var n = m.Select(s => s.ToString());

            var x = n.GetValueOrFallback("");
        }
    }
}