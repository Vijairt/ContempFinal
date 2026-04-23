using Microsoft.EntityFrameworkCore;
using TeamProjectAPI.Models;

namespace TeamProjectAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<TeamMember> TeamMembers { get; set; }
        public DbSet<Hobby> Hobbies { get; set; }
        public DbSet<BreakfastFood> BreakfastFoods { get; set; }
        public DbSet<Movie> Movies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TeamMember>().HasData(
                new TeamMember { Id = 1, FullName = "Rohit Vijai", Birthdate = new DateTime(2003, 7, 11), CollegeProgram = "Computer Information Technology", YearInProgram = "Junior", Email = "vijairt@mail.uc.edu" },
                new TeamMember { Id = 2, FullName = "Jack Baker", Birthdate = new DateTime(2001, 8, 22), CollegeProgram = "Computer Information Technology", YearInProgram = "Senior", Email = "jack.baker@student.edu" }
            );

            modelBuilder.Entity<Hobby>().HasData(
                new Hobby { Id = 1, Name = "Photography", Category = "Creative", Description = "Capturing moments with a camera", SkillLevel = 3, RequiresEquipment = true },
                new Hobby { Id = 2, Name = "Hiking", Category = "Outdoor", Description = "Exploring trails and nature", SkillLevel = 2, RequiresEquipment = false },
                new Hobby { Id = 3, Name = "Chess", Category = "Indoor", Description = "Strategic board game", SkillLevel = 4, RequiresEquipment = true },
                new Hobby { Id = 4, Name = "Painting", Category = "Creative", Description = "Creating art with paint", SkillLevel = 3, RequiresEquipment = true },
                new Hobby { Id = 5, Name = "Gaming", Category = "Indoor", Description = "Playing video games", SkillLevel = 5, RequiresEquipment = true }
            );

            modelBuilder.Entity<BreakfastFood>().HasData(
                new BreakfastFood { Id = 1, Name = "Pancakes", Cuisine = "American", Calories = 350, IsVegetarian = true, PreparationTime = "20 mins" },
                new BreakfastFood { Id = 2, Name = "Avocado Toast", Cuisine = "Modern", Calories = 250, IsVegetarian = true, PreparationTime = "10 mins" },
                new BreakfastFood { Id = 3, Name = "Breakfast Burrito", Cuisine = "Mexican", Calories = 500, IsVegetarian = false, PreparationTime = "15 mins" },
                new BreakfastFood { Id = 4, Name = "Greek Yogurt Parfait", Cuisine = "Mediterranean", Calories = 200, IsVegetarian = true, PreparationTime = "5 mins" },
                new BreakfastFood { Id = 5, Name = "Eggs Benedict", Cuisine = "American", Calories = 600, IsVegetarian = false, PreparationTime = "25 mins" }
            );

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
