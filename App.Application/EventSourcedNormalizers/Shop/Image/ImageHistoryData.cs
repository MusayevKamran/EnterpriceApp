using App.Application.ViewModels.Shop;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Application.EventSourcedNormalizers.Shop.Image
{
    public class ImageHistoryData
    {
        public int ImageId { get; set; }
        public string ImageLink { get; set; }
        public bool ProfileImage { get; set; }
        public ProductViewModel ProductViewModel { get; set; }
        public string Action { get; set; }
        public string When { get; set; }
        public string Who { get; set; }
    }
}
