using Microsoft.EntityFrameworkCore;
using MovieDatabase.Infrastructure.Data;
using MovieDatabase.Infrastructure.Seed;
using MovieDatabase.Application;
using MovieDatabase.API.ErrorHandling;
using MovieDatabase.API.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddCors();
builder.Services.AddControllers();
builder.Services.AddApplicationServices();
builder.Services.AddExceptionHandler<CustomExceptionHandler>();
//builder.Services.AddTransient<ExceptionMiddleware>();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
//app.UseMiddleware<ExceptionMiddleware>();

app.UseCors(builder => builder
    .AllowAnyMethod()
    .AllowAnyHeader()
    .WithOrigins("http://localhost:4200", "https://localhost:4200"));

app.UseExceptionHandler(options => { });


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

try
{
    using var scope = app.Services.CreateScope();
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppDbContext>();
    await context.Database.MigrateAsync();
    await DbSeeder.SeedAsync(context);
}
catch (Exception ex)
{
    Console.WriteLine(ex);
    throw;
}

app.Run();
