using App.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Domain.Models.Shop
{
    public class Comment : Entity
    {
        public Comment(Guid commentId, string commentContent)
        {
            CommentId = commentId;
            CommentContent = commentContent;
        }
        public Guid CommentId { get; set; }
        public string CommentContent { get; set; }
        public Product Product { get; set; }
        //public User User { get; set; }
    }
}
