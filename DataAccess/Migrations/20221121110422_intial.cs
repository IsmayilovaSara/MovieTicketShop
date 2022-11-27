using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class intial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    ImgPath = table.Column<string>(type: "text", nullable: false),
                    IMDbRating = table.Column<double>(type: "double precision", nullable: false),
                    Price = table.Column<double>(type: "double precision", nullable: false),
                    Note = table.Column<string>(type: "text", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreateUserId = table.Column<int>(type: "integer", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdateUserId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreateUserId = table.Column<int>(type: "integer", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdateUserId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Username = table.Column<string>(type: "text", nullable: false),
                    Salt = table.Column<string>(type: "text", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: false),
                    RoleId = table.Column<int>(type: "integer", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreateUserId = table.Column<int>(type: "integer", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdateUserId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProductId = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    Count = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Carts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Carts_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CreateDate", "CreateUserId", "IMDbRating", "ImgPath", "Name", "Note", "Price", "UpdateDate", "UpdateUserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 11, 21, 15, 4, 22, 153, DateTimeKind.Local).AddTicks(9788), 1, 7.2999999999999998, "~/image/AntMan.jpg", "Ant-Man", "Description", 7.5, null, null },
                    { 2, new DateTime(2022, 11, 21, 15, 4, 22, 153, DateTimeKind.Local).AddTicks(9801), 1, 7.2000000000000002, "~/image/Don'tLookUp.jpg", "Don't Look Up", "Description", 8.0, null, null },
                    { 3, new DateTime(2022, 11, 21, 15, 4, 22, 153, DateTimeKind.Local).AddTicks(9810), 1, 7.7999999999999998, "~/image/Dunkirk.jpg", "Dunkirk", "Description", 10.0, null, null },
                    { 4, new DateTime(2022, 11, 21, 15, 4, 22, 153, DateTimeKind.Local).AddTicks(9819), 1, 6.5999999999999996, "~/image/EnolaHolmes.jpg", "Enola Holmes", "Description", 6.0, null, null },
                    { 5, new DateTime(2022, 11, 21, 15, 4, 22, 153, DateTimeKind.Local).AddTicks(9828), 1, 6.5, "~/image/FlatLiners.jpg", "Flatliners", "Description", 6.0, null, null },
                    { 6, new DateTime(2022, 11, 21, 15, 4, 22, 153, DateTimeKind.Local).AddTicks(9841), 1, 8.5999999999999996, "~/image/Interstellar.jpg", "Interstellar", "Description", 10.0, null, null },
                    { 7, new DateTime(2022, 11, 21, 15, 4, 22, 153, DateTimeKind.Local).AddTicks(9850), 1, 8.4000000000000004, "~/image/Joker.jpg", "Joker", "Description", 5.0, null, null },
                    { 8, new DateTime(2022, 11, 21, 15, 4, 22, 153, DateTimeKind.Local).AddTicks(9859), 1, 8.0, "~/image/TheIncredibles.jpg", "The Incredibles", "Description", 4.5, null, null },
                    { 9, new DateTime(2022, 11, 21, 15, 4, 22, 153, DateTimeKind.Local).AddTicks(9868), 1, 7.0, "~/image/ThePlatform.jpg", "The Platform", "Description", 8.5, null, null },
                    { 10, new DateTime(2022, 11, 21, 15, 4, 22, 153, DateTimeKind.Local).AddTicks(9877), 1, 6.5, "~/image/ThorLoveandThunder.jpg", "Thor: Love and Thunder", "Description", 6.0, null, null }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreateDate", "CreateUserId", "Name", "UpdateDate", "UpdateUserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 11, 21, 15, 4, 22, 153, DateTimeKind.Local).AddTicks(8404), 1, "Admin", null, null },
                    { 2, new DateTime(2022, 11, 21, 15, 4, 22, 153, DateTimeKind.Local).AddTicks(8489), 1, "User", null, null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreateDate", "CreateUserId", "PasswordHash", "RoleId", "Salt", "UpdateDate", "UpdateUserId", "Username" },
                values: new object[] { 1, new DateTime(2022, 11, 21, 15, 4, 22, 153, DateTimeKind.Local).AddTicks(9734), 1, "2����		�:��/�5oX���<f�E��7,��", 1, "YYif+HvdHfgp5g==", null, null, "admin" });

            migrationBuilder.CreateIndex(
                name: "IX_Carts_ProductId",
                table: "Carts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_UserId",
                table: "Carts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
