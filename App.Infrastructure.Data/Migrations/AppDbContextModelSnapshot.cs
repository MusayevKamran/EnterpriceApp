﻿// <auto-generated />
using System;
using App.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace App.Infrastructure.Data.Migrations
{
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.0-rtm-35687")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("App.Domain.Models.Shop.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("CategoryId")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("App.Domain.Models.Shop.Comment", b =>
                {
                    b.Property<Guid>("CommentId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CommentContent");

                    b.Property<Guid?>("ProductId");

                    b.HasKey("CommentId");

                    b.HasIndex("ProductId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("App.Domain.Models.Shop.Detail", b =>
                {
                    b.Property<Guid>("DetailId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CategoryId");

                    b.Property<string>("DetailFeature");

                    b.Property<string>("DetailName");

                    b.HasKey("DetailId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Details");
                });

            modelBuilder.Entity("App.Domain.Models.Shop.Image", b =>
                {
                    b.Property<Guid>("ImageId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ImageLink");

                    b.Property<Guid?>("ProductId");

                    b.Property<string>("ProfileImage");

                    b.HasKey("ImageId");

                    b.HasIndex("ProductId");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("App.Domain.Models.Shop.Product", b =>
                {
                    b.Property<Guid>("ProductId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CategoryId");

                    b.Property<Guid?>("DetailId");

                    b.Property<string>("ProductName");

                    b.Property<Guid?>("SellerId");

                    b.HasKey("ProductId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("DetailId");

                    b.HasIndex("SellerId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("App.Domain.Models.Shop.Seller", b =>
                {
                    b.Property<Guid>("SellerId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<string>("Name");

                    b.Property<string>("PhoneNumber");

                    b.HasKey("SellerId");

                    b.ToTable("Sellers");
                });

            modelBuilder.Entity("App.Domain.Models.Shop.Comment", b =>
                {
                    b.HasOne("App.Domain.Models.Shop.Product", "Product")
                        .WithMany("Comments")
                        .HasForeignKey("ProductId");
                });

            modelBuilder.Entity("App.Domain.Models.Shop.Detail", b =>
                {
                    b.HasOne("App.Domain.Models.Shop.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId");
                });

            modelBuilder.Entity("App.Domain.Models.Shop.Image", b =>
                {
                    b.HasOne("App.Domain.Models.Shop.Product")
                        .WithMany("Images")
                        .HasForeignKey("ProductId");
                });

            modelBuilder.Entity("App.Domain.Models.Shop.Product", b =>
                {
                    b.HasOne("App.Domain.Models.Shop.Category", "Category")
                        .WithMany("Product")
                        .HasForeignKey("CategoryId");

                    b.HasOne("App.Domain.Models.Shop.Detail", "Detail")
                        .WithMany()
                        .HasForeignKey("DetailId");

                    b.HasOne("App.Domain.Models.Shop.Seller", "Seller")
                        .WithMany()
                        .HasForeignKey("SellerId");
                });
#pragma warning restore 612, 618
        }
    }
}
