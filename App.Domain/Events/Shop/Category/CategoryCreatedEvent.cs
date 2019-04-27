using App.Domain.Core.Events;
using App.Domain.Models.Shop;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Domain.Events.Shop.Category
{
    public class CategoryCreatedEvent : Event
    {
        public CategoryCreatedEvent(int categoryId, string categoryName)
        {   
            CategoryId = categoryId;
            CategoryName = categoryName;
        }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
