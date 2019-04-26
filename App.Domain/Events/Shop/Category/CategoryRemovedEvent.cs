using App.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Domain.Events.Shop.Category
{
    public class CategoryRemovedEvent : Event
    {
        public CategoryRemovedEvent(Guid categoryId)
        {
            CategoryId = categoryId;
            AggregateId = categoryId;
        }
        public Guid CategoryId { get; set; }
    }
}
