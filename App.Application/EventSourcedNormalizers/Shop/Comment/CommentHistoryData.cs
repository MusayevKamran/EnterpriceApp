using App.Application.ViewModels.Shop;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Application.EventSourcedNormalizers.Shop.Comment
{
    public class CommentHistoryData
    {
        public int CommentId { get; set; }
        public string CommentContent { get; set; }
        public ProductViewModel ProductViewModel { get; set; }
        public int UserId { get; set; }
        public string Action { get; set; }
        public string When { get; set; }
        public string Who { get; set; }
    }
}
