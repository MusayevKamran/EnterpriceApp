using App.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Domain.Models.Shop
{
    public class Comment : Entity<int>
    {
        public Comment() { }
        public Comment(int commentId, string commentContent, Product product, int userId)
        {
            CommentId = commentId;
            CommentContent = commentContent;
            Product = product;
            UserId = userId;
        }
        public int CommentId { get; private set; }
        public virtual string CommentContent { get; private set; }
        public virtual Product Product { get; private set; }
        public int UserId { get; set; }
    }
}
