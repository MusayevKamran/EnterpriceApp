using System;
using System.Collections.Generic;
using System.Text;
using App.Domain.Models.Shop;

namespace App.Domain.Commands.Shop.Product
{
    public class CreateNewProductCommand : ProductCommand
    {
        public CreateNewProductCommand(int productId, string productName, Models.Shop.Category category, Models.Shop.Detail detail, Models.Shop.Seller seller, ICollection<Models.Shop.Image> images)
        {
            ProductId = productId;
            ProductName = productName;
            Category = category;
            Detail = detail;
            Seller = seller;
            Images = images;
        }

        public override bool IsValid()
        {
            return true;
        }
    }
}
