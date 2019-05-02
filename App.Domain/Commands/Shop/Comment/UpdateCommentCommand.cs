using System;
using System.Collections.Generic;
using System.Text;

namespace App.Domain.Commands.Shop.Comment
{
    public class UpdateCommentCommand : CommentCommand
    {
        public UpdateCommentCommand(int commentId, string commentContent, Models.Shop.Product product, int userId)
        {
            CommentId = commentId;
            CommentContent = commentContent;
            Product = product;
            UserId = userId;
        }

        public override bool IsValid()
        {
            return true;
        }
    }
}
