using App.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Domain.Events.Shop.Seller
{
    public class SellerRemoveEvent : Event
    {
        public SellerRemoveEvent(int sellerId)
        {
            SellerId = sellerId;
            AggregateId = sellerId;
        }
        public int SellerId { get; set; }
    }
}
