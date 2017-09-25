namespace Domain.EventSourcing
{
    internal class InventoryItemDeactivated : Event
    {
        private object _id;

        public InventoryItemDeactivated(object id)
        {
        }
    }
}