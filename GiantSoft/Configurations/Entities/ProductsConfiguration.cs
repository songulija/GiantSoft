using GiantSoft.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GiantSoft.Configurations.Entities
{
    public class ProductsConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
               new Product
               {
                   Id = 1,
                   BrandId = 1,
                   UserId = 0,
                   CategoryId=1,
                   ProductName= "IPhone 11",
                   ModelYear= DateTime.Now,
                   Price= 899,
                   CountInStock= 2,
                   Description= "string",
                   Color= "Pink",
                   Country= "Lithuania",
                   City= "Vilnius",
                   AddDate= DateTime.Now,
                   ExpireDate= DateTime.Now,
                   OtherBrand= "string",
                   ImageString= "https://store.storeimages.cdn-apple.com/4668/as-images.apple.com/is/iphone-13-family-select-2021?wid=940&hei=1112&fmt=jpeg&qlt=80&.v=1629842667000"
               },
               new Product
               {
                   Id = 2,
                   BrandId = 1,
                   UserId = 0,
                   CategoryId = 1,
                   ProductName = "IPhone 11",
                   ModelYear = DateTime.Now,
                   Price = 899,
                   CountInStock = 2,
                   Description = "string",
                   Color = "Pink",
                   Country = "Lithuania",
                   City = "Vilnius",
                   AddDate = DateTime.Now,
                   ExpireDate = DateTime.Now,
                   OtherBrand = "string",
                   ImageString = "https://store.storeimages.cdn-apple.com/4668/as-images.apple.com/is/iphone-13-family-select-2021?wid=940&hei=1112&fmt=jpeg&qlt=80&.v=1629842667000"
               },
               new Product
               {
                   Id = 3,
                   BrandId = 1,
                   UserId = 0,
                   CategoryId = 1,
                   ProductName = "IPhone 11",
                   ModelYear = DateTime.Now,
                   Price = 899,
                   CountInStock = 2,
                   Description = "string",
                   Color = "Pink",
                   Country = "Lithuania",
                   City = "Vilnius",
                   AddDate = DateTime.Now,
                   ExpireDate = DateTime.Now,
                   OtherBrand = "string",
                   ImageString = "https://store.storeimages.cdn-apple.com/4668/as-images.apple.com/is/iphone-13-family-select-2021?wid=940&hei=1112&fmt=jpeg&qlt=80&.v=1629842667000"
               },
               new Product
               {
                   Id = 4,
                   BrandId = 1,
                   UserId = 0,
                   CategoryId = 1,
                   ProductName = "IPhone 11",
                   ModelYear = DateTime.Now,
                   Price = 899,
                   CountInStock = 2,
                   Description = "string",
                   Color = "Pink",
                   Country = "Lithuania",
                   City = "Vilnius",
                   AddDate = DateTime.Now,
                   ExpireDate = DateTime.Now,
                   OtherBrand = "string",
                   ImageString = "https://store.storeimages.cdn-apple.com/4668/as-images.apple.com/is/iphone-13-family-select-2021?wid=940&hei=1112&fmt=jpeg&qlt=80&.v=1629842667000"
               },
               new Product
               {
                   Id = 5,
                   BrandId = 1,
                   UserId = 0,
                   CategoryId = 1,
                   ProductName = "IPhone 11",
                   ModelYear = DateTime.Now,
                   Price = 899,
                   CountInStock = 2,
                   Description = "string",
                   Color = "Pink",
                   Country = "Lithuania",
                   City = "Vilnius",
                   AddDate = DateTime.Now,
                   ExpireDate = DateTime.Now,
                   OtherBrand = "string",
                   ImageString = "https://store.storeimages.cdn-apple.com/4668/as-images.apple.com/is/iphone-13-family-select-2021?wid=940&hei=1112&fmt=jpeg&qlt=80&.v=1629842667000"
               },
               new Product
               {
                   Id = 6,
                   BrandId = 1,
                   UserId = 0,
                   CategoryId = 1,
                   ProductName = "IPhone 11",
                   ModelYear = DateTime.Now,
                   Price = 899,
                   CountInStock = 2,
                   Description = "string",
                   Color = "Pink",
                   Country = "Lithuania",
                   City = "Vilnius",
                   AddDate = DateTime.Now,
                   ExpireDate = DateTime.Now,
                   OtherBrand = "string",
                   ImageString = "https://store.storeimages.cdn-apple.com/4668/as-images.apple.com/is/iphone-13-family-select-2021?wid=940&hei=1112&fmt=jpeg&qlt=80&.v=1629842667000"
               },
               new Product
               {
                   Id = 7,
                   BrandId = 1,
                   UserId = 0,
                   CategoryId = 1,
                   ProductName = "IPhone 11",
                   ModelYear = DateTime.Now,
                   Price = 899,
                   CountInStock = 2,
                   Description = "string",
                   Color = "Pink",
                   Country = "Lithuania",
                   City = "Vilnius",
                   AddDate = DateTime.Now,
                   ExpireDate = DateTime.Now,
                   OtherBrand = "string",
                   ImageString = "https://store.storeimages.cdn-apple.com/4668/as-images.apple.com/is/iphone-13-family-select-2021?wid=940&hei=1112&fmt=jpeg&qlt=80&.v=1629842667000"
               },
               new Product
               {
                   Id = 8,
                   BrandId = 1,
                   UserId = 0,
                   CategoryId = 1,
                   ProductName = "IPhone 11",
                   ModelYear = DateTime.Now,
                   Price = 899,
                   CountInStock = 2,
                   Description = "string",
                   Color = "Pink",
                   Country = "Lithuania",
                   City = "Vilnius",
                   AddDate = DateTime.Now,
                   ExpireDate = DateTime.Now,
                   OtherBrand = "string",
                   ImageString = "https://store.storeimages.cdn-apple.com/4668/as-images.apple.com/is/iphone-13-family-select-2021?wid=940&hei=1112&fmt=jpeg&qlt=80&.v=1629842667000"
               },
               new Product
               {
                   Id = 9,
                   BrandId = 1,
                   UserId = 0,
                   CategoryId = 1,
                   ProductName = "IPhone 11",
                   ModelYear = DateTime.Now,
                   Price = 899,
                   CountInStock = 2,
                   Description = "string",
                   Color = "Pink",
                   Country = "Lithuania",
                   City = "Vilnius",
                   AddDate = DateTime.Now,
                   ExpireDate = DateTime.Now,
                   OtherBrand = "string",
                   ImageString = "https://store.storeimages.cdn-apple.com/4668/as-images.apple.com/is/iphone-13-family-select-2021?wid=940&hei=1112&fmt=jpeg&qlt=80&.v=1629842667000"
               },
               new Product
               {
                   Id = 10,
                   BrandId = 1,
                   UserId = 0,
                   CategoryId = 1,
                   ProductName = "IPhone 11",
                   ModelYear = DateTime.Now,
                   Price = 899,
                   CountInStock = 2,
                   Description = "string",
                   Color = "Pink",
                   Country = "Lithuania",
                   City = "Vilnius",
                   AddDate = DateTime.Now,
                   ExpireDate = DateTime.Now,
                   OtherBrand = "string",
                   ImageString = "https://store.storeimages.cdn-apple.com/4668/as-images.apple.com/is/iphone-13-family-select-2021?wid=940&hei=1112&fmt=jpeg&qlt=80&.v=1629842667000"
               },
               new Product
               {
                   Id = 11,
                   BrandId = 1,
                   UserId = 0,
                   CategoryId = 1,
                   ProductName = "IPhone 11",
                   ModelYear = DateTime.Now,
                   Price = 899,
                   CountInStock = 2,
                   Description = "string",
                   Color = "Pink",
                   Country = "Lithuania",
                   City = "Vilnius",
                   AddDate = DateTime.Now,
                   ExpireDate = DateTime.Now,
                   OtherBrand = "string",
                   ImageString = "https://store.storeimages.cdn-apple.com/4668/as-images.apple.com/is/iphone-13-family-select-2021?wid=940&hei=1112&fmt=jpeg&qlt=80&.v=1629842667000"
               },
               new Product
               {
                   Id = 12,
                   BrandId = 1,
                   UserId = 0,
                   CategoryId = 1,
                   ProductName = "IPhone 11",
                   ModelYear = DateTime.Now,
                   Price = 899,
                   CountInStock = 2,
                   Description = "string",
                   Color = "Pink",
                   Country = "Lithuania",
                   City = "Vilnius",
                   AddDate = DateTime.Now,
                   ExpireDate = DateTime.Now,
                   OtherBrand = "string",
                   ImageString = "https://store.storeimages.cdn-apple.com/4668/as-images.apple.com/is/iphone-13-family-select-2021?wid=940&hei=1112&fmt=jpeg&qlt=80&.v=1629842667000"
               }
            );
        }
    }
}
