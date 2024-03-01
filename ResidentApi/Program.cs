using Microsoft.EntityFrameworkCore;
using ResidentApi.Logic.Database;
using ResidentApi.Logic.Repositories;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

builder.Services.AddDbContext<ResidentDbContext>(options =>
    options.UseSqlServer(config.GetConnectionString("DefaultConnectionString")));

// Add services to the container.
builder.Services.AddScoped<IResidentRepository, ResidentRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

using var scope = app.Services.CreateScope();
var context = scope.ServiceProvider.GetService<DatabaseInitializer>();
await context.InitializeAsync();

app.MapControllers();

app.Run();

public partial class Program { }