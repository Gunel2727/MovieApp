using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MovieApp.DAL.Data.Migrations
{
    /// <inheritdoc />
    public partial class mig_1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Directors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Directors", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Directors",
                columns: new[] { "Id", "Address", "Age", "City", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "100 Hollywood Blvd,Los Angeles,CA", 74, "Los Angeles", "An American filmmaker known for his work in blockbuster films", "Steven Spielberg" },
                    { 2, "200 Sunset Blvd, Los Angeles, CA", 53, "Los Angeles", "A British-American film director known for complex storytelling", "Christopher Nolan" },
                    { 3, "300 Vine St, Hollywood, CA", 60, "Hollywood", "An American filmmaker famous for non-linear narratives", "Quentin Tarantino" },
                    { 4, "400 Broadway, New York, NY", 81, "New York", "An American director known for crime and drama films", "Martin Scorsese" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Directors");
        }
    }
}
