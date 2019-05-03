using App.Domain.Interfaces.Shop;
using App.Domain.Models.Shop;
using App.Infrastructure.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Infrastructure.Data.Repository.Shop
{
    public class ProductRepository : Repository<Product, int>, IProductRepository
    {
        public ProductRepository(ShopDbContext context) : base(context)
        { }
    }
}
