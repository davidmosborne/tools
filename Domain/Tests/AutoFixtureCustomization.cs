using FluentAssertions;
using Ploeh.AutoFixture;
using Ploeh.AutoFixture.AutoMoq;
using Ploeh.AutoFixture.Kernel;
using Xunit;

namespace Domain.Tests
{
    public class AutoFixtureCustomization
    {
        [Fact]
        public void TestWithCustomizations()
        {
            var fixture = new Fixture().Customize(new MyCustomizations());

            fixture.Customizations.Add(new MySpecimenBuilder());

            fixture.Create<string>().Should().Contain("me!");
        }

        private class MyCustomizations : CompositeCustomization
        {
            public MyCustomizations()
                : base(
                    new AutoMoqCustomization(),
                    new MyCustomization())
            {
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// ...this is the perfect place to encapsulate common Customizations...
        /// http://blog.ploeh.dk/2011/03/18/EncapsulatingAutoFixtureCustomizations/
        /// </summary>
        private class MyCustomization : ICustomization
        {
            public void Customize(IFixture fixture)
            {
                fixture.Inject("You're only going to get me!");
            }
        }

        private class MySpecimenBuilder : ISpecimenBuilder
        {
            public object Create(object request, ISpecimenContext context)
            {
                throw new System.NotImplementedException();
            }
        }
    }
}
