using App.Domain.Models.Shop;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Infrastructure.Data.Mappings.Shop
{
    public class DetailMap : IEntityTypeConfiguration<Detail>
    {
        public void Configure(EntityTypeBuilder<Detail> builder)
        {
            builder.HasKey(d => d.DetailId);
            builder.HasOne(c => c.Category);
        }
    }
}
