using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Concrete;
using DAL.Contracts;
using HumanResourceProject.Models;
using Microsoft.Extensions.DependencyInjection;

public class ExtraServiceDI
{
    public void ConfigureServices(IServiceCollection services)
    {
        //DbContext
        services.AddDbContext<HospitalityPRO_DbContext>();

        //Repositories
        services.AddScoped<IExtraServicesRepository, ExtraServicesRepository>();

        services.AddAutoMapper(typeof(ExtraServiceDI));
     
        // services.AddScoped<IService, Service>();
    }
}

