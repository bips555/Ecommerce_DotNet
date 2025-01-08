using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Ecommerce_DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ISBN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ListPrice = table.Column<double>(type: "float", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Price50 = table.Column<double>(type: "float", nullable: false),
                    Price100 = table.Column<double>(type: "float", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "DisplayOrder", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Action" },
                    { 2, 2, "Sci-Fi" },
                    { 3, 3, "Romance" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Author", "CategoryId", "Description", "ISBN", "ImageUrl", "ListPrice", "Price", "Price100", "Price50", "Title" },
                values: new object[,]
                {
                    { 1, "Billy Spark", 1, "Praesent vitae sodales libero. Praesent molestie.", "SWD9999001", "", 99.0, 90.0, 80.0, 85.0, "Fortune of Time" },
                    { 2, "Jane Doe", 2, "Lorem ipsum dolor sit amet, consectetur adipiscing elit.", "SWD9999002", "", 120.0, 110.0, 100.0, 105.0, "Future of Earth" },
                    { 3, "John Smith", 3, "Sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.", "SWD9999003", "", 89.0, 85.0, 75.0, 80.0, "Secrets of the Universe" },
                    { 4, "Alice Johnson", 1, "Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris.", "SWD9999004", "", 95.0, 90.0, 80.0, 85.0, "The Hidden Truth" },
                    { 5, "Michael Brown", 2, "Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore.", "SWD9999005", "", 150.0, 140.0, 130.0, 135.0, "Adventures in Coding" },
                    { 6, "Chris Green", 3, "Excepteur sint occaecat cupidatat non proident, sunt in culpa.", "SWD9999006", "", 200.0, 190.0, 180.0, 185.0, "Mastering .NET" },
                    { 7, "Emily White", 1, "Proin eget tortor risus. Donec sollicitudin molestie malesuada.", "SWD9999007", "", 110.0, 100.0, 90.0, 95.0, "Journey to the Stars" },
                    { 8, "Robert Black", 2, "Vestibulum ac diam sit amet quam vehicula elementum.", "SWD9999008", "", 130.0, 120.0, 110.0, 115.0, "Data Structures Unleashed" },
                    { 9, "Sophia Blue", 3, "Pellentesque in ipsum id orci porta dapibus.", "SWD9999009", "", 175.0, 165.0, 155.0, 160.0, "Artificial Intelligence Basics" },
                    { 10, "Ethan Gray", 1, "Curabitur aliquet quam id dui posuere blandit.", "SWD9999010", "", 140.0, 130.0, 120.0, 125.0, "The Art of Problem Solving" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
