using System.Collections;
using System.Collections.Generic;

namespace Domain
{
    internal interface IEventContainer<TEvent> where TEvent : DomainEvent
    {
        ICollection<TEvent> Events { get; }
    }
}
