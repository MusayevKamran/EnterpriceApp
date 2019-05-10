using App.Domain.Interfaces.Shop;
using App.Domain.Models.Shop;
using App.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App.Infrastructure.Data.Repository.Shop
{
    public class CategoryRepository : Repository<Category, int>, ICategoryRepository
    {
        public CategoryRepository(ShopDbContext context) : base(context)
        { }

        public Category GetByIdNoTracking(int categoryId)
        {
            return DbSet.AsNoTracking().FirstOrDefault(c => c.CategoryId == categoryId);
        }
    }
}
