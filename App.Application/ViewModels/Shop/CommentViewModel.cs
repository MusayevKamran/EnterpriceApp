using App.Domain.Models.Shop;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Application.ViewModels.Shop
{
    public class CommentViewModel
    {
        public int CommentId { get;  set; }
        public string CommentContent { get;  set; }
        public Product Product { get;  set; }
        public int UserId { get; set; }
    }
}
