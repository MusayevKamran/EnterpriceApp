using App.Domain.Models.Shop;
using System;

namespace App.Domain.Interfaces.Shop
{
    public interface ISellerRepository : IRepository<Seller, int>
    {
    }
}
