using App.Domain.Core.Events;
using App.Domain.Models.Shop;
using System;


namespace App.Domain.Events.Shop.Comment
{
    public class CommentCreatedEvent : Event
    {
        public CommentCreatedEvent(int commentId, string commentContent, Models.Shop.Product product, int userId)
        {
            CommentId = commentId;
            CommentContent = commentContent;
            Product = product;
            UserID = userId;
        }
        public int CommentId { get; set; }
        public string CommentContent { get; set; }
        public Models.Shop.Product Product { get; set; }
        public int UserID { get; set; }
    }
}
