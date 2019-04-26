using App.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Domain.Events.Shop.Product
{
    public class ProductRemoveEvent : Event
    {
        public ProductRemoveEvent(Guid productId)
        {
            ProductId = productId;
            AggregateId = productId;
        }
        public Guid ProductId { get; set; }
    }
}
