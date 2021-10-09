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
                    BrandName = "SKATEDELUXE"
                },
                new Brand
                {
                    Id = 3,
                    BrandName = "DC"
                },
                new Brand
                {
                    Id = 4,
                    BrandName = "Element"
                },
                new Brand
                {
                    Id = 5,
                    BrandName = "Baker"
                },
                new Brand
                {
                    Id = 6,
                    BrandName = "New balance"
                }
            );
        }
    }
}
