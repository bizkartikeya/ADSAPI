using AdsSqlApi.Infrastructure;
using AdsSqlApi.Infrastructure.Persistence;
using AdsSqlApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddInfrastructure(builder.Configuration);
// DbContext is registered in Infrastructure.AddInfrastructure

var app = builder.Build();

// Log DB connection string and pads count, seed sample pad if empty
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var logger = services.GetRequiredService<ILogger<Program>>();
    try
    {
        var db = services.GetRequiredService<AppDbContext>();
        db.Database.Migrate();

        var conn = db.Database.GetDbConnection().ConnectionString;
        logger.LogInformation("Env: {Env}, Connection: {Conn}", builder.Environment.EnvironmentName, conn);

        var count = await db.Pads.CountAsync();
        logger.LogInformation("Pads count: {Count}", count);

        if (count == 0)
        {
            var seededId = Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa6");
            db.Pads.Add(new Pads
            {
                Id = seededId,
                Name = "Seed Pad",
                Code = "SEED",
                IsActive = true,
                CreatedAtUtc = DateTime.UtcNow
            });
            await db.SaveChangesAsync();
            logger.LogInformation("Seeded pad with Id: {Id}", seededId);
        }
    }
    catch (Exception ex)
    {
        logger.LogError(ex, "An error occurred while migrating or seeding the database.");
        throw;
    }
}

app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();

app.MapGet("/", () => Results.Redirect("/swagger"));
app.MapControllers();

app.Run();
