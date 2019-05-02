using System;
using System.Collections.Generic;
using System.Text;

namespace App.Domain.Commands.Shop.Image
{
    public class CreateNewImageCommand : ImageCommand
    {
        public CreateNewImageCommand(int imageId, string imageLink, bool profileImage, Models.Shop.Product product)
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
