
using App.Domain.Models.Shop;
using System.Collections.Generic;

namespace App.Application.ViewModels.Shop
{
    public class ProductViewModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public Category Category { get; set; }
        public Detail Detail { get; set; }
        public Seller Seller { get; set; }
        public ICollection<Image> Image { get; set; }
    }
}
