using GiantSoft.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GiantSoft.Configurations.Entities
{ /// <summary>
  /// Letting BrandConfiguration class know that it'll be inhereted from
  /// IEntityTypeConfiguration of type Brand
  /// here we will define our initial Brands for database
  /// </summary>
    public class BrandsConfiguration : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.HasData(
                new Brand
                {
                    Id = 1,
                    BrandName = "Adidas"
                },
                new Brand
                {
                    Id = 2,
                    BrandName = "H&M"
                },
                new Brand
                {
                    Id = 3,
                    BrandName = "Nike"
                },
                new Brand
                {
                    Id = 4,
                    BrandName = "Zara"
                },
                new Brand
                {
                    Id = 5,
                    BrandName = "Levi's"
                },
                new Brand
                {
                    Id = 6,
                    BrandName = "Ralph Lauren"
                },
                new Brand
                {
                    Id = 7,
                    BrandName = "Tommy Hilfiger"
                },
                new Brand
                {
                    Id = 8,
                    BrandName = "Calvin Klein"
                },
                new Brand
                {
                    Id = 9,
                    BrandName = "Guess"
                },
                new Brand
                {
                    Id = 10,
                    BrandName = "Lacoste"
                },
                new Brand
                {
                    Id = 11,
                    BrandName = "Emporio Armani"
                },
                new Brand
                {
                    Id = 12,
                    BrandName = "Tom Tailor"
                },
                new Brand
                {
                    Id = 13,
                    BrandName = "Columbia"
                },
                new Brand
                {
                    Id = 14,
                    BrandName = "Crocs"
                },
                new Brand
                {
                    Id = 15,
                    BrandName = "Diesel"
                },
                new Brand
                {
                    Id = 16,
                    BrandName = "Hummel"
                },
                new Brand
                {
                    Id = 17,
                    BrandName = "Jack&Jones"
                },
                new Brand
                {
                    Id = 18,
                    BrandName = "Kappa"
                },
                new Brand
                {
                    Id = 19,
                    BrandName = "Napajiri"
                },
                new Brand
                {
                    Id = 20,
                    BrandName = "Puma"
                },
                new Brand
                {
                    Id = 21,
                    BrandName = "Reebok"
                },
                new Brand
                {
                    Id = 22,
                    BrandName = "New Balance"
                },
                new Brand
                {
                    Id = 23,
                    BrandName = "Timberland"
                },
                new Brand
                {
                    Id = 24,
                    BrandName = "Under Armour"
                }
            );
        }
    }
}
