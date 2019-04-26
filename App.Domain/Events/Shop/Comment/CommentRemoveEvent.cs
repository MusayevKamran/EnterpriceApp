using App.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Domain.Events.Shop.Comment
{
    public class CommentRemoveEvent : Event
    {
        public CommentRemoveEvent(Guid commentId)
        {
            CommentId = commentId;
            AggregateId = commentId;
        }
        public Guid CommentId { get; set; }
    }
}
