using System;

namespace Domain
{
    abstract class DomainEvent
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
    }
}
