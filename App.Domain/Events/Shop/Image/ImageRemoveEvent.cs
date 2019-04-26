using App.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Domain.Events.Shop.Image
{
    public class ImageRemoveEvent : Event
    {
        public ImageRemoveEvent(Guid imageId)
        {
            ImageId = imageId;
            AggregateId = imageId;
        }
        public Guid ImageId { get; set; }
    }
}
