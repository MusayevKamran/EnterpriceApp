using App.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Domain.Models.Shop
{
    public class Seller : Entity<int>
    {
        public Seller(Guid sellerId, string name, string email, string phoneNumber)
        {
            SellerId = sellerId;
            Name = name;
            Email = email;
            PhoneNumber = phoneNumber;
        }
        public Guid SellerId { get; set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string PhoneNumber { get; private set; }
    }
}

