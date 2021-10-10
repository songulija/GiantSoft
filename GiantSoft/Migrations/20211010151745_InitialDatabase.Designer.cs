﻿// <auto-generated />
using System;
using GiantSoft.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GiantSoft.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20211010151745_InitialDatabase")]
    partial class InitialDatabase
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GiantSoft.Data.ApiUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("GiantSoft.Data.Brand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BrandName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Brands");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BrandName = "Adidas"
                        },
                        new
                        {
                            Id = 2,
                            BrandName = "SKATEDELUXE"
                        },
                        new
                        {
                            Id = 3,
                            BrandName = "DC"
                        },
                        new
                        {
                            Id = 4,
                            BrandName = "Element"
                        },
                        new
                        {
                            Id = 5,
                            BrandName = "Baker"
                        },
                        new
                        {
                            Id = 6,
                            BrandName = "New balance"
                        });
                });

            modelBuilder.Entity("GiantSoft.Data.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ParentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Skateboards"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Shoes"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Accessories"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Longboards",
                            ParentId = 1
                        },
                        new
                        {
                            Id = 5,
                            Name = "Regular skateboards",
                            ParentId = 1
                        },
                        new
                        {
                            Id = 6,
                            Name = "Man",
                            ParentId = 2
                        },
                        new
                        {
                            Id = 7,
                            Name = "Women",
                            ParentId = 2
                        },
                        new
                        {
                            Id = 8,
                            Name = "Skate shoes",
                            ParentId = 6
                        },
                        new
                        {
                            Id = 9,
                            Name = "Sneakers",
                            ParentId = 6
                        },
                        new
                        {
                            Id = 10,
                            Name = "Skate shoes",
                            ParentId = 7
                        },
                        new
                        {
                            Id = 11,
                            Name = "Sneakers",
                            ParentId = 7
                        });
                });

            modelBuilder.Entity("GiantSoft.Data.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<float>("Rating")
                        .HasColumnType("real");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("GiantSoft.Data.Feedback", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ApiUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("FeedbackText")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Rating")
                        .HasColumnType("float");

                    b.Property<int>("ReceiverId")
                        .HasColumnType("int");

                    b.Property<int>("SenderId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ApiUserId");

                    b.ToTable("Feedbacks");
                });

            modelBuilder.Entity("GiantSoft.Data.Journal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ApiUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ApiUserId");

                    b.HasIndex("ProductId");

                    b.ToTable("Journals");
                });

            modelBuilder.Entity("GiantSoft.Data.Payment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("EmailAdress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PaymentMethod")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UpdateTime")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("GiantSoft.Data.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("AddDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ApiUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("BrandId")
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Color")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CountInStock")
                        .HasColumnType("int");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ExpireDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ImageString")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ModelYear")
                        .HasColumnType("datetime2");

                    b.Property<string>("OtherBrand")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<string>("ProductName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ApiUserId");

                    b.HasIndex("BrandId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AddDate = new DateTime(2021, 10, 10, 18, 17, 45, 178, DateTimeKind.Local).AddTicks(9613),
                            BrandId = 1,
                            CategoryId = 1,
                            City = "Vilnius",
                            Color = "Pink",
                            CountInStock = 2,
                            Country = "Lithuania",
                            Description = "string",
                            ExpireDate = new DateTime(2021, 10, 10, 18, 17, 45, 178, DateTimeKind.Local).AddTicks(9929),
                            ImageString = "https://store.storeimages.cdn-apple.com/4668/as-images.apple.com/is/iphone-13-family-select-2021?wid=940&hei=1112&fmt=jpeg&qlt=80&.v=1629842667000",
                            ModelYear = new DateTime(2021, 10, 10, 18, 17, 45, 175, DateTimeKind.Local).AddTicks(6577),
                            OtherBrand = "string",
                            Price = 899.0,
                            ProductName = "IPhone 11",
                            UserId = 0
                        },
                        new
                        {
                            Id = 2,
                            AddDate = new DateTime(2021, 10, 10, 18, 17, 45, 179, DateTimeKind.Local).AddTicks(705),
                            BrandId = 1,
                            CategoryId = 1,
                            City = "Vilnius",
                            Color = "Pink",
                            CountInStock = 2,
                            Country = "Lithuania",
                            Description = "string",
                            ExpireDate = new DateTime(2021, 10, 10, 18, 17, 45, 179, DateTimeKind.Local).AddTicks(708),
                            ImageString = "https://brain-images-ssl.cdn.dixons.com/4/8/10230584/u_10230584.jpg",
                            ModelYear = new DateTime(2021, 10, 10, 18, 17, 45, 179, DateTimeKind.Local).AddTicks(693),
                            OtherBrand = "string",
                            Price = 1199.0,
                            ProductName = "IPhone 11",
                            UserId = 0
                        },
                        new
                        {
                            Id = 3,
                            AddDate = new DateTime(2021, 10, 10, 18, 17, 45, 179, DateTimeKind.Local).AddTicks(717),
                            BrandId = 1,
                            CategoryId = 1,
                            City = "Vilnius",
                            Color = "Pink",
                            CountInStock = 4,
                            Country = "Lithuania",
                            Description = "string",
                            ExpireDate = new DateTime(2021, 10, 10, 18, 17, 45, 179, DateTimeKind.Local).AddTicks(719),
                            ImageString = "https://brain-images-ssl.cdn.dixons.com/6/0/10230606/u_10230606.jpg",
                            ModelYear = new DateTime(2021, 10, 10, 18, 17, 45, 179, DateTimeKind.Local).AddTicks(713),
                            OtherBrand = "string",
                            Price = 1099.0,
                            ProductName = "IPhone 10 Pro",
                            UserId = 0
                        },
                        new
                        {
                            Id = 4,
                            AddDate = new DateTime(2021, 10, 10, 18, 17, 45, 179, DateTimeKind.Local).AddTicks(725),
                            BrandId = 1,
                            CategoryId = 1,
                            City = "Vilnius",
                            Color = "Pink",
                            CountInStock = 3,
                            Country = "Lithuania",
                            Description = "string",
                            ExpireDate = new DateTime(2021, 10, 10, 18, 17, 45, 179, DateTimeKind.Local).AddTicks(728),
                            ImageString = "https://brain-images-ssl.cdn.dixons.com/0/0/10230600/u_10230600.jpg",
                            ModelYear = new DateTime(2021, 10, 10, 18, 17, 45, 179, DateTimeKind.Local).AddTicks(723),
                            OtherBrand = "string",
                            Price = 999.0,
                            ProductName = "IPhone 11",
                            UserId = 0
                        },
                        new
                        {
                            Id = 5,
                            AddDate = new DateTime(2021, 10, 10, 18, 17, 45, 179, DateTimeKind.Local).AddTicks(734),
                            BrandId = 1,
                            CategoryId = 1,
                            City = "Vilnius",
                            Color = "Pink",
                            CountInStock = 2,
                            Country = "Lithuania",
                            Description = "string",
                            ExpireDate = new DateTime(2021, 10, 10, 18, 17, 45, 179, DateTimeKind.Local).AddTicks(736),
                            ImageString = "https://brain-images-ssl.cdn.dixons.com/7/9/10230597/u_10230597.jpg",
                            ModelYear = new DateTime(2021, 10, 10, 18, 17, 45, 179, DateTimeKind.Local).AddTicks(731),
                            OtherBrand = "string",
                            Price = 1159.0,
                            ProductName = "IPhone 11 Pro",
                            UserId = 0
                        },
                        new
                        {
                            Id = 6,
                            AddDate = new DateTime(2021, 10, 10, 18, 17, 45, 179, DateTimeKind.Local).AddTicks(743),
                            BrandId = 1,
                            CategoryId = 1,
                            City = "Vilnius",
                            Color = "Pink",
                            CountInStock = 2,
                            Country = "Lithuania",
                            Description = "string",
                            ExpireDate = new DateTime(2021, 10, 10, 18, 17, 45, 179, DateTimeKind.Local).AddTicks(746),
                            ImageString = "https://media.ao.com/en-GB/Productimages/Images/rvMedium/purple_apple_mobile_01_m_p.jpg",
                            ModelYear = new DateTime(2021, 10, 10, 18, 17, 45, 179, DateTimeKind.Local).AddTicks(740),
                            OtherBrand = "string",
                            Price = 930.0,
                            ProductName = "IPhone 12",
                            UserId = 0
                        },
                        new
                        {
                            Id = 7,
                            AddDate = new DateTime(2021, 10, 10, 18, 17, 45, 179, DateTimeKind.Local).AddTicks(752),
                            BrandId = 1,
                            CategoryId = 1,
                            City = "Vilnius",
                            Color = "Pink",
                            CountInStock = 2,
                            Country = "Lithuania",
                            Description = "string",
                            ExpireDate = new DateTime(2021, 10, 10, 18, 17, 45, 179, DateTimeKind.Local).AddTicks(754),
                            ImageString = "https://cdn.shopify.com/s/files/1/2700/1230/products/iPhone12_Purple_PDP_Image_2__WWEN_1024x1024.jpg?v=1619138796",
                            ModelYear = new DateTime(2021, 10, 10, 18, 17, 45, 179, DateTimeKind.Local).AddTicks(749),
                            OtherBrand = "string",
                            Price = 800.0,
                            ProductName = "IPhone 10 Pro",
                            UserId = 0
                        },
                        new
                        {
                            Id = 8,
                            AddDate = new DateTime(2021, 10, 10, 18, 17, 45, 179, DateTimeKind.Local).AddTicks(761),
                            BrandId = 1,
                            CategoryId = 1,
                            City = "Vilnius",
                            Color = "Pink",
                            CountInStock = 2,
                            Country = "Lithuania",
                            Description = "string",
                            ExpireDate = new DateTime(2021, 10, 10, 18, 17, 45, 179, DateTimeKind.Local).AddTicks(763),
                            ImageString = "https://m.xcite.com/media/catalog/product/cache/1/image/9df78eab33525d08d6e5fb8d27136e95/b/u/buy_apple_iphone_11_phone_-_purple_lowest_price_in_kuwait_4_1.jpg",
                            ModelYear = new DateTime(2021, 10, 10, 18, 17, 45, 179, DateTimeKind.Local).AddTicks(758),
                            OtherBrand = "string",
                            Price = 999.0,
                            ProductName = "IPhone 11",
                            UserId = 0
                        },
                        new
                        {
                            Id = 9,
                            AddDate = new DateTime(2021, 10, 10, 18, 17, 45, 179, DateTimeKind.Local).AddTicks(769),
                            BrandId = 1,
                            CategoryId = 1,
                            City = "Vilnius",
                            Color = "Pink",
                            CountInStock = 2,
                            Country = "Lithuania",
                            Description = "string",
                            ExpireDate = new DateTime(2021, 10, 10, 18, 17, 45, 179, DateTimeKind.Local).AddTicks(771),
                            ImageString = "https://m.media-amazon.com/images/I/81mxun+6pEL._AC_SL1500_.jpg",
                            ModelYear = new DateTime(2021, 10, 10, 18, 17, 45, 179, DateTimeKind.Local).AddTicks(766),
                            OtherBrand = "string",
                            Price = 1130.0,
                            ProductName = "IPhone 10 Pro",
                            UserId = 0
                        },
                        new
                        {
                            Id = 10,
                            AddDate = new DateTime(2021, 10, 10, 18, 17, 45, 179, DateTimeKind.Local).AddTicks(777),
                            BrandId = 1,
                            CategoryId = 1,
                            City = "Vilnius",
                            Color = "Pink",
                            CountInStock = 2,
                            Country = "Lithuania",
                            Description = "string",
                            ExpireDate = new DateTime(2021, 10, 10, 18, 17, 45, 179, DateTimeKind.Local).AddTicks(780),
                            ImageString = "https://www.ideal.lt/media/catalog/product/cache/1/image/1920x/9df78eab33525d08d6e5fb8d27136e95/i/p/iphone12_green_3.png",
                            ModelYear = new DateTime(2021, 10, 10, 18, 17, 45, 179, DateTimeKind.Local).AddTicks(775),
                            OtherBrand = "string",
                            Price = 1299.0,
                            ProductName = "IPhone 12",
                            UserId = 0
                        },
                        new
                        {
                            Id = 11,
                            AddDate = new DateTime(2021, 10, 10, 18, 17, 45, 179, DateTimeKind.Local).AddTicks(786),
                            BrandId = 1,
                            CategoryId = 1,
                            City = "Vilnius",
                            Color = "Pink",
                            CountInStock = 2,
                            Country = "Lithuania",
                            Description = "string",
                            ExpireDate = new DateTime(2021, 10, 10, 18, 17, 45, 179, DateTimeKind.Local).AddTicks(788),
                            ImageString = "https://kainos-img.dgn.lt/photos2_25_57208819/img.jpg",
                            ModelYear = new DateTime(2021, 10, 10, 18, 17, 45, 179, DateTimeKind.Local).AddTicks(783),
                            OtherBrand = "string",
                            Price = 900.0,
                            ProductName = "IPhone 11",
                            UserId = 0
                        },
                        new
                        {
                            Id = 12,
                            AddDate = new DateTime(2021, 10, 10, 18, 17, 45, 179, DateTimeKind.Local).AddTicks(795),
                            BrandId = 1,
                            CategoryId = 1,
                            City = "Vilnius",
                            Color = "Pink",
                            CountInStock = 2,
                            Country = "Lithuania",
                            Description = "string",
                            ExpireDate = new DateTime(2021, 10, 10, 18, 17, 45, 179, DateTimeKind.Local).AddTicks(797),
                            ImageString = "https://istore.lt/media/catalog/product/cache/1/small_image/504x/602f0fa2c1f0d1ba5e241f914e856ff9/a/p/apple-iphone-11-red-2.jpg",
                            ModelYear = new DateTime(2021, 10, 10, 18, 17, 45, 179, DateTimeKind.Local).AddTicks(792),
                            OtherBrand = "string",
                            Price = 915.0,
                            ProductName = "IPhone 11",
                            UserId = 0
                        });
                });

            modelBuilder.Entity("GiantSoft.Data.Whishlist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ApiUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ApiUserId");

                    b.HasIndex("ProductId");

                    b.ToTable("Whishlists");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");

                    b.HasData(
                        new
                        {
                            Id = "14d42e66-82c0-4931-a272-2b29f3fb2e62",
                            ConcurrencyStamp = "22eb779b-3742-4d33-9691-887945f6c31e",
                            Name = "User",
                            NormalizedName = "USER"
                        },
                        new
                        {
                            Id = "99ca24c0-40f9-48ff-9cf8-92cc8629008e",
                            ConcurrencyStamp = "dfe1a002-7236-4a56-a044-15041c6fe3a8",
                            Name = "Administrator",
                            NormalizedName = "ADMINISTRATOR"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("GiantSoft.Data.Feedback", b =>
                {
                    b.HasOne("GiantSoft.Data.ApiUser", null)
                        .WithMany("Feedbacks")
                        .HasForeignKey("ApiUserId");
                });

            modelBuilder.Entity("GiantSoft.Data.Journal", b =>
                {
                    b.HasOne("GiantSoft.Data.ApiUser", null)
                        .WithMany("Journals")
                        .HasForeignKey("ApiUserId");

                    b.HasOne("GiantSoft.Data.Product", null)
                        .WithMany("Journals")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GiantSoft.Data.Payment", b =>
                {
                    b.HasOne("GiantSoft.Data.Product", null)
                        .WithMany("Payments")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GiantSoft.Data.Product", b =>
                {
                    b.HasOne("GiantSoft.Data.ApiUser", null)
                        .WithMany("Products")
                        .HasForeignKey("ApiUserId");

                    b.HasOne("GiantSoft.Data.Brand", null)
                        .WithMany("Products")
                        .HasForeignKey("BrandId");

                    b.HasOne("GiantSoft.Data.Category", null)
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GiantSoft.Data.Whishlist", b =>
                {
                    b.HasOne("GiantSoft.Data.ApiUser", null)
                        .WithMany("Whishlists")
                        .HasForeignKey("ApiUserId");

                    b.HasOne("GiantSoft.Data.Product", null)
                        .WithMany("Whishlists")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("GiantSoft.Data.ApiUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("GiantSoft.Data.ApiUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GiantSoft.Data.ApiUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("GiantSoft.Data.ApiUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GiantSoft.Data.ApiUser", b =>
                {
                    b.Navigation("Feedbacks");

                    b.Navigation("Journals");

                    b.Navigation("Products");

                    b.Navigation("Whishlists");
                });

            modelBuilder.Entity("GiantSoft.Data.Brand", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("GiantSoft.Data.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("GiantSoft.Data.Product", b =>
                {
                    b.Navigation("Journals");

                    b.Navigation("Payments");

                    b.Navigation("Whishlists");
                });
#pragma warning restore 612, 618
        }
    }
}