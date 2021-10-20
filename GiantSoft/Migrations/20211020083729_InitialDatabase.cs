using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GiantSoft.Migrations
{
    public partial class InitialDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrandName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Feedbacks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReceiverId = table.Column<int>(type: "int", nullable: false),
                    SenderId = table.Column<int>(type: "int", nullable: false),
                    FeedbackText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rating = table.Column<double>(type: "float", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ApiUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedbacks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Feedbacks_AspNetUsers_ApiUserId",
                        column: x => x.ApiUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    BrandId = table.Column<int>(type: "int", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModelYear = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    CountInStock = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpireDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OtherBrand = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageString = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApiUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_AspNetUsers_ApiUserId",
                        column: x => x.ApiUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Rating = table.Column<float>(type: "real", nullable: false),
                    ApiUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_AspNetUsers_ApiUserId",
                        column: x => x.ApiUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comments_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Journals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApiUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Journals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Journals_AspNetUsers_ApiUserId",
                        column: x => x.ApiUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Journals_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    PaymentMethod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailAdress = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payments_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Whishlists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ApiUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Whishlists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Whishlists_AspNetUsers_ApiUserId",
                        column: x => x.ApiUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Whishlists_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "c8e33f6f-d30b-416f-9062-213d2e992d9b", "03e45956-c964-4d9d-be85-2ef26835b95f", "Administrator", "ADMINISTRATOR" },
                    { "a2adfb48-81bb-4db1-a378-b45cce904391", "3b2759ab-c6a9-4654-9d79-347b37a4ecef", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "BrandName" },
                values: new object[,]
                {
                    { 6, "New balance" },
                    { 5, "Baker" },
                    { 1, "Adidas" },
                    { 3, "DC" },
                    { 2, "SKATEDELUXE" },
                    { 4, "Element" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "ParentId" },
                values: new object[,]
                {
                    { 1, "Skateboards", null },
                    { 2, "Shoes", null },
                    { 3, "Accessories", null },
                    { 5, "Regular skateboards", 1 },
                    { 6, "Man", 2 },
                    { 7, "Women", 2 },
                    { 8, "Skate shoes", 6 },
                    { 9, "Sneakers", 6 },
                    { 10, "Skate shoes", 7 },
                    { 11, "Sneakers", 7 },
                    { 4, "Longboards", 1 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "AddDate", "ApiUserId", "BrandId", "CategoryId", "City", "Color", "CountInStock", "Country", "Description", "ExpireDate", "ImageString", "ModelYear", "OtherBrand", "Price", "ProductName", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 10, 20, 11, 37, 29, 443, DateTimeKind.Local).AddTicks(572), null, 1, 1, "Vilnius", "Pink", 2, "Lithuania", "string", new DateTime(2021, 10, 20, 11, 37, 29, 443, DateTimeKind.Local).AddTicks(898), "https://store.storeimages.cdn-apple.com/4668/as-images.apple.com/is/iphone-13-family-select-2021?wid=940&hei=1112&fmt=jpeg&qlt=80&.v=1629842667000", new DateTime(2021, 10, 20, 11, 37, 29, 440, DateTimeKind.Local).AddTicks(3129), "string", 899.0, "IPhone 11", 0 },
                    { 2, new DateTime(2021, 10, 20, 11, 37, 29, 443, DateTimeKind.Local).AddTicks(1668), null, 1, 1, "Vilnius", "Pink", 2, "Lithuania", "string", new DateTime(2021, 10, 20, 11, 37, 29, 443, DateTimeKind.Local).AddTicks(1671), "https://brain-images-ssl.cdn.dixons.com/4/8/10230584/u_10230584.jpg", new DateTime(2021, 10, 20, 11, 37, 29, 443, DateTimeKind.Local).AddTicks(1655), "string", 1199.0, "IPhone 11", 0 },
                    { 3, new DateTime(2021, 10, 20, 11, 37, 29, 443, DateTimeKind.Local).AddTicks(1679), null, 1, 1, "Vilnius", "Pink", 4, "Lithuania", "string", new DateTime(2021, 10, 20, 11, 37, 29, 443, DateTimeKind.Local).AddTicks(1682), "https://brain-images-ssl.cdn.dixons.com/6/0/10230606/u_10230606.jpg", new DateTime(2021, 10, 20, 11, 37, 29, 443, DateTimeKind.Local).AddTicks(1676), "string", 1099.0, "IPhone 10 Pro", 0 },
                    { 4, new DateTime(2021, 10, 20, 11, 37, 29, 443, DateTimeKind.Local).AddTicks(1688), null, 1, 1, "Vilnius", "Pink", 3, "Lithuania", "string", new DateTime(2021, 10, 20, 11, 37, 29, 443, DateTimeKind.Local).AddTicks(1691), "https://brain-images-ssl.cdn.dixons.com/0/0/10230600/u_10230600.jpg", new DateTime(2021, 10, 20, 11, 37, 29, 443, DateTimeKind.Local).AddTicks(1685), "string", 999.0, "IPhone 11", 0 },
                    { 5, new DateTime(2021, 10, 20, 11, 37, 29, 443, DateTimeKind.Local).AddTicks(1697), null, 1, 1, "Vilnius", "Pink", 2, "Lithuania", "string", new DateTime(2021, 10, 20, 11, 37, 29, 443, DateTimeKind.Local).AddTicks(1700), "https://brain-images-ssl.cdn.dixons.com/7/9/10230597/u_10230597.jpg", new DateTime(2021, 10, 20, 11, 37, 29, 443, DateTimeKind.Local).AddTicks(1695), "string", 1159.0, "IPhone 11 Pro", 0 },
                    { 6, new DateTime(2021, 10, 20, 11, 37, 29, 443, DateTimeKind.Local).AddTicks(1775), null, 1, 1, "Vilnius", "Pink", 2, "Lithuania", "string", new DateTime(2021, 10, 20, 11, 37, 29, 443, DateTimeKind.Local).AddTicks(1777), "https://media.ao.com/en-GB/Productimages/Images/rvMedium/purple_apple_mobile_01_m_p.jpg", new DateTime(2021, 10, 20, 11, 37, 29, 443, DateTimeKind.Local).AddTicks(1771), "string", 930.0, "IPhone 12", 0 },
                    { 7, new DateTime(2021, 10, 20, 11, 37, 29, 443, DateTimeKind.Local).AddTicks(1784), null, 1, 1, "Vilnius", "Pink", 2, "Lithuania", "string", new DateTime(2021, 10, 20, 11, 37, 29, 443, DateTimeKind.Local).AddTicks(1786), "https://cdn.shopify.com/s/files/1/2700/1230/products/iPhone12_Purple_PDP_Image_2__WWEN_1024x1024.jpg?v=1619138796", new DateTime(2021, 10, 20, 11, 37, 29, 443, DateTimeKind.Local).AddTicks(1781), "string", 800.0, "IPhone 10 Pro", 0 },
                    { 8, new DateTime(2021, 10, 20, 11, 37, 29, 443, DateTimeKind.Local).AddTicks(1792), null, 1, 1, "Vilnius", "Pink", 2, "Lithuania", "string", new DateTime(2021, 10, 20, 11, 37, 29, 443, DateTimeKind.Local).AddTicks(1794), "https://m.xcite.com/media/catalog/product/cache/1/image/9df78eab33525d08d6e5fb8d27136e95/b/u/buy_apple_iphone_11_phone_-_purple_lowest_price_in_kuwait_4_1.jpg", new DateTime(2021, 10, 20, 11, 37, 29, 443, DateTimeKind.Local).AddTicks(1789), "string", 999.0, "IPhone 11", 0 },
                    { 9, new DateTime(2021, 10, 20, 11, 37, 29, 443, DateTimeKind.Local).AddTicks(1800), null, 1, 1, "Vilnius", "Pink", 2, "Lithuania", "string", new DateTime(2021, 10, 20, 11, 37, 29, 443, DateTimeKind.Local).AddTicks(1802), "https://m.media-amazon.com/images/I/81mxun+6pEL._AC_SL1500_.jpg", new DateTime(2021, 10, 20, 11, 37, 29, 443, DateTimeKind.Local).AddTicks(1797), "string", 1130.0, "IPhone 10 Pro", 0 },
                    { 10, new DateTime(2021, 10, 20, 11, 37, 29, 443, DateTimeKind.Local).AddTicks(1808), null, 1, 1, "Vilnius", "Pink", 2, "Lithuania", "string", new DateTime(2021, 10, 20, 11, 37, 29, 443, DateTimeKind.Local).AddTicks(1810), "https://www.ideal.lt/media/catalog/product/cache/1/image/1920x/9df78eab33525d08d6e5fb8d27136e95/i/p/iphone12_green_3.png", new DateTime(2021, 10, 20, 11, 37, 29, 443, DateTimeKind.Local).AddTicks(1805), "string", 1299.0, "IPhone 12", 0 },
                    { 11, new DateTime(2021, 10, 20, 11, 37, 29, 443, DateTimeKind.Local).AddTicks(1816), null, 1, 1, "Vilnius", "Pink", 2, "Lithuania", "string", new DateTime(2021, 10, 20, 11, 37, 29, 443, DateTimeKind.Local).AddTicks(1818), "https://kainos-img.dgn.lt/photos2_25_57208819/img.jpg", new DateTime(2021, 10, 20, 11, 37, 29, 443, DateTimeKind.Local).AddTicks(1813), "string", 900.0, "IPhone 11", 0 },
                    { 12, new DateTime(2021, 10, 20, 11, 37, 29, 443, DateTimeKind.Local).AddTicks(1824), null, 1, 1, "Vilnius", "Pink", 2, "Lithuania", "string", new DateTime(2021, 10, 20, 11, 37, 29, 443, DateTimeKind.Local).AddTicks(1826), "https://istore.lt/media/catalog/product/cache/1/small_image/504x/602f0fa2c1f0d1ba5e241f914e856ff9/a/p/apple-iphone-11-red-2.jpg", new DateTime(2021, 10, 20, 11, 37, 29, 443, DateTimeKind.Local).AddTicks(1821), "string", 915.0, "IPhone 11", 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ApiUserId",
                table: "Comments",
                column: "ApiUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ProductId",
                table: "Comments",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_ApiUserId",
                table: "Feedbacks",
                column: "ApiUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Journals_ApiUserId",
                table: "Journals",
                column: "ApiUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Journals_ProductId",
                table: "Journals",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_ProductId",
                table: "Payments",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ApiUserId",
                table: "Products",
                column: "ApiUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_BrandId",
                table: "Products",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Whishlists_ApiUserId",
                table: "Whishlists",
                column: "ApiUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Whishlists_ProductId",
                table: "Whishlists",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Feedbacks");

            migrationBuilder.DropTable(
                name: "Journals");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "Whishlists");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
