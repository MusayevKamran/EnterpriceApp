using App.Domain.Core.Models;
using System;
using System.Collections.Generic;

namespace App.Domain.Models.Shop
{
    public class Product : Entity<int>
    {
        public Product(Guid productId, string productName)
        {
            ProductId = productId;
            ProductName = productName;
            Images = new HashSet<Image>(); ;
            Comments = new HashSet<Comment>();
        }
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public Detail Detail { get; set; }
        public Category Category { get; set; }
        public Seller Seller { get; set; }
        public ICollection<Image> Images { get; set; }
        public ICollection<Comment> Comments { get; set; }

    }
}
