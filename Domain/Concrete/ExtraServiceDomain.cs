using Domain.Contracts;
using DTO.ExtraServiceDTO;
using HumanResourceProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Concrete
{
    public class ExtraServiceDomain : IExtraServiceDomain
    {
        private readonly HospitalityPRO_DbContext _context;
        public ExtraServiceDomain (HospitalityPRO_DbContext context)
        {
            _context = context;
        }
        public IEnumerable<ExtraService> GetAllServices()
        {
            return new List<ExtraService>();
        }

        public async Task<ExtraService> GetExtraServiceById(int serviceID)
        {
            var service = await _context.ExtraServices.FindAsync(serviceID);
            return service;
        }
        //public async Task<ExtraServiceDTO> UpdateExtraService(int serviceId, ExtraServiceDTO request)
        //{

        //}
    }
}
