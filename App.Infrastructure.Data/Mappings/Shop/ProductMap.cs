using App.Domain.Models.Shop;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Infrastructure.Data.Mappings.Shop
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.ProductId);

            builder.HasOne(d => d.Detail);
            builder.HasOne(c => c.Category);
            builder.HasOne(s => s.Seller);
            builder.HasMany(i => i.Images);
            builder.HasMany(c => c.Comments);
        }
    }
}
