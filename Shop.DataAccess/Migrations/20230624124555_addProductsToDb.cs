using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Shop.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addProductsToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Developer = table.Column<string>(type: "TEXT", nullable: false),
                    Publisher = table.Column<string>(type: "TEXT", nullable: false),
                    Price = table.Column<double>(type: "REAL", nullable: false),
                    Price50 = table.Column<double>(type: "REAL", nullable: false),
                    Price100 = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "Developer", "Price", "Price100", "Price50", "Publisher", "Title" },
                values: new object[,]
                {
                    { 1, "Prepare to live", "Form Hardware", 59.990000000000002, 39.990000000000002, 49.990000000000002, "Nandai Bamco", "Bright Souls" },
                    { 2, "Prepare to live again", "Form Hardware", 59.990000000000002, 39.990000000000002, 49.990000000000002, "Nandai Bamco", "Bright Souls 2" },
                    { 3, "Prepere to die", "Form Hardware, Bimtendo, Circle Enix, Bugisoft, Icestorm, DVD Projekt BLUE, Altus", 69.989999999999995, 49.990000000000002, 59.990000000000002, "NASA", "Dean Simulator" },
                    { 4, "The sequel to the critically acclaimed masterpiece Dean Simulator", "Form Hardware, Bimtendo, Circle Enix, Bugisoft, Icestorm, DVD Projekt BLUE, Altus", 69.989999999999995, 49.990000000000002, 59.990000000000002, "NASA", "Dean Simulator - Revenge" },
                    { 5, "Hardest game ever - IGN", "Dean", 59.990000000000002, 39.990000000000002, 49.990000000000002, "Dean", "Student Simulator 2023" },
                    { 6, "One of the most well known games in the whole universe", "Bimtendo", 59.990000000000002, 39.990000000000002, 49.990000000000002, "Bimtendo", "Super Maria Sisters" },
                    { 7, "Game of the Year, every year", "Bimtendo", 59.990000000000002, 39.990000000000002, 49.990000000000002, "Bimtendo", "Super Maria Sisters 2" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
