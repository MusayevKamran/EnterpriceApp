using App.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Domain.Events.Shop.Comment
{
    public class CommentUpdateEvent : Event
    {
        public CommentUpdateEvent(Guid commentId, string commentContent, Models.Shop.Product product)
        {
            CommentId = commentId;
            CommentContent = commentContent;
            Product = product;
        }
        public Guid CommentId { get; set; }
        public string CommentContent { get; set; }
        public Models.Shop.Product Product { get; set; }
    }
}
