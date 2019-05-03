using App.Application.ViewModels.Shop;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Application.EventSourcedNormalizers.Shop.Product
{
    public class ProductHistoryData
    {     
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public CategoryViewModel CategoryViewModel { get; set; }
        public DetailViewModel DetailViewModel { get; set; }
        public SellerViewModel SellerViewModel { get; set; }
        public ImageViewModel ImageViewModel { get; set; }
        public string Action { get; set; }
        public string When { get; set; }
        public string Who { get; set; }
    }
}
