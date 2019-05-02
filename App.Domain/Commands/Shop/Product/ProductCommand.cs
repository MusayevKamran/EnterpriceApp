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
        public string ProductName { get; set; }
        public Models.Shop.Category Category { get; set; }
        public Models.Shop.Detail Detail { get; set; }
        public Models.Shop.Seller Seller { get; set; }
        public ICollection<Models.Shop.Image> Images { get; set; }
    }
}
