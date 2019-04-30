using App.Domain.Core.Models;
using System;
using System.Collections.Generic;

namespace App.Domain.Models.Shop
{
    public class Product : Entity<int>
    {
        public Product() { }

        public Product(int productId, string productName, Category category, Detail detail, Seller seller, ICollection<Image> images)
        {
            ProductId = productId;
            ProductName = productName;
            Category = category;
            Detail = detail;
            Seller = seller;
            Images = images;
            Comments = new HashSet<Comment>();
        }
        public int ProductId { get; private set; }
        public virtual string ProductName { get; private set; }
        public virtual Detail Detail { get; private set; }
        public virtual Category Category { get; private set; }
        public virtual Seller Seller { get; private set; }
        public virtual ICollection<Image> Images { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }

    }
}
