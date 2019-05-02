using System;
using System.Collections.Generic;
using System.Text;

namespace App.Domain.Commands.Shop.Seller
{
    public class UpdateSellerCommand : SellerCommand
    {
        public UpdateSellerCommand(int sellerId, string name, string email, string phoneNumber)
        {
            SellerId = sellerId;
            Name = name;
            Email = email;
            PhoneNumber = phoneNumber;
        }
        public override bool IsValid()
        {
            return true;
        }
    }
}
