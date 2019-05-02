using App.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Domain.Models.Shop
{
    public class Image : Entity<int>
    {
        public Image() { }
        public Image(int imageId, string imageLink, bool profileImage, Product product)
        {
            ImageId = imageId;
            ImageLink = imageLink;
            ProfileImage = profileImage;
            Product = product;
        }
        public int ImageId { get; private set; }
        public virtual string ImageLink { get; private set; }
        public virtual bool ProfileImage { get; private set; }
        public virtual Product Product { get; private set; }
    }
}
