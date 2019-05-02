using App.Domain.Models.Shop;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Application.ViewModels.Shop
{
    public class ImageViewModel
    {
        public int ImageId { get; set; }
        public string ImageLink { get; set; }
        public bool ProfileImage { get; set; }
        public Product Product { get; set; }
    }
}
