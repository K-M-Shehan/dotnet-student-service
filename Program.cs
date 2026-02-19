using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using StudentService.Data;
using StudentService.Models;

var builder = WebApplication.CreateBuilder(args);

// Register controllers
builder.Services.AddControllers();

// Register EF Core with In-Memory database
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseInMemoryDatabase("StudentDb"));

// Register Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "StudentService API",
        Version = "v1",
        Description = "CRUD API for managing students"
    });
});

var app = builder.Build();

// Enable Swagger UI in all environments
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "StudentService API v1");
    c.RoutePrefix = string.Empty; // Serve Swagger UI at the app root
});

// Configure the HTTP request pipeline
app.UseHttpsRedirection();
app.MapControllers();

// Seed the in-memory database with sample students on startup
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    if (!db.Students.Any())
    {
        db.Students.AddRange(
            new Student { FirstName = "John", LastName = "Doe", Email = "john.doe@example.com", Age = 20, Major = "Computer Science", EnrolledAt = DateTime.UtcNow },
            new Student { FirstName = "Alice", LastName = "Smith", Email = "alice.smith@example.com", Age = 22, Major = "Mathematics", EnrolledAt = DateTime.UtcNow }
        );
        db.SaveChanges();
    }
}

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
