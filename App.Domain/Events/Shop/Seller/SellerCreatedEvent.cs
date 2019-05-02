using App.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Domain.Events.Shop.Seller
{
    public class SellerCreatedEvent : Event
    {
        public SellerCreatedEvent(int sellerId, string name, string email, string phoneNumber)
        {
            SellerId = sellerId;
            Name = name;
            Email = email;
            PhoneNumber = phoneNumber;
        }
        public int SellerId { get; set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string PhoneNumber { get; private set; }

    }
}
