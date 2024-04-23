using DAL.Concrete;
using DAL.Contacts;
using DI;
using Domain.Mappings;
using Entities.Models;
using HumanResourceProject.Models;
using Lamar.Microsoft.DependencyInjection;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connString = builder.Configuration.GetConnectionString("RecrutimentDatabase");
builder.Services.AddDbContext<RecrutimentContext>(options => options.UseSqlServer(connString));



// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IBrowsingDataRepository, BrowsingDataRepository>();
builder.Services.AddScoped<INotificationRepository, NotificationRepository>();  
builder.Services.AddDbContext<HospitalityPRO_DbContext>();
builder.Services.AddAutoMapper(typeof(GeneralProfile));


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", b => b.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin());
});

// use Lamar as DI.
builder.Host.UseLamar((context, registry) =>
{
    // register services using Lamar
    registry.IncludeRegistry<RecrutimentRegistry>();
    registry.IncludeRegistry<MapperRegistry>();
    // add the controllers
});


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
