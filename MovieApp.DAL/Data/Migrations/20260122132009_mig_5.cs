using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MovieApp.DAL.Data.Migrations
{
    /// <inheritdoc />
    public partial class mig_5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Description", "DirectorId", "Duration", "Imdb", "ReleaseYear", "Title" },
                values: new object[,]
                {
                    { 1, "A thief who steals secrets through dreams is given a final mission.", 1, 148, 8.8m, new DateTime(2010, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Inception" },
                    { 2, "Batman faces the Joker, a criminal mastermind who spreads chaos.", 1, 152, 9.0m, new DateTime(2008, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Dark Knight" },
                    { 3, "A group of astronauts travel through a wormhole to save humanity.", 2, 169, 8.6m, new DateTime(2014, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Interstellar" },
                    { 4, "Two prisoners form a deep friendship over many years.", 2, 142, 9.3m, new DateTime(1994, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Shawshank Redemption" },
                    { 5, "The life story of a simple man with a big heart.", 3, 142, 8.8m, new DateTime(1994, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Forrest Gump" },
                    { 6, "A hacker discovers the true nature of his reality and fights against its controllers.", 4, 136, 8.7m, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Matrix" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 6);
        }
    }
}
