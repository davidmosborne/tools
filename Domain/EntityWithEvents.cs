using System.Collections.Generic;

namespace Domain
{
    class EntityWithEvents : Supertype<EntityWithEvents>, IEventContainer<SomethingHappened>
    {
        public ICollection<SomethingHappened> Events { get; } = new List<SomethingHappened>();

        public void DoSomething()
        {
            // Do something

            Events.Add(new SomethingHappened());
        }
    }
}
