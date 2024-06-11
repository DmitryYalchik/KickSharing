using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KickSharing.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class FirstInitial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Prices",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    MinutePrice = table.Column<double>(type: "REAL", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Scooters",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Identifier = table.Column<string>(type: "TEXT", maxLength: 10, nullable: false),
                    ChargePercent = table.Column<int>(type: "INTEGER", nullable: false),
                    IsBlocked = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Scooters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    IsEmailVerified = table.Column<bool>(type: "INTEGER", nullable: true),
                    Phone = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    IsPhoneVerified = table.Column<bool>(type: "INTEGER", nullable: true),
                    Role = table.Column<int>(type: "INTEGER", nullable: false, defaultValue: 0),
                    DateBirth = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsBlocked = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rents",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    ScooterId = table.Column<string>(type: "TEXT", nullable: false),
                    PriceId = table.Column<string>(type: "TEXT", nullable: false),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    StartDateTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    StartLatitude = table.Column<string>(type: "TEXT", nullable: false),
                    StartLongitude = table.Column<string>(type: "TEXT", nullable: false),
                    FinishDateTime = table.Column<DateTime>(type: "TEXT", nullable: true),
                    FinishLatitude = table.Column<string>(type: "TEXT", nullable: true),
                    FinishLongitude = table.Column<string>(type: "TEXT", nullable: true),
                    CreatedDateTime = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rents_Prices_PriceId",
                        column: x => x.PriceId,
                        principalTable: "Prices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rents_Scooters_ScooterId",
                        column: x => x.ScooterId,
                        principalTable: "Scooters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rents_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Rents_PriceId",
                table: "Rents",
                column: "PriceId");

            migrationBuilder.CreateIndex(
                name: "IX_Rents_ScooterId",
                table: "Rents",
                column: "ScooterId");

            migrationBuilder.CreateIndex(
                name: "IX_Rents_UserId",
                table: "Rents",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Scooters_Identifier",
                table: "Scooters",
                column: "Identifier",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Phone",
                table: "Users",
                column: "Phone",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rents");

            migrationBuilder.DropTable(
                name: "Prices");

            migrationBuilder.DropTable(
                name: "Scooters");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
