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
                   Price = 1199,
                   CountInStock = 2,
                   Description = "string",
                   Color = "Pink",
                   Country = "Lithuania",
                   City = "Vilnius",
                   AddDate = DateTime.Now,
                   ExpireDate = DateTime.Now,
                   OtherBrand = "string",
                   ImageString = "https://brain-images-ssl.cdn.dixons.com/4/8/10230584/u_10230584.jpg"
               },
               new Product
               {
                   Id = 3,
                   BrandId = 1,
                   UserId = 0,
                   CategoryId = 1,
                   ProductName = "IPhone 10 Pro",
                   ModelYear = DateTime.Now,
                   Price = 1099,
                   CountInStock = 4,
                   Description = "string",
                   Color = "Pink",
                   Country = "Lithuania",
                   City = "Vilnius",
                   AddDate = DateTime.Now,
                   ExpireDate = DateTime.Now,
                   OtherBrand = "string",
                   ImageString = "https://brain-images-ssl.cdn.dixons.com/6/0/10230606/u_10230606.jpg"
               },
               new Product
               {
                   Id = 4,
                   BrandId = 1,
                   UserId = 0,
                   CategoryId = 1,
                   ProductName = "IPhone 11",
                   ModelYear = DateTime.Now,
                   Price = 999,
                   CountInStock = 3,
                   Description = "string",
                   Color = "Pink",
                   Country = "Lithuania",
                   City = "Vilnius",
                   AddDate = DateTime.Now,
                   ExpireDate = DateTime.Now,
                   OtherBrand = "string",
                   ImageString = "https://brain-images-ssl.cdn.dixons.com/0/0/10230600/u_10230600.jpg"
               },
               new Product
               {
                   Id = 5,
                   BrandId = 1,
                   UserId = 0,
                   CategoryId = 1,
                   ProductName = "IPhone 11 Pro",
                   ModelYear = DateTime.Now,
                   Price = 1159,
                   CountInStock = 2,
                   Description = "string",
                   Color = "Pink",
                   Country = "Lithuania",
                   City = "Vilnius",
                   AddDate = DateTime.Now,
                   ExpireDate = DateTime.Now,
                   OtherBrand = "string",
                   ImageString = "https://brain-images-ssl.cdn.dixons.com/7/9/10230597/u_10230597.jpg"
               },
               new Product
               {
                   Id = 6,
                   BrandId = 1,
                   UserId = 0,
                   CategoryId = 1,
                   ProductName = "IPhone 12",
                   ModelYear = DateTime.Now,
                   Price = 930,
                   CountInStock = 2,
                   Description = "string",
                   Color = "Pink",
                   Country = "Lithuania",
                   City = "Vilnius",
                   AddDate = DateTime.Now,
                   ExpireDate = DateTime.Now,
                   OtherBrand = "string",
                   ImageString = "https://media.ao.com/en-GB/Productimages/Images/rvMedium/purple_apple_mobile_01_m_p.jpg"
               },
               new Product
               {
                   Id = 7,
                   BrandId = 1,
                   UserId = 0,
                   CategoryId = 1,
                   ProductName = "IPhone 10 Pro",
                   ModelYear = DateTime.Now,
                   Price = 800,
                   CountInStock = 2,
                   Description = "string",
                   Color = "Pink",
                   Country = "Lithuania",
                   City = "Vilnius",
                   AddDate = DateTime.Now,
                   ExpireDate = DateTime.Now,
                   OtherBrand = "string",
                   ImageString = "https://cdn.shopify.com/s/files/1/2700/1230/products/iPhone12_Purple_PDP_Image_2__WWEN_1024x1024.jpg?v=1619138796"
               },
               new Product
               {
                   Id = 8,
                   BrandId = 1,
                   UserId = 0,
                   CategoryId = 1,
                   ProductName = "IPhone 11",
                   ModelYear = DateTime.Now,
                   Price = 999,
                   CountInStock = 2,
                   Description = "string",
                   Color = "Pink",
                   Country = "Lithuania",
                   City = "Vilnius",
                   AddDate = DateTime.Now,
                   ExpireDate = DateTime.Now,
                   OtherBrand = "string",
                   ImageString = "https://m.xcite.com/media/catalog/product/cache/1/image/9df78eab33525d08d6e5fb8d27136e95/b/u/buy_apple_iphone_11_phone_-_purple_lowest_price_in_kuwait_4_1.jpg"
               },
               new Product
               {
                   Id = 9,
                   BrandId = 1,
                   UserId = 0,
                   CategoryId = 1,
                   ProductName = "IPhone 10 Pro",
                   ModelYear = DateTime.Now,
                   Price = 1130,
                   CountInStock = 2,
                   Description = "string",
                   Color = "Pink",
                   Country = "Lithuania",
                   City = "Vilnius",
                   AddDate = DateTime.Now,
                   ExpireDate = DateTime.Now,
                   OtherBrand = "string",
                   ImageString = "https://m.media-amazon.com/images/I/81mxun+6pEL._AC_SL1500_.jpg"
               },
               new Product
               {
                   Id = 10,
                   BrandId = 1,
                   UserId = 0,
                   CategoryId = 1,
                   ProductName = "IPhone 12",
                   ModelYear = DateTime.Now,
                   Price = 1299,
                   CountInStock = 2,
                   Description = "string",
                   Color = "Pink",
                   Country = "Lithuania",
                   City = "Vilnius",
                   AddDate = DateTime.Now,
                   ExpireDate = DateTime.Now,
                   OtherBrand = "string",
                   ImageString = "https://www.ideal.lt/media/catalog/product/cache/1/image/1920x/9df78eab33525d08d6e5fb8d27136e95/i/p/iphone12_green_3.png"
               },
               new Product
               {
                   Id = 11,
                   BrandId = 1,
                   UserId = 0,
                   CategoryId = 1,
                   ProductName = "IPhone 11",
                   ModelYear = DateTime.Now,
                   Price = 900,
                   CountInStock = 2,
                   Description = "string",
                   Color = "Pink",
                   Country = "Lithuania",
                   City = "Vilnius",
                   AddDate = DateTime.Now,
                   ExpireDate = DateTime.Now,
                   OtherBrand = "string",
                   ImageString = "https://kainos-img.dgn.lt/photos2_25_57208819/img.jpg"
               },
               new Product
               {
                   Id = 12,
                   BrandId = 1,
                   UserId = 0,
                   CategoryId = 1,
                   ProductName = "IPhone 11",
                   ModelYear = DateTime.Now,
                   Price = 915,
                   CountInStock = 2,
                   Description = "string",
                   Color = "Pink",
                   Country = "Lithuania",
                   City = "Vilnius",
                   AddDate = DateTime.Now,
                   ExpireDate = DateTime.Now,
                   OtherBrand = "string",
                   ImageString = "https://istore.lt/media/catalog/product/cache/1/small_image/504x/602f0fa2c1f0d1ba5e241f914e856ff9/a/p/apple-iphone-11-red-2.jpg"
               }
            );
        }
    }
}
