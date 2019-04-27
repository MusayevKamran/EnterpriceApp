using App.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Domain.Models.Shop
{
    public class Category : Entity<int>
    {
        public Category(int categoryId, string categoryName)
        {
            CategoryId = categoryId;
            CategoryName = categoryName;
            Product = new HashSet<Product>();
        }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public ICollection<Product> Product { get; set; }
    }
}
