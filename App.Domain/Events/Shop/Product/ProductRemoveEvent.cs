using App.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Domain.Events.Shop.Product
{
    public class ProductRemoveEvent : Event
    {
        public ProductRemoveEvent(int productId)
        {
            ProductId = productId;
            AggregateId = productId;
        }
        public int ProductId { get; set; }
    }
}
