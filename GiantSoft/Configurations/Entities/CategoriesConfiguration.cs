using GiantSoft.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GiantSoft.Configurations.Entities
{
    /// <summary>
    /// Letting CategoriesConfiguration class know that it'll be inhereted from
    /// IEntityTypeConfiguration of type Category
    /// here we will define our initial Categories for database
    /// </summary>
    public class CategoriesConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(
                new Category
                {
                    Id = 1,
                    Name = "Skateboards",
                    ParentId = null
                },
                new Category
                {
                    Id = 2,
                    Name = "Shoes",
                    ParentId = null
                },
                new Category
                {
                    Id = 3,
                    Name = "Accessories",
                    ParentId = null
                },
                new Category
                {
                    Id = 4,
                    Name = "Longboards",
                    ParentId = 1
                },
                new Category
                {
                    Id = 5,
                    Name = "Regular skateboards",
                    ParentId = 1
                },
                new Category
                {
                    Id = 6,
                    Name = "Man",
                    ParentId = 2
                },
                new Category
                {
                    Id = 7,
                    Name = "Women",
                    ParentId = 2
                },
                new Category
                {
                    Id = 8,
                    Name = "Skate shoes",
                    ParentId = 6
                },
                new Category
                {
                    Id = 9,
                    Name = "Sneakers",
                    ParentId = 6
                },
                new Category
                {
                    Id = 10,
                    Name = "Skate shoes",
                    ParentId = 7
                },
                new Category
                {
                    Id = 11,
                    Name = "Sneakers",
                    ParentId = 7
                }

            );
        }
    }
}
