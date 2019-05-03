using App.Application.ViewModels.Shop;
using App.Domain.Models.Shop;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Application.EventSourcedNormalizers.Shop.Category
{
    public class CategoryHistoryData
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int SubCategory { get; set; }
        public string Action { get; set; }
        public string When { get; set; }
        public string Who { get; set; }
    }
}
