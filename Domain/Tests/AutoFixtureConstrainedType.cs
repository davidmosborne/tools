using System;
using Ploeh.AutoFixture;
using Xunit;

namespace Domain.Tests
{
    public class AutoFixtureConstrainedType
    {
        [Fact]
        public void CreateConstrainedType()
        {
            var fixture = new Fixture();

            fixture.Register<int, DateTime>(i => DateTime.UtcNow.AddDays(i).Date);

            var date = fixture.Create<DateTime>();
        }
    }
}
