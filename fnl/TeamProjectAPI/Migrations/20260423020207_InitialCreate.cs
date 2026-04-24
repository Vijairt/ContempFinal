using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TeamProjectAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BreakfastFoods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cuisine = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Calories = table.Column<int>(type: "int", nullable: false),
                    IsVegetarian = table.Column<bool>(type: "bit", nullable: false),
                    PreparationTime = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BreakfastFoods", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Hobbies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SkillLevel = table.Column<int>(type: "int", nullable: false),
                    RequiresEquipment = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hobbies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Genre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReleaseYear = table.Column<int>(type: "int", nullable: false),
                    Director = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rating = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TeamMembers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Birthdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CollegeProgram = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    YearInProgram = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamMembers", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "BreakfastFoods",
                columns: new[] { "Id", "Calories", "Cuisine", "IsVegetarian", "Name", "PreparationTime" },
                values: new object[,]
                {
                    { 1, 350, "American", true, "Pancakes", "20 mins" },
                    { 2, 250, "Modern", true, "Avocado Toast", "10 mins" },
                    { 3, 500, "Mexican", false, "Breakfast Burrito", "15 mins" },
                    { 4, 200, "Mediterranean", true, "Greek Yogurt Parfait", "5 mins" },
                    { 5, 600, "American", false, "Eggs Benedict", "25 mins" }
                });

            migrationBuilder.InsertData(
                table: "Hobbies",
                columns: new[] { "Id", "Category", "Description", "Name", "RequiresEquipment", "SkillLevel" },
                values: new object[,]
                {
                    { 1, "Creative", "Capturing moments with a camera", "Photography", true, 3 },
                    { 2, "Outdoor", "Exploring trails and nature", "Hiking", false, 2 },
                    { 3, "Indoor", "Strategic board game", "Chess", true, 4 },
                    { 4, "Creative", "Creating art with paint", "Painting", true, 3 },
                    { 5, "Indoor", "Playing video games", "Gaming", true, 5 }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Director", "Genre", "Rating", "ReleaseYear", "Title" },
                values: new object[,]
                {
                    { 1, "Christopher Nolan", "Sci-Fi", 8.8000000000000007, 2010, "Inception" },
                    { 2, "Christopher Nolan", "Action", 9.0, 2008, "The Dark Knight" },
                    { 3, "Christopher Nolan", "Sci-Fi", 8.5999999999999996, 2014, "Interstellar" },
                    { 4, "Bong Joon-ho", "Thriller", 8.5, 2019, "Parasite" },
                    { 5, "Frank Darabont", "Drama", 9.3000000000000007, 1994, "The Shawshank Redemption" }
                });

            migrationBuilder.InsertData(
                table: "TeamMembers",
                columns: new[] { "Id", "Birthdate", "CollegeProgram", "Email", "FullName", "YearInProgram" },
                values: new object[,]
                {
                    { 1, new DateTime(2002, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Computer Information Technology", "rohit.vijai@student.edu", "Rohit Vijai", "Junior" },
                    { 2, new DateTime(2001, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Computer Information Technology", "alex.johnson@student.edu", "Alex Johnson", "Senior" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BreakfastFoods");

            migrationBuilder.DropTable(
                name: "Hobbies");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "TeamMembers");
        }
    }
}
