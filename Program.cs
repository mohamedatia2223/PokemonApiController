using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PokemonReviewApp.Data;
using PokemonReviewApp.Helper;
using PokemonReviewApp.InterFace.Repo;
using PokemonReviewApp.Repo;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IOwnerRepo, OwnerRepo>();
builder.Services.AddScoped<IPokemonRepo, PokemonRepo>();
builder.Services.AddScoped<IReviewerRepo, ReviewerRepo>();
builder.Services.AddScoped<IReviewRepo, ReviewRepo>();

builder.Services.AddAutoMapper(typeof(MappingProfiles));


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
