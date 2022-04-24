using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.EF.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
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
                values: new object[] { new Guid("04695079-2d60-4c94-a15a-12ad10fb08ec"), 0, new DateTimeOffset(new DateTime(2022, 4, 24, 21, 46, 35, 605, DateTimeKind.Unspecified).AddTicks(5255), new TimeSpan(0, 2, 0, 0, 0)), null, new DateTimeOffset(new DateTime(2022, 4, 26, 21, 46, 35, 605, DateTimeKind.Unspecified).AddTicks(5252), new TimeSpan(0, 2, 0, 0, 0)), "Natankowac samochod" });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "CompleteStatus", "CreatedDate", "Description", "ExpirationDate", "Title" },
                values: new object[] { new Guid("26b233e9-cbd9-4e0f-ad75-7993e5d7399b"), 0, new DateTimeOffset(new DateTime(2022, 4, 24, 21, 46, 35, 605, DateTimeKind.Unspecified).AddTicks(5222), new TimeSpan(0, 2, 0, 0, 0)), "Zrobic zakupy w sklepie, koszt bulek 0.40gr", new DateTimeOffset(new DateTime(2022, 4, 25, 21, 46, 35, 605, DateTimeKind.Unspecified).AddTicks(5175), new TimeSpan(0, 2, 0, 0, 0)), "Kupic bulki" });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "CompleteStatus", "CreatedDate", "Description", "ExpirationDate", "Title" },
                values: new object[] { new Guid("aeec3b85-7623-4c63-b0fc-f5efcb25567c"), 0, new DateTimeOffset(new DateTime(2022, 4, 24, 21, 46, 35, 605, DateTimeKind.Unspecified).AddTicks(5260), new TimeSpan(0, 2, 0, 0, 0)), null, new DateTimeOffset(new DateTime(2022, 5, 2, 21, 46, 35, 605, DateTimeKind.Unspecified).AddTicks(5258), new TimeSpan(0, 2, 0, 0, 0)), "Napic sie kawy" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tasks");
        }
    }
}
