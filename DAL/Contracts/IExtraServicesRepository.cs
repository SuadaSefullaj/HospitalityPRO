using DTO.ExtraServiceDTO;
using HumanResourceProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Contracts
{
    public interface IExtraServicesRepository
    {
        Task<IEnumerable<ExtraService>> GetAllServices();
        Task<ExtraService> GetExtraServicesById(int serviceId); 
        Task<ExtraService> AddExtraService(ExtraServiceDTO request);
        Task<ExtraService> UpdateExtraService(int serviceId, ExtraServiceDTO request);
    }
}
