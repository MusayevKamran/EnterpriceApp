using System;
using System.Collections.Generic;
using System.Text;

namespace App.Domain.Commands.Shop.Product
{
    public class UpdateProductCommand : ProductCommand
    {
        public UpdateProductCommand(int productId, string productName, Models.Shop.Category category, Models.Shop.Detail detail, Models.Shop.Seller seller, ICollection<Models.Shop.Image> images)
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
            throw new NotImplementedException();
        }
    }
}
