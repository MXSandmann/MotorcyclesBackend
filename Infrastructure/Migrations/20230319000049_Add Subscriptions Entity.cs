using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddSubscriptionsEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Motorcycles",
                keyColumn: "Id",
                keyValue: new Guid("4f81dc65-1a56-44bb-90c2-0468c90c308d"));

            migrationBuilder.DeleteData(
                table: "Motorcycles",
                keyColumn: "Id",
                keyValue: new Guid("e662b658-404b-4078-afff-523fc6889253"));

            migrationBuilder.DeleteData(
                table: "Motorcycles",
                keyColumn: "Id",
                keyValue: new Guid("f6ca9445-898d-405b-be7d-97ed33aac317"));

            migrationBuilder.CreateTable(
                name: "Subscriptions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserName = table.Column<string>(type: "text", nullable: false),
                    UserEmail = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscriptions", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Motorcycles",
                columns: new[] { "Id", "Company", "EnginePower", "ModelName", "ModelType", "Price" },
                values: new object[,]
                {
                    { new Guid("6fb6397b-6dd9-499d-ac10-15f616663cfa"), "Kawasaki", 7, "KLX110R", "Motocross", 3195.0 },
                    { new Guid("aa29ae7e-0515-48c5-82db-aa1a1422798b"), "BMW", 136, "R 1250 RS", "Sport", 20000.0 },
                    { new Guid("f9de0146-4a48-4d18-80d9-99d95ec451ff"), "Triumph", 70, "Bonnevile T100", "Naked", 14000.0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Subscriptions");

            migrationBuilder.DeleteData(
                table: "Motorcycles",
                keyColumn: "Id",
                keyValue: new Guid("6fb6397b-6dd9-499d-ac10-15f616663cfa"));

            migrationBuilder.DeleteData(
                table: "Motorcycles",
                keyColumn: "Id",
                keyValue: new Guid("aa29ae7e-0515-48c5-82db-aa1a1422798b"));

            migrationBuilder.DeleteData(
                table: "Motorcycles",
                keyColumn: "Id",
                keyValue: new Guid("f9de0146-4a48-4d18-80d9-99d95ec451ff"));

            migrationBuilder.InsertData(
                table: "Motorcycles",
                columns: new[] { "Id", "Company", "EnginePower", "ModelName", "ModelType", "Price" },
                values: new object[,]
                {
                    { new Guid("4f81dc65-1a56-44bb-90c2-0468c90c308d"), "BMW", 136, "R 1250 RS", "Sport", 20000.0 },
                    { new Guid("e662b658-404b-4078-afff-523fc6889253"), "Triumph", 70, "Bonnevile T100", "Naked", 14000.0 },
                    { new Guid("f6ca9445-898d-405b-be7d-97ed33aac317"), "Kawasaki", 7, "KLX110R", "Motocross", 3195.0 }
                });
        }
    }
}
