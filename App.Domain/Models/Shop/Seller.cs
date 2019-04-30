using App.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Domain.Models.Shop
{
    public class Seller : Entity<int>
    {
        public Seller() { }
        public Seller(Guid sellerId, string name, string email, string phoneNumber)
        {
            SellerId = sellerId;
            Name = name;
            Email = email;
            PhoneNumber = phoneNumber;
            Products = new HashSet<Product>();
        }
        public Guid SellerId { get; set; }
        public virtual string Name { get; private set; }
        public virtual string Email { get; private set; }
        public virtual string PhoneNumber { get; private set; }
        public virtual ICollection<Product> Products { get; private set; }
    }
}

