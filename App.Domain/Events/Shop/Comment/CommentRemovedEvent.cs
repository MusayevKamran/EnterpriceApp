using App.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Domain.Events.Shop.Comment
{
    public class CommentRemovedEvent : Event
    {
        public CommentRemovedEvent(int commentId)
        {
            CommentId = commentId;
            AggregateId = commentId;
        }
        public int CommentId { get; set; }
    }
}
