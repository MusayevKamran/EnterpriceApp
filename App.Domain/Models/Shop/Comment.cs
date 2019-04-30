using App.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Domain.Models.Shop
{
    public class Comment : Entity<int>
    {
        public Comment() { }
        public Comment(int commentId, string commentContent,Product product)
        {
            CommentId = commentId;
            CommentContent = commentContent;
            Product = product;
        }
        public int CommentId { get; private set; }
        public virtual string CommentContent { get; private set; }
        public virtual Product Product { get; private set; }
        //public User User { get; set; }
    }
}
