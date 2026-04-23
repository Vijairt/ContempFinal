using Microsoft.AspNetCore.Mvc;
using TeamProjectAPI.Controllers;
using TeamProjectAPI.Models;
using TeamProjectAPI.Tests.Helpers;

namespace TeamProjectAPI.Tests
{
    public class HobbiesControllerTests
    {
        private HobbiesController GetController(string dbName)
        {
            var context = DbContextHelper.GetInMemoryDbContext(dbName);
            context.Hobbies.AddRange(
                new Hobby { Id = 1, Name = "Photography", Category = "Creative", Description = "Taking photos", SkillLevel = 3, RequiresEquipment = true },
                new Hobby { Id = 2, Name = "Hiking", Category = "Outdoor", Description = "Walking trails", SkillLevel = 2, RequiresEquipment = false }
            );
            context.SaveChanges();
            return new HobbiesController(context);
        }

        [Fact]
        public async Task Get_NoId_ReturnsListOfHobbies()
        {
            var controller = GetController("Hobbies_Get_All");
            var result = await controller.Get(null);
            var ok = Assert.IsType<OkObjectResult>(result.Result);
            var hobbies = Assert.IsAssignableFrom<IEnumerable<Hobby>>(ok.Value);
            Assert.Equal(2, hobbies.Count());
        }

        [Fact]
        public async Task Get_ValidId_ReturnsHobby()
        {
            var controller = GetController("Hobbies_Get_ById");
            var result = await controller.Get(1);
            var ok = Assert.IsType<OkObjectResult>(result.Result);
            var hobby = Assert.IsType<Hobby>(ok.Value);
            Assert.Equal("Photography", hobby.Name);
        }

        [Fact]
        public async Task Get_InvalidId_ReturnsNotFound()
        {
            var controller = GetController("Hobbies_Get_NotFound");
            var result = await controller.Get(999);
            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public async Task Create_ValidHobby_ReturnsCreated()
        {
            var controller = GetController("Hobbies_Create");
            var newHobby = new Hobby { Id = 3, Name = "Chess", Category = "Indoor", Description = "Board game", SkillLevel = 4, RequiresEquipment = true };
            var result = await controller.Create(newHobby);
            var created = Assert.IsType<CreatedAtActionResult>(result.Result);
            var hobby = Assert.IsType<Hobby>(created.Value);
            Assert.Equal("Chess", hobby.Name);
        }

        [Fact]
        public async Task Update_ValidHobby_ReturnsNoContent()
        {
            var controller = GetController("Hobbies_Update");
            var updated = new Hobby { Id = 1, Name = "Photography Updated", Category = "Creative", Description = "Taking photos", SkillLevel = 5, RequiresEquipment = true };
            var result = await controller.Update(1, updated);
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task Update_IdMismatch_ReturnsBadRequest()
        {
            var controller = GetController("Hobbies_Update_BadRequest");
            var updated = new Hobby { Id = 2, Name = "Hiking", Category = "Outdoor", Description = "Walking", SkillLevel = 2, RequiresEquipment = false };
            var result = await controller.Update(1, updated);
            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public async Task Delete_ValidId_ReturnsNoContent()
        {
            var controller = GetController("Hobbies_Delete");
            var result = await controller.Delete(1);
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task Delete_InvalidId_ReturnsNotFound()
        {
            var controller = GetController("Hobbies_Delete_NotFound");
            var result = await controller.Delete(999);
            Assert.IsType<NotFoundResult>(result);
        }
    }
}
