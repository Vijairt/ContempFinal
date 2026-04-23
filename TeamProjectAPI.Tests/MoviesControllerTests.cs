using Microsoft.AspNetCore.Mvc;
using TeamProjectAPI.Controllers;
using TeamProjectAPI.Models;
using TeamProjectAPI.Tests.Helpers;

namespace TeamProjectAPI.Tests
{
    public class MoviesControllerTests
    {
        private MoviesController GetController(string dbName)
        {
            var context = DbContextHelper.GetInMemoryDbContext(dbName);
            context.Movies.AddRange(
                new Movie { Id = 1, Title = "Inception", Genre = "Sci-Fi", ReleaseYear = 2010, Director = "Christopher Nolan", Rating = 8.8 },
                new Movie { Id = 2, Title = "The Dark Knight", Genre = "Action", ReleaseYear = 2008, Director = "Christopher Nolan", Rating = 9.0 }
            );
            context.SaveChanges();
            return new MoviesController(context);
        }

        [Fact]
        public async Task Get_NoId_ReturnsListOfMovies()
        {
            var controller = GetController("Movies_Get_All");
            var result = await controller.Get(null);
            var ok = Assert.IsType<OkObjectResult>(result.Result);
            var movies = Assert.IsAssignableFrom<IEnumerable<Movie>>(ok.Value);
            Assert.Equal(2, movies.Count());
        }

        [Fact]
        public async Task Get_ValidId_ReturnsMovie()
        {
            var controller = GetController("Movies_Get_ById");
            var result = await controller.Get(1);
            var ok = Assert.IsType<OkObjectResult>(result.Result);
            var movie = Assert.IsType<Movie>(ok.Value);
            Assert.Equal("Inception", movie.Title);
        }

        [Fact]
        public async Task Get_InvalidId_ReturnsNotFound()
        {
            var controller = GetController("Movies_Get_NotFound");
            var result = await controller.Get(999);
            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public async Task Create_ValidMovie_ReturnsCreated()
        {
            var controller = GetController("Movies_Create");
            var newMovie = new Movie { Id = 3, Title = "Interstellar", Genre = "Sci-Fi", ReleaseYear = 2014, Director = "Christopher Nolan", Rating = 8.6 };
            var result = await controller.Create(newMovie);
            var created = Assert.IsType<CreatedAtActionResult>(result.Result);
            var movie = Assert.IsType<Movie>(created.Value);
            Assert.Equal("Interstellar", movie.Title);
        }

        [Fact]
        public async Task Update_ValidMovie_ReturnsNoContent()
        {
            var controller = GetController("Movies_Update");
            var updated = new Movie { Id = 1, Title = "Inception Updated", Genre = "Sci-Fi", ReleaseYear = 2010, Director = "Christopher Nolan", Rating = 9.0 };
            var result = await controller.Update(1, updated);
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task Update_IdMismatch_ReturnsBadRequest()
        {
            var controller = GetController("Movies_Update_BadRequest");
            var updated = new Movie { Id = 2, Title = "The Dark Knight", Genre = "Action", ReleaseYear = 2008, Director = "Christopher Nolan", Rating = 9.0 };
            var result = await controller.Update(1, updated);
            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public async Task Delete_ValidId_ReturnsNoContent()
        {
            var controller = GetController("Movies_Delete");
            var result = await controller.Delete(1);
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task Delete_InvalidId_ReturnsNotFound()
        {
            var controller = GetController("Movies_Delete_NotFound");
            var result = await controller.Delete(999);
            Assert.IsType<NotFoundResult>(result);
        }
    }
}
