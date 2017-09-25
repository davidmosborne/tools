using System;

namespace Domain.EventSourcing
{
    public class InventoryItem : AggregateRoot
    {
        private bool _activated;

        private void Apply(InventoryItemDeactivated e)
        {
            _activated = false;
        }

        public void Deactivate()
        {
            if (!_activated) throw new InvalidOperationException("already deactivated");
            ApplyChange(new InventoryItemDeactivated(Id));
        }

        public override Guid Id { get; }
    }
}
