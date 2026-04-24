using Microsoft.EntityFrameworkCore;
using TeamProjectAPI.Data;

namespace TeamProjectAPI.Tests.Helpers
{
    public static class DbContextHelper
    {
        public static AppDbContext GetInMemoryDbContext(string dbName)
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: dbName)
                .Options;
            return new AppDbContext(options);
        }
    }
}
