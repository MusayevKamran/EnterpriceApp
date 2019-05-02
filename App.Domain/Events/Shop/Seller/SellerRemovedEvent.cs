using App.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Domain.Events.Shop.Seller
{
    public class SellerRemovedEvent : Event
    {
        public SellerRemovedEvent(int sellerId)
        {
            SellerId = sellerId;
            AggregateId = sellerId;
        }
        public int SellerId { get; set; }
    }
}
