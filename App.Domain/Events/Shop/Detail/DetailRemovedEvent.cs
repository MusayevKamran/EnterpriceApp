using App.Domain.Core.Events;

namespace App.Domain.Events.Shop.Detail
{
    public class DetailRemovedEvent : Event
    {
        public DetailRemovedEvent(int detailId)
        {
            DetailId = detailId;
            AggregateId = detailId;
        }
        public int DetailId { get; set; }
    }
}
