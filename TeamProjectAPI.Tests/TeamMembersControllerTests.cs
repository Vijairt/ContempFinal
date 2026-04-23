using Microsoft.AspNetCore.Mvc;
using TeamProjectAPI.Controllers;
using TeamProjectAPI.Models;
using TeamProjectAPI.Tests.Helpers;

namespace TeamProjectAPI.Tests
{
    public class TeamMembersControllerTests
    {
        private TeamMembersController GetController(string dbName)
        {
            var context = DbContextHelper.GetInMemoryDbContext(dbName);
            context.TeamMembers.AddRange(
                new TeamMember { Id = 1, FullName = "Alice Smith", Birthdate = new DateTime(2000, 1, 1), CollegeProgram = "CIT", YearInProgram = "Junior", Email = "alice@test.com" },
                new TeamMember { Id = 2, FullName = "Bob Jones", Birthdate = new DateTime(2001, 3, 15), CollegeProgram = "CIT", YearInProgram = "Senior", Email = "bob@test.com" }
            );
            context.SaveChanges();
            return new TeamMembersController(context);
        }

        [Fact]
        public async Task Get_NoId_ReturnsListOfMembers()
        {
            var controller = GetController("TeamMembers_Get_All");
            var result = await controller.Get(null);
            var ok = Assert.IsType<OkObjectResult>(result.Result);
            var members = Assert.IsAssignableFrom<IEnumerable<TeamMember>>(ok.Value);
            Assert.Equal(2, members.Count());
        }

        [Fact]
        public async Task Get_ValidId_ReturnsMember()
        {
            var controller = GetController("TeamMembers_Get_ById");
            var result = await controller.Get(1);
            var ok = Assert.IsType<OkObjectResult>(result.Result);
            var member = Assert.IsType<TeamMember>(ok.Value);
            Assert.Equal("Alice Smith", member.FullName);
        }

        [Fact]
        public async Task Get_InvalidId_ReturnsNotFound()
        {
            var controller = GetController("TeamMembers_Get_NotFound");
            var result = await controller.Get(999);
            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public async Task Create_ValidMember_ReturnsCreated()
        {
            var controller = GetController("TeamMembers_Create");
            var newMember = new TeamMember { Id = 3, FullName = "Carol White", Birthdate = new DateTime(2002, 6, 10), CollegeProgram = "CIT", YearInProgram = "Freshman", Email = "carol@test.com" };
            var result = await controller.Create(newMember);
            var created = Assert.IsType<CreatedAtActionResult>(result.Result);
            var member = Assert.IsType<TeamMember>(created.Value);
            Assert.Equal("Carol White", member.FullName);
        }

        [Fact]
        public async Task Update_ValidMember_ReturnsNoContent()
        {
            var controller = GetController("TeamMembers_Update");
            var updated = new TeamMember { Id = 1, FullName = "Alice Updated", Birthdate = new DateTime(2000, 1, 1), CollegeProgram = "CIT", YearInProgram = "Senior", Email = "alice@test.com" };
            var result = await controller.Update(1, updated);
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task Update_IdMismatch_ReturnsBadRequest()
        {
            var controller = GetController("TeamMembers_Update_BadRequest");
            var updated = new TeamMember { Id = 2, FullName = "Alice", Birthdate = DateTime.Now, CollegeProgram = "CIT", YearInProgram = "Junior", Email = "alice@test.com" };
            var result = await controller.Update(1, updated);
            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public async Task Delete_ValidId_ReturnsNoContent()
        {
            var controller = GetController("TeamMembers_Delete");
            var result = await controller.Delete(1);
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task Delete_InvalidId_ReturnsNotFound()
        {
            var controller = GetController("TeamMembers_Delete_NotFound");
            var result = await controller.Delete(999);
            Assert.IsType<NotFoundResult>(result);
        }
    }
}
