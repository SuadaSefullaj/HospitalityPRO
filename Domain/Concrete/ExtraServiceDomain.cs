using DAL.Concrete;
using Domain.Contracts;
using DTO.ExtraServiceDTO;
using HumanResourceProject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Concrete
{
    public class ExtraServiceDomain : IExtraServiceDomain
    {
        private readonly HospitalityPRO_DbContext _dbContext;
        public ExtraServiceDomain (HospitalityPRO_DbContext context)
        {
            _dbContext = context;
        }
        public async Task<ExtraService> AddExtraService(ExtraServiceDTO request)
        {
            var extraService = new ExtraService
            {
                Type = request.Type,
                Price = request.Price,
                Description = request.Description
            };

             var addedExtraService = _dbContext.ExtraServices.Add(extraService);
            await _dbContext.SaveChangesAsync();

            return addedExtraService.Entity;
        }

        public async Task<ExtraService> UpdateExtraService(int serviceId, ExtraServiceDTO request)
        {
            var extraService = new ExtraService()
            {
                Type = request.Type,
                Price = request.Price,
                Description = request.Description
            };

            var updatedExtraService = _dbContext.ExtraServices.Update(extraService);
            await _dbContext.SaveChangesAsync();

            return updatedExtraService.Entity;
        }
    }
}
