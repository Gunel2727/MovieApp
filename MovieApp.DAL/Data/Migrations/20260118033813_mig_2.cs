using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieApp.DAL.Data.Migrations
{
    /// <inheritdoc />
    public partial class mig_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Region",
                table: "Directors",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Directors",
                keyColumn: "Id",
                keyValue: 1,
                column: "Region",
                value: null);

            migrationBuilder.UpdateData(
                table: "Directors",
                keyColumn: "Id",
                keyValue: 2,
                column: "Region",
                value: null);

            migrationBuilder.UpdateData(
                table: "Directors",
                keyColumn: "Id",
                keyValue: 3,
                column: "Region",
                value: null);

            migrationBuilder.UpdateData(
                table: "Directors",
                keyColumn: "Id",
                keyValue: 4,
                column: "Region",
                value: null);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Region",
                table: "Directors");
        }
    }
}
