using App.Domain.Core.Commands;
using App.Domain.Models.Shop;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Domain.Commands.Shop.Product
{
    public abstract class ProductCommand : Command
    {
        public int ProductId { get; set; }
        public virtual string ProductName { get; set; }
        public virtual Models.Shop.Category Category { get; set; }
        public virtual Detail Detail { get; set; }     
        public virtual Seller Seller { get; set; }
        public virtual ICollection<Image> Images { get; set; }
    }
}
