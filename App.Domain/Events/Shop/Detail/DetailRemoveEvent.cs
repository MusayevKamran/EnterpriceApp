using App.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Domain.Events.Shop.Detail
{
    public class DetailRemoveEvent : Event
    {
        public DetailRemoveEvent(int detailId)
        {
            DetailId = detailId;
            AggregateId = detailId;
        }
        public int DetailId { get; set; }
    }
}
