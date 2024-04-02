using AutoMapper;
using DAL.Contracts;
using DTO.ExtraServiceDTO;
using HumanResourceProject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Concrete
{
    internal class ExtraServicesRepository :  BaseRepository<ExtraService, Guid>, IExtraServicesRepository
    {
        public ExtraServicesRepository(HospitalityPRO_DbContext dbContext) : base(dbContext)
        {
        
        }

        public ExtraService GetExtraServicesById(int serviceId)
        {
           var data = context.FirstOrDefault(x=>x.ServicesId == serviceId);
            return data;
        }
    }
}
