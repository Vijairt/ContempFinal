using Microsoft.EntityFrameworkCore;
using TeamProjectAPI.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddOpenApiDocument(config =>
{
    config.Title = "Team Project API";
    config.Version = "v1";
    config.Description = "ASP.NET Web API for IT3045C Final Project";
});

var app = builder.Build();

app.UseOpenApi();
app.UseSwaggerUi();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
