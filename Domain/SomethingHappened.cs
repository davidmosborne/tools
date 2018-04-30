using System;

namespace Domain
{
    class SomethingHappened : DomainEvent
    {
        public DateTime When { get; } = DateTime.UtcNow;
    }
}
