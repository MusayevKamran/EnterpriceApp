using System;
using System.Collections.Generic;
using System.Text;

namespace App.Domain.Commands.Shop.Image
{
    public class UpdateImageCommand : ImageCommand
    {
        public UpdateImageCommand(int imageId, string imageLink, bool profileImage, Models.Shop.Product product)
        {
            ImageId = imageId;
            ImageLink = imageLink;
            ProfileImage = profileImage;
            Product = product;
        }
        public override bool IsValid()
        {
            return true;
        }
    }
}
