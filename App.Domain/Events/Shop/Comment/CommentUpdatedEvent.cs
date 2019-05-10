using App.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Domain.Events.Shop.Comment
{
    public class CommentUpdatedEvent : Event
    {
        public CommentUpdatedEvent(int commentId, string commentContent, Models.Shop.Product product, int userId)
        {
            CommentId = commentId;
            CommentContent = commentContent;
            Product = product;
            UserID = userId;
            AggregateId = commentId;
        }
        public int CommentId { get; set; }
        public string CommentContent { get; set; }
        public Models.Shop.Product Product { get; set; }
        public int UserID { get; set; }
    }
}
