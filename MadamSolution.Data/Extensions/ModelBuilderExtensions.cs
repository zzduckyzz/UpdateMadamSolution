﻿using MadamSolution.Data.Entities;
using MadamSolution.Data.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MadamSolution.Data.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppConfig>().HasData(
               new AppConfig() { Key = "HomeTitle", Value = "Welcome" },
               new AppConfig() { Key = "HomeKeyword", Value = "Abc" },
               new AppConfig() { Key = "HomeDescription", Value = "OnlineShop" }
               );
            modelBuilder.Entity<Language>().HasData(
                new Language() { Id = "vi", Name = "Tiếng Việt", IsDefault = true },
                new Language() { Id = "en", Name = "English", IsDefault = false });

            modelBuilder.Entity<Category>().HasData(
                new Category()
                {
                    Id = 1,
                    IsShowOnHome = true,
                    ParentId = null,
                    SortOrder = 1,
                    Status = Status.Active,
                },
                new Category()
                {
                    Id = 2,
                    IsShowOnHome = true,
                    ParentId = null,
                    SortOrder = 2,
                    Status = Status.Active,
                },
                new Category()
                {
                    Id = 3,
                    IsShowOnHome = true,
                    ParentId = null,
                    SortOrder = 3,
                    Status = Status.Active,
                },

                 new Category()
                 {
                     Id = 4,
                     IsShowOnHome = true,
                     ParentId = null,
                     SortOrder = 4,
                     Status = Status.Active
                 });

            modelBuilder.Entity<CategoryTranslation>().HasData(
                  new CategoryTranslation() { Id = 1, CategoryId = 1, Name = "Áo Phông", LanguageId = "vi", SeoAlias = "ao-phong", SeoDescription = "Áo Phông", SeoTitle = "Áo Phông" },
                  new CategoryTranslation() { Id = 2, CategoryId = 1, Name = "Women T-Shirt", LanguageId = "en", SeoAlias = "Women T-Shirt", SeoDescription = "Women T-Shirt", SeoTitle = "Women T-Shirt" },
                  new CategoryTranslation() { Id = 3, CategoryId = 2, Name = "Áo nỉ", LanguageId = "vi", SeoAlias = "ao-ni", SeoDescription = "Áo nỉ chui đầu", SeoTitle = "Áo nỉ chui đầu" },
                  new CategoryTranslation() { Id = 4, CategoryId = 2, Name = "Women Hoodie", LanguageId = "en", SeoAlias = "Women Hoodie", SeoDescription = "The hoodie products for women", SeoTitle = "The hoodie products for women" },
                  new CategoryTranslation() { Id = 5, CategoryId = 3, Name = "Áo len", LanguageId = "vi", SeoAlias = "ao-len", SeoDescription = "Áo len", SeoTitle = "Áo len" },
                  new CategoryTranslation() { Id = 6, CategoryId = 3, Name = "Women Sweater", LanguageId = "en", SeoAlias = "women-Sweater", SeoDescription = "Women Sweater", SeoTitle = "Women Sweater" },
                  new CategoryTranslation() { Id = 7, CategoryId = 4, Name = "Áo sơ mi", LanguageId = "vi", SeoAlias = "ao-so-mi", SeoDescription = "blazer nữ", SeoTitle = "blazer nữ" },
                  new CategoryTranslation() { Id = 8, CategoryId = 4, Name = "Women T-Shirt", LanguageId = "en", SeoAlias = "TShirt-women", SeoDescription = "Women T-Shirt", SeoTitle = "Women T-Shirt" });

            modelBuilder.Entity<Product>().HasData(
           new Product()
           {
               Id = 1,
               DateCreated = DateTime.Now,
               OriginalPrice = 100000,
               Price = 200000,
               Stock = 1,
               ViewCount = 0,
           });
            modelBuilder.Entity<ProductTranslation>().HasData(
                 new ProductTranslation()
                 {
                     Id = 1,
                     ProductId = 1,
                     Name = "Áo phông trơn zara",
                     LanguageId = "vi",
                     SeoAlias = "ao-phong-tron-zara",
                     SeoDescription = "Áo phông trơn zara",
                     SeoTitle = "Áo phông trơn zara",
                     Details = "Áo phông trơn zara",
                     Description = "Áo phông trơn zara"
                 },
                    new ProductTranslation()
                    {
                        Id = 2,
                        ProductId = 1,
                        Name = "Zara T-Shirt Women",
                        LanguageId = "en",
                        SeoAlias = "zara-t-shirt-women",
                        SeoDescription = "Áo phông zara",
                        SeoTitle = "Áo phông zara",
                        Details = "Áo phông zara",
                        Description = "Áo phông zara"
                    });
            modelBuilder.Entity<ProductInCategory>().HasData(
                new ProductInCategory() { ProductId = 1, CategoryId = 1 }
                );
            var roleId = new Guid("223F4C1D-FA90-4C3E-9BEE-6D29C7BE76A8");
            var adminId = new Guid("A0381E29-F86D-4377-8661-8186912B8FE9");
            modelBuilder.Entity<AppRole>().HasData(new AppRole
            {
                Id = roleId,
                Name = "admin",
                NormalizedName = "admin",
                Description = "Administrator role"
            });

            var hasher = new PasswordHasher<AppUser>();
            modelBuilder.Entity<AppUser>().HasData(new AppUser
            {
                Id = adminId,
                UserName = "admin",
                NormalizedUserName = "admin",
                Email = "duc.phamminh94@gmail.com",
                NormalizedEmail = "duc.phamminh94@gmail.com",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "Handoivodoi1@@@"),
                SecurityStamp = string.Empty,
                FirstName = "Duc",
                LastName = "Pham",
                Dob = new DateTime(2021, 2, 1)
            });

            modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(new IdentityUserRole<Guid>
            {
                RoleId = roleId,
                UserId = adminId
            });
            modelBuilder.Entity<Slide>().HasData(
                new Slide()
                {
                    Id = 1,
                    Name = "Thời trang nữ cao cấp",
                    Description = "Hàng chất lượng mà giá cả lại phải chăng tốt nhất thị trường",
                    Url="#",
                    SortOrder = 1,
                    Image = "/themes/images/carousel/1.png",
                    Status = Status.Active

                },
                new Slide()
                {
                    Id = 2,
                    Name = "Thời trang nữ cao cấp",
                    Description = "Hàng chất lượng mà giá cả lại phải chăng tốt nhất thị trường",
                    Url = "#",
                    SortOrder = 2,
                    Image = "/themes/images/carousel/2.png",
                    Status = Status.Active

                },
                new Slide()
                {
                    Id = 3,
                    Name = "Thời trang nữ cao cấp",
                    Description = "Hàng chất lượng mà giá cả lại phải chăng tốt nhất thị trường",
                    Url = "#",
                    SortOrder = 3,
                    Image = "/themes/images/carousel/3.png",
                    Status = Status.Active

                },
                new Slide()
                {
                    Id = 4,
                    Name = "Thời trang nữ cao cấp",
                    Description = "Hàng chất lượng mà giá cả lại phải chăng tốt nhất thị trường",
                    Url = "#",
                    SortOrder = 4,
                    Image = "/themes/images/carousel/4.png",
                    Status = Status.Active

                },
                new Slide()
                {
                    Id = 5,
                    Name = "Thời trang nữ cao cấp",
                    Description = "Hàng chất lượng mà giá cả lại phải chăng tốt nhất thị trường",
                    Url = "#",
                    SortOrder = 5,
                    Image = "/themes/images/carousel/5.png",
                    Status = Status.Active

                },
                new Slide()
                {
                    Id = 6,
                    Name = "Thời trang nữ cao cấp",
                    Description = "Hàng chất lượng mà giá cả lại phải chăng tốt nhất thị trường",
                    Url = "#",
                    SortOrder = 6,
                    Image = "/themes/images/carousel/6.png",
                    Status = Status.Active

                }
            ) ;


        }





    }
}
