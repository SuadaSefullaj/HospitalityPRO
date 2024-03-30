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
       Task<ExtraService> AddExtraService(ExtraServiceDTO request);
        //Task<ExtraServiceDTO> UpdateExtraService(int serviceId, ExtraServiceDTO request);
    }
}