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
       ExtraService AddExtraService(ExtraServiceDTO request);
       bool UpdateExtraService(int serviceId, ExtraServiceDTO request);
       bool DeleteExtraService(int serviceId);
       ExtraServiceDTO GetByServiceId(int serviceId);
       IList<ExtraServiceDTO> GetAllExtraServices();

    }
}