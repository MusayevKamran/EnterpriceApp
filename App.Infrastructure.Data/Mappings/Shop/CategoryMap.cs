using App.Domain.Models.Shop;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Infrastructure.Data.Mappings.Shop
{
    public class CategoryMap : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            //builder.Property(c => c.Id).HasColumnName("Id").ValueGeneratedNever();

            builder.HasKey(c => c.CategoryId);

            builder.Property(c => c.CategoryId)
                .HasColumnName("CategoryId")
                .ValueGeneratedOnAdd();

            builder.Property(c => c.CategoryName)
                .HasColumnType("varchar(100)")
                .HasMaxLength(100)
                .IsRequired();

            builder.HasMany(p => p.Products);
        }
    }
}