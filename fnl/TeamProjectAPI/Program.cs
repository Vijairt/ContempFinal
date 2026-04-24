// ============================================================
// PRESENTATION NOTE - Program.cs
// This is the entry point of the entire application.
// Every line here configures and starts the web server.
// ============================================================

using Microsoft.EntityFrameworkCore;
using TeamProjectAPI.Data;

// PRESENTATION NOTE: Creates the application builder which loads settings
// from appsettings.json such as the database connection string.
var builder = WebApplication.CreateBuilder(args);

// PRESENTATION NOTE: Registers the MVC controllers so the app knows
// to route incoming HTTP requests to the correct controller classes.
builder.Services.AddControllers();

// PRESENTATION NOTE: Connects our app to SQL Server using Entity Framework Core.
// The connection string is read from appsettings.json under "DefaultConnection".
// This is what allows us to query and save data to the database.
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// PRESENTATION NOTE: Sets up NSwag to generate the Swagger UI documentation page.
// This gives us a visual browser interface to see and test all our API endpoints.
builder.Services.AddOpenApiDocument(config =>
{
    config.Title = "Team Project API";
    config.Version = "v1";
    config.Description = "ASP.NET Web API for IT3045C Final Project";
});

var app = builder.Build();

// PRESENTATION NOTE: Enables the Swagger UI at /swagger in the browser.
// This is how we visually interact with and test the API during the demo.
app.UseOpenApi();
app.UseSwaggerUi();

// PRESENTATION NOTE: Redirects any HTTP requests to HTTPS for security.
app.UseHttpsRedirection();

// PRESENTATION NOTE: Enables the authorization middleware for future use.
app.UseAuthorization();

// PRESENTATION NOTE: Maps incoming HTTP requests to the correct controller
// and action method based on the route (e.g. /api/TeamMembers).
app.MapControllers();

// PRESENTATION NOTE: Starts the web server and begins listening for requests.
app.Run();
