using App.Domain.Core.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Domain.Commands.Shop.Comment
{
    public abstract class CommentCommand : Command
    {
        public int CommentId { get; set; }
        public string CommentContent { get; set; }
        public Models.Shop.Product Product { get; set; }
        public int UserId { get; set; }
    }
}
