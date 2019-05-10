using App.Domain.Core.Events;
using App.Domain.Models.Shop;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Domain.Events.Shop.Category
{
    public class CategoryUpdatedEvent : Event
    {
        public CategoryUpdatedEvent(int categoryId, string categoryName, int subCategory)
        {
            CategoryId = categoryId;
            CategoryName = categoryName;
            SubCategory = subCategory;
            AggregateId = categoryId;
        }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int SubCategory { get; set; }
    }
}
