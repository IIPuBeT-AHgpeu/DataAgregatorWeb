using DataAgregatorWeb.Models;
using DataAgregatorWeb.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
//builder.Services.AddDbContext<HorizonDbContext>(options =>
//    options.UseSqlServer(connectionString));
builder.Services.AddDbContext<PassFlowDBContext>(options => options.UseNpgsql(connectionString));

builder.Services.AddTransient<IRepository<Bus>, Repository<Bus>>();
builder.Services.AddTransient<IRepository<Trip>, Repository<Trip>>();
builder.Services.AddTransient<IRepository<Way>, Repository<Way>>();
builder.Services.AddTransient<IWeatherService<FromWeatherAPIModel>, WeatherService>();
builder.Services.AddTransient<ISimpleLogger, SimpleLogger>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
