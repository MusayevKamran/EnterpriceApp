using App.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Domain.Events.Shop.Detail
{
    public class DetailUpdateEvent : Event
    {
        public DetailUpdateEvent(Guid detailId, string detailName, string detailFeature)
        {
            DetailId = detailId;
            DetailName = detailName;
            DetailFeature = detailFeature;
        }
        public Guid DetailId { get; set; }
        public string DetailName { get; set; }
        public string DetailFeature { get; set; }

    }
}

