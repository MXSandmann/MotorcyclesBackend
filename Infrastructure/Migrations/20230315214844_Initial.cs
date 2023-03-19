using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Motorcycles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ModelName = table.Column<string>(type: "text", nullable: false),
                    Company = table.Column<string>(type: "text", nullable: false),
                    ModelType = table.Column<string>(type: "text", nullable: false),
                    EnginePower = table.Column<int>(type: "integer", nullable: false),
                    Price = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Motorcycles", x => x.Id);
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Motorcycles");
        }
    }
}
