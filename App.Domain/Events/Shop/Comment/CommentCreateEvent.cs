using App.Domain.Core.Events;
using App.Domain.Models.Shop;
using System;


namespace App.Domain.Events.Shop.Comment
{
    public class CommentCreateEvent : Event
    {
        public CommentCreateEvent(Guid commentId, string commentContent, Models.Shop.Product product)
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
