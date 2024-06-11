using KickSharing.DataAccess;
using KickSharing.DataAccess.Interfaces;
using KickSharing.DataAccess.Models;
using KickSharing.DataAccess.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AppDBContext>();

builder.Services.AddScoped<IPriceInterface<Price>, PriceService>();
builder.Services.AddScoped<IRentInterface<Rent>, RentService>();
builder.Services.AddScoped<IScooterInterface<Scooter>, ScooterService>();
builder.Services.AddScoped<IUserInterface<User>, UserService>();

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
