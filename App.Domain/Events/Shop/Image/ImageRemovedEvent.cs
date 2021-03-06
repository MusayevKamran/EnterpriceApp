﻿using App.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Domain.Events.Shop.Image
{
    public class ImageRemovedEvent : Event
    {
        public ImageRemovedEvent(int imageId)
        {
            ImageId = imageId;
            AggregateId = imageId;
        }
        public int ImageId { get; set; }
    }
}
