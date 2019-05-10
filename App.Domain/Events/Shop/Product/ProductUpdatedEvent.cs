using App.Domain.Core.Events;
using App.Domain.Models.Shop;
using System;
using System.Collections.Generic;

namespace App.Domain.Events.Shop.Product
{
    public class ProductUpdatedEvent : Event
    {
        public ProductUpdatedEvent(int productId, string productName, Models.Shop.Category category, Models.Shop.Detail detail,  Models.Shop.Seller seller, ICollection<Models.Shop.Image> images)
        {
            ProductId = productId;
            ProductName = productName;
            Category = category;
            Detail = detail;
            Seller = seller;
            Images = images;
            AggregateId = productId;
        }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public Models.Shop.Category Category { get; set; }
        public Models.Shop.Detail Detail { get; set; }
        public Models.Shop.Seller Seller { get; set; }
        public ICollection<Models.Shop.Image> Images { get; set; }

    }
}
