using DAL.Concrete;
using DAL.Contracts;
using DI;
using Domain.Concrete;
using Domain.Contracts;
using Domain.Mappings;
using Entities.Models;
using Helpers;
using HumanResourceProject.Models;
using Lamar.Microsoft.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Quartz;
using Swashbuckle.AspNetCore.Filters;
using System.Configuration;
using System.Text;

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
builder.Services.AddHttpContextAccessor();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        Description = "Standard Authorization header using the Bearer scheme (\"bearer {token}\")",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });

    options.OperationFilter<SecurityRequirementsOperationFilter>();
});

//To read the TOKEN by using the key, this key is set in AppSettings
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8
                .GetBytes(builder.Configuration.GetSection("AppSettings:Token").Value)),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });

builder.Services.AddAutoMapper(typeof(GeneralProfile));

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", b => b.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin());
});
builder.Services.AddQuartz(configure =>
{
    configure.UseMicrosoftDependencyInjectionJobFactory();
});


// add QUARTZ services
builder.Services.AddQuartzHostedService(options =>
{
    options.WaitForJobsToComplete = true;
});
builder.Services.AddQuartz(configure =>
{
    var jobKey = new JobKey(nameof(DeleteInactiveClientsJob));

    configure
        .AddJob<DeleteInactiveClientsJob>(jobKey)
        .AddTrigger(
            trigger => trigger
                .ForJob(jobKey)
                .WithSimpleSchedule(schedule => schedule
                    .WithIntervalInHours(24) // Run once a day
                    .RepeatForever()));

    configure.UseMicrosoftDependencyInjectionJobFactory();
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
app.UseCors("AllowAll");
app.UseAuthentication(); 
app.UseAuthorization();


app.MapControllers();

app.Run();
