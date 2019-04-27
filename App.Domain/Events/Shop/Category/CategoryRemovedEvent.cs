using App.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Domain.Events.Shop.Category
{
    public class CategoryRemovedEvent : Event
    {
        public CategoryRemovedEvent(int categoryId)
        {
            CategoryId = categoryId;
            AggregateId = categoryId;
        }
        public int CategoryId { get; set; }
    }
}
