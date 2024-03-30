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
        Task<ExtraService> AddExtraService(ExtraServiceDTO request);
        Task<IEnumerable<ExtraService>> GetAllServices();
        Task<ExtraService> GetExtraServicesById(int serviceId);

    }
}
