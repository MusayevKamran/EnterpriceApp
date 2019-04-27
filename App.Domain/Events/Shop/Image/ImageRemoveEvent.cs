using App.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Domain.Events.Shop.Image
{
    public class ImageRemoveEvent : Event
    {
        public ImageRemoveEvent(int imageId)
        {
            ImageId = imageId;
            AggregateId = imageId;
        }
        public int ImageId { get; set; }
    }
}
