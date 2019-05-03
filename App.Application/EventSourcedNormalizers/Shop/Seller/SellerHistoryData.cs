using System;
using System.Collections.Generic;
using System.Text;

namespace App.Application.EventSourcedNormalizers.Shop.Seller
{
    public class SellerHistoryData
    {
        public int SellerId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Action { get; set; }
        public string When { get; set; }
        public string Who { get; set; }
    }
}
