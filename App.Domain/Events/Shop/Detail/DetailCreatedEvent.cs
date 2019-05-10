using App.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Domain.Events.Shop.Detail
{
    public class DetailCreatedEvent : Event
    {
        public DetailCreatedEvent(int detailId, string detailName, string detailFeature, Models.Shop.Category category)
        {
            DetailId = detailId;
            DetailName = detailName;
            DetailFeature = detailFeature;
            Category = category;
            AggregateId = detailId;
        }
        public int DetailId { get; set; }
        public string DetailName { get; set; }
        public string DetailFeature { get; set; }
        public Models.Shop.Category Category { get; private set; }

    }
}
