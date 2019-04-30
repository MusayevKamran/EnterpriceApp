using System;
using System.Collections.Generic;
using System.Text;

namespace App.Domain.Commands.Shop.Product
{
    public class RemoveProductCommand : ProductCommand
    {
        public RemoveProductCommand(int productId)
        {
            ProductId = productId;
            AggregateId = productId;
        }
        public override bool IsValid()
        {
            throw new NotImplementedException();
        }
    }
}
