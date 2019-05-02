using App.Domain.Core.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Domain.Commands.Shop.Seller
{
    public abstract class SellerCommand : Command
    {
        public int SellerId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}
