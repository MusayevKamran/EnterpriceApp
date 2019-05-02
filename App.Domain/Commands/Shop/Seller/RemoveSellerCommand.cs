using System;
using System.Collections.Generic;
using System.Text;

namespace App.Domain.Commands.Shop.Seller
{
    public class RemoveSellerCommand : SellerCommand
    {
        public RemoveSellerCommand(int sellerId)
        {
            SellerId = sellerId;
            AggregateId = sellerId;
        }
        public override bool IsValid()
        {
            return true;
        }
    }
}
