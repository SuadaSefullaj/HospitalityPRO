using DTO.ExtraServiceDTO;
using HumanResourceProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts
{
    public interface IExtraServiceDomain
    {
        IEnumerable<ExtraService> GetAllServices();
        Task<ExtraService> GetExtraServiceById(int serviceId);
        //Task<ExtraServiceDTO> UpdateExtraService(int serviceId, ExtraServiceDTO request);
    }
}