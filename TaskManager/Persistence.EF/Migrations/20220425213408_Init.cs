using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.EF.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    ExpirationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompleteStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "CompleteStatus", "CreatedDate", "Description", "ExpirationDate", "Title" },
                values: new object[] { new Guid("e74dc990-5488-4b39-aecc-28c1eecb011f"), 0, new DateTimeOffset(new DateTime(2022, 4, 25, 23, 34, 8, 30, DateTimeKind.Unspecified).AddTicks(1904), new TimeSpan(0, 2, 0, 0, 0)), null, new DateTimeOffset(new DateTime(2022, 5, 3, 23, 34, 8, 30, DateTimeKind.Unspecified).AddTicks(1901), new TimeSpan(0, 2, 0, 0, 0)), "Napic sie kawy" });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "CompleteStatus", "CreatedDate", "Description", "ExpirationDate", "Title" },
                values: new object[] { new Guid("ed4bf9d1-a7c4-4f89-8d0d-4fac1bf8f294"), 0, new DateTimeOffset(new DateTime(2022, 4, 25, 23, 34, 8, 30, DateTimeKind.Unspecified).AddTicks(1859), new TimeSpan(0, 2, 0, 0, 0)), "Zrobic zakupy w sklepie, koszt bulek 0.40gr", new DateTimeOffset(new DateTime(2022, 4, 26, 23, 34, 8, 30, DateTimeKind.Unspecified).AddTicks(1811), new TimeSpan(0, 2, 0, 0, 0)), "Kupic bulki" });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "CompleteStatus", "CreatedDate", "Description", "ExpirationDate", "Title" },
                values: new object[] { new Guid("ef20f70e-4b78-45eb-9404-de3da9ff16dc"), 0, new DateTimeOffset(new DateTime(2022, 4, 25, 23, 34, 8, 30, DateTimeKind.Unspecified).AddTicks(1898), new TimeSpan(0, 2, 0, 0, 0)), null, new DateTimeOffset(new DateTime(2022, 4, 27, 23, 34, 8, 30, DateTimeKind.Unspecified).AddTicks(1895), new TimeSpan(0, 2, 0, 0, 0)), "Natankowac samochod" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tasks");
        }
    }
}
