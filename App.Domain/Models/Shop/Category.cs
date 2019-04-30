using App.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Domain.Models.Shop
{
    public class Category : Entity<int>
    {
        public Category() { }
        public Category(int categoryId, string categoryName)
        {
            CategoryId = categoryId;
            CategoryName = categoryName;
            Products = new HashSet<Product>();
        }
        public int CategoryId { get; private set; }
        public virtual string CategoryName { get; private set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
