using App.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Domain.Models.Shop
{
    public class Image : Entity<int>
    {
        public Image(Guid imageId, string imageLink, string profileImage)
        {
            ImageId = imageId;
            ImageLink = imageLink;
            ProfileImage = profileImage;
        }
        public Guid ImageId { get; set; }
        public string ImageLink { get; set; }
        public string ProfileImage { get; set; }
    }
}
