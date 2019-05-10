using App.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Domain.Events.Shop.Image
{
    public class ImageUpdatedEvent : Event
    {
        public ImageUpdatedEvent(int imageId, string imageLink, bool profileImage, Models.Shop.Product product)
        {
            ImageId = imageId;
            ImageLink = imageLink;
            ProfileImage = profileImage;
            Product = product;
            AggregateId = imageId;
        }
        public int ImageId { get; set; }
        public string ImageLink { get; set; }
        public bool ProfileImage { get; set; }
        public Models.Shop.Product Product { get; set; }
    }
}
