using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KickSharing.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class FixedScooter : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Prices",
                keyColumn: "Id",
                keyValue: "c6ec6546-e614-4296-bb66-a17564e022ba");

            migrationBuilder.DeleteData(
                table: "Scooters",
                keyColumn: "Id",
                keyValue: "041cec82-b5ce-4554-9563-b0e562c0971e");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "7ffba6e5-f413-40b6-8a2b-b8379174eeeb");

            migrationBuilder.AddColumn<string>(
                name: "Latitude",
                table: "Scooters",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Longitude",
                table: "Scooters",
                type: "TEXT",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Prices",
                columns: new[] { "Id", "CreatedDateTime", "MinutePrice" },
                values: new object[] { "7b8f98a9-e541-43ff-aadf-7c1f2f91e7ef", new DateTime(2024, 6, 16, 8, 15, 35, 936, DateTimeKind.Utc).AddTicks(7006), 5.0 });

            migrationBuilder.InsertData(
                table: "Scooters",
                columns: new[] { "Id", "ChargePercent", "CreatedDateTime", "Identifier", "IsBlocked", "Latitude", "Longitude" },
                values: new object[] { "4100811c-bfed-4fe6-b047-3f980df104ce", 100, new DateTime(2024, 6, 16, 8, 15, 35, 936, DateTimeKind.Utc).AddTicks(7299), "AA0001", false, null, null });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDateTime", "DateBirth", "Email", "IsBlocked", "IsEmailVerified", "IsPhoneVerified", "Name", "Phone", "Role" },
                values: new object[] { "aa4995d2-d1b4-4e3e-a8d2-51271a5ce49f", new DateTime(2024, 6, 16, 8, 15, 35, 936, DateTimeKind.Utc).AddTicks(7157), new DateTime(2003, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "dmitry_yalchik@mail.ru", false, true, true, "Admin", "78005553535", 2 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Prices",
                keyColumn: "Id",
                keyValue: "7b8f98a9-e541-43ff-aadf-7c1f2f91e7ef");

            migrationBuilder.DeleteData(
                table: "Scooters",
                keyColumn: "Id",
                keyValue: "4100811c-bfed-4fe6-b047-3f980df104ce");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "aa4995d2-d1b4-4e3e-a8d2-51271a5ce49f");

            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "Scooters");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "Scooters");

            migrationBuilder.InsertData(
                table: "Prices",
                columns: new[] { "Id", "CreatedDateTime", "MinutePrice" },
                values: new object[] { "c6ec6546-e614-4296-bb66-a17564e022ba", new DateTime(2024, 6, 11, 19, 53, 39, 923, DateTimeKind.Utc).AddTicks(5405), 5.0 });

            migrationBuilder.InsertData(
                table: "Scooters",
                columns: new[] { "Id", "ChargePercent", "CreatedDateTime", "Identifier", "IsBlocked" },
                values: new object[] { "041cec82-b5ce-4554-9563-b0e562c0971e", 100, new DateTime(2024, 6, 11, 19, 53, 39, 923, DateTimeKind.Utc).AddTicks(5713), "AA0001", false });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDateTime", "DateBirth", "Email", "IsBlocked", "IsEmailVerified", "IsPhoneVerified", "Name", "Phone", "Role" },
                values: new object[] { "7ffba6e5-f413-40b6-8a2b-b8379174eeeb", new DateTime(2024, 6, 11, 19, 53, 39, 923, DateTimeKind.Utc).AddTicks(5559), new DateTime(2003, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "dmitry_yalchik@mail.ru", false, true, true, "Admin", "78005553535", 2 });
        }
    }
}
