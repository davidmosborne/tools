using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentAssertions;
using Xunit;

namespace Domain
{
    public class KeyedSupertypeTests
    {
        [Fact]
        public void Will()
        {
            var e1 = new EntityWithIntKey(1);
            var e2 = new EntityWithIntKey(1);

            e1.Should().Be(e2);

            e1.Equals(e2).Should().BeTrue();
        }

        [Fact]
        public void WillNot()
        {
            var e1 = new EntityWithIntKey(1);
            var e2 = new EntityWithIntKey(2);

            e1.Should().NotBe(e2);

            e1.Equals(e2).Should().BeFalse();
        }

        [Fact]
        public void Will2()
        {
            var e1 = new EntityWithByteArrayKey();
            var e2 = e1;

            e1.Should().Be(e2);

            e1.Equals(e2).Should().BeTrue();
        }

        [Fact]
        public void WillNot2()
        {
            var e1 = new EntityWithByteArrayKey(Guid.Empty.ToByteArray());
            var e2 = new EntityWithByteArrayKey(Guid.Empty.ToByteArray());

            e1.Should().Be(e2);

            e1.Equals(e2).Should().BeTrue();
        }

        [Fact]
        public void WillEquateTwoArrays()
        {
            var e1 = new EntityWithByteArrayKey(Guid.Empty.ToByteArray());
            var e2 = new EntityWithByteArrayKey(Guid.Empty.ToByteArray());

            e1.GetHashCode().Equals(e2.GetHashCode()).Should().BeTrue();
        }

        private sealed class EntityWithIntKey : Supertype<int, EntityWithIntKey>
        {
            public EntityWithIntKey(int id)
            {
                Id = id;
            }
        }

        private sealed class EntityWithByteArrayKey
            : Supertype<byte[], EntityWithByteArrayKey>
        {
            public EntityWithByteArrayKey(byte[] id)
            {
                Id = id;
            }

            public EntityWithByteArrayKey()
            {
            }
        }
    }
}