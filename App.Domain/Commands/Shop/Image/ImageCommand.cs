using App.Domain.Core.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Domain.Commands.Shop.Image
{
    public abstract class ImageCommand : Command
    {
        public int ImageId { get; set; }
        public string ImageLink { get; set; }
        public bool ProfileImage { get; set; }
        public Models.Shop.Product Product { get; set; }
    }
}
