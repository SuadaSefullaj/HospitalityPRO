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
    public class ExtraServicesRepository : IExtraServicesRepository
    {
        private readonly HospitalityPRO_DbContext _dbContext;
        private readonly IMapper _mapper;
        public ExtraServicesRepository(HospitalityPRO_DbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<IEnumerable<ExtraService>> GetAllServices()
        {
            return await _dbContext.ExtraServices.ToListAsync();
        }
        public async Task<ExtraService> GetExtraServicesById(int serviceId)
        {
            return await _dbContext.ExtraServices.FirstOrDefaultAsync(c => c.ServicesId == serviceId)
                ?? throw new Exception("Not Found!!!");
        }
        public async Task<ExtraService> AddExtraService(ExtraServiceDTO request)
        {
            var extraService = _mapper.Map<ExtraService>(request);

            var addedExtraService = _dbContext.ExtraServices.Add(extraService);
            await _dbContext.SaveChangesAsync();

            return addedExtraService.Entity;
        }

        public async Task<ExtraService> UpdateExtraService(int serviceId, ExtraServiceDTO request)
        {
            var existingService = _dbContext.ExtraServices.FirstOrDefault(c => c.ServicesId == serviceId);
            _mapper.Map(existingService, request);
            await _dbContext.SaveChangesAsync();
            return existingService;
        }
    }
}
