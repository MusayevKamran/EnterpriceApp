using App.Application.ViewModels.Shop;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Application.EventSourcedNormalizers.Shop.Detail
{
    public class DetailHistoryData
    {
        public int DetailId { get; set; }
        public string DetailName { get; set; }
        public string DetailFeature { get; set; }
        public CategoryViewModel CategoryViewModel { get; set; }
        public string Action { get; set; }
        public string When { get; set; }
        public string Who { get; set; }
    }
}
