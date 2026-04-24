// ============================================================
// PRESENTATION NOTE - AppDbContext.cs
// This is the Database Context class - it is the bridge between
// our C# application and the SQL Server database.
// Every database operation in the app goes through this class.
// ============================================================

using Microsoft.EntityFrameworkCore;
using TeamProjectAPI.Models;

namespace TeamProjectAPI.Data
{
    public class AppDbContext : DbContext
    {
        // PRESENTATION NOTE: Constructor that receives database options (like the connection string)
        // and passes them to the base DbContext class from Entity Framework Core.
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // PRESENTATION NOTE: Each DbSet represents one table in the database.
        // Entity Framework Core uses these to generate and query the actual SQL tables.
        public DbSet<TeamMember> TeamMembers { get; set; }
        public DbSet<Hobby> Hobbies { get; set; }
        public DbSet<BreakfastFood> BreakfastFoods { get; set; }
        public DbSet<Movie> Movies { get; set; }

        // PRESENTATION NOTE: OnModelCreating runs automatically when the database is first created.
        // This is where we seed all four tables with default data so the API works
        // immediately without needing to manually insert any records.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // PRESENTATION NOTE: Seeds the TeamMembers table with our two team members.
            // This satisfies the rubric requirement for team member data including
            // full name, birthdate, college program, year in program, and email.
            modelBuilder.Entity<TeamMember>().HasData(
                new TeamMember { Id = 1, FullName = "Rohit Vijai", Birthdate = new DateTime(2003, 7, 11), CollegeProgram = "Computer Information Technology", YearInProgram = "Junior", Email = "vijairt@mail.uc.edu" },
                new TeamMember { Id = 2, FullName = "Jack Baker", Birthdate = new DateTime(2001, 8, 22), CollegeProgram = "Computer Information Technology", YearInProgram = "Senior", Email = "jack.baker@student.edu" }
            );

            // PRESENTATION NOTE: Seeds the Hobbies table with 5 hobbies.
            // Each hobby has a name, category, description, skill level, and equipment requirement.
            modelBuilder.Entity<Hobby>().HasData(
                new Hobby { Id = 1, Name = "Photography", Category = "Creative", Description = "Capturing moments with a camera", SkillLevel = 3, RequiresEquipment = true },
                new Hobby { Id = 2, Name = "Hiking", Category = "Outdoor", Description = "Exploring trails and nature", SkillLevel = 2, RequiresEquipment = false },
                new Hobby { Id = 3, Name = "Chess", Category = "Indoor", Description = "Strategic board game", SkillLevel = 4, RequiresEquipment = true },
                new Hobby { Id = 4, Name = "Painting", Category = "Creative", Description = "Creating art with paint", SkillLevel = 3, RequiresEquipment = true },
                new Hobby { Id = 5, Name = "Gaming", Category = "Indoor", Description = "Playing video games", SkillLevel = 5, RequiresEquipment = true }
            );

            // PRESENTATION NOTE: Seeds the BreakfastFoods table with 5 breakfast foods.
            // Each food has a name, cuisine type, calorie count, vegetarian status, and prep time.
            modelBuilder.Entity<BreakfastFood>().HasData(
                new BreakfastFood { Id = 1, Name = "Pancakes", Cuisine = "American", Calories = 350, IsVegetarian = true, PreparationTime = "20 mins" },
                new BreakfastFood { Id = 2, Name = "Avocado Toast", Cuisine = "Modern", Calories = 250, IsVegetarian = true, PreparationTime = "10 mins" },
                new BreakfastFood { Id = 3, Name = "Breakfast Burrito", Cuisine = "Mexican", Calories = 500, IsVegetarian = false, PreparationTime = "15 mins" },
                new BreakfastFood { Id = 4, Name = "Greek Yogurt Parfait", Cuisine = "Mediterranean", Calories = 200, IsVegetarian = true, PreparationTime = "5 mins" },
                new BreakfastFood { Id = 5, Name = "Eggs Benedict", Cuisine = "American", Calories = 600, IsVegetarian = false, PreparationTime = "25 mins" }
            );

            // PRESENTATION NOTE: Seeds the Movies table with 5 favorite movies.
            // Each movie has a title, genre, release year, director, and rating out of 10.
            modelBuilder.Entity<Movie>().HasData(
                new Movie { Id = 1, Title = "Inception", Genre = "Sci-Fi", ReleaseYear = 2010, Director = "Christopher Nolan", Rating = 8.8 },
                new Movie { Id = 2, Title = "The Dark Knight", Genre = "Action", ReleaseYear = 2008, Director = "Christopher Nolan", Rating = 9.0 },
                new Movie { Id = 3, Title = "Interstellar", Genre = "Sci-Fi", ReleaseYear = 2014, Director = "Christopher Nolan", Rating = 8.6 },
                new Movie { Id = 4, Title = "Parasite", Genre = "Thriller", ReleaseYear = 2019, Director = "Bong Joon-ho", Rating = 8.5 },
                new Movie { Id = 5, Title = "The Shawshank Redemption", Genre = "Drama", ReleaseYear = 1994, Director = "Frank Darabont", Rating = 9.3 }
            );
        }
    }
}
