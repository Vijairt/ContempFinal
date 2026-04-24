using Microsoft.AspNetCore.Mvc;
using TeamProjectAPI.Controllers;
using TeamProjectAPI.Models;
using TeamProjectAPI.Tests.Helpers;

namespace TeamProjectAPI.Tests
{
    public class BreakfastFoodsControllerTests
    {
        private BreakfastFoodsController GetController(string dbName)
        {
            var context = DbContextHelper.GetInMemoryDbContext(dbName);
            context.BreakfastFoods.AddRange(
                new BreakfastFood { Id = 1, Name = "Pancakes", Cuisine = "American", Calories = 350, IsVegetarian = true, PreparationTime = "20 mins" },
                new BreakfastFood { Id = 2, Name = "Avocado Toast", Cuisine = "Modern", Calories = 250, IsVegetarian = true, PreparationTime = "10 mins" }
            );
            context.SaveChanges();
            return new BreakfastFoodsController(context);
        }

        [Fact]
        public async Task Get_NoId_ReturnsListOfFoods()
        {
            var controller = GetController("BreakfastFoods_Get_All");
            var result = await controller.Get(null);
            var ok = Assert.IsType<OkObjectResult>(result.Result);
            var foods = Assert.IsAssignableFrom<IEnumerable<BreakfastFood>>(ok.Value);
            Assert.Equal(2, foods.Count());
        }

        [Fact]
        public async Task Get_ValidId_ReturnsFood()
        {
            var controller = GetController("BreakfastFoods_Get_ById");
            var result = await controller.Get(1);
            var ok = Assert.IsType<OkObjectResult>(result.Result);
            var food = Assert.IsType<BreakfastFood>(ok.Value);
            Assert.Equal("Pancakes", food.Name);
        }

        [Fact]
        public async Task Get_InvalidId_ReturnsNotFound()
        {
            var controller = GetController("BreakfastFoods_Get_NotFound");
            var result = await controller.Get(999);
            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public async Task Create_ValidFood_ReturnsCreated()
        {
            var controller = GetController("BreakfastFoods_Create");
            var newFood = new BreakfastFood { Id = 3, Name = "Eggs Benedict", Cuisine = "American", Calories = 600, IsVegetarian = false, PreparationTime = "25 mins" };
            var result = await controller.Create(newFood);
            var created = Assert.IsType<CreatedAtActionResult>(result.Result);
            var food = Assert.IsType<BreakfastFood>(created.Value);
            Assert.Equal("Eggs Benedict", food.Name);
        }

        [Fact]
        public async Task Update_ValidFood_ReturnsNoContent()
        {
            var controller = GetController("BreakfastFoods_Update");
            var updated = new BreakfastFood { Id = 1, Name = "Pancakes Updated", Cuisine = "American", Calories = 400, IsVegetarian = true, PreparationTime = "25 mins" };
            var result = await controller.Update(1, updated);
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task Update_IdMismatch_ReturnsBadRequest()
        {
            var controller = GetController("BreakfastFoods_Update_BadRequest");
            var updated = new BreakfastFood { Id = 2, Name = "Avocado Toast", Cuisine = "Modern", Calories = 250, IsVegetarian = true, PreparationTime = "10 mins" };
            var result = await controller.Update(1, updated);
            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public async Task Delete_ValidId_ReturnsNoContent()
        {
            var controller = GetController("BreakfastFoods_Delete");
            var result = await controller.Delete(1);
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task Delete_InvalidId_ReturnsNotFound()
        {
            var controller = GetController("BreakfastFoods_Delete_NotFound");
            var result = await controller.Delete(999);
            Assert.IsType<NotFoundResult>(result);
        }
    }
}
