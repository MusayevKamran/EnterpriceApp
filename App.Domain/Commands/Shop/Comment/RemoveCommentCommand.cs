using System;
using System.Collections.Generic;
using System.Text;

namespace App.Domain.Commands.Shop.Comment
{
    public class RemoveCommentCommand : CommentCommand
    {
        public RemoveCommentCommand(int commentId)
        {
            CommentId = commentId;
            AggregateId = commentId;
        }
        public override bool IsValid()
        {
            return true;
        }
    }
}
