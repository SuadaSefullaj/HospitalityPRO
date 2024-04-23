using DTO;
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
        IEnumerable<ExtraServiceDTO> GetAllExtraServices();
        ExtraServiceDTO GetExtraService(int id);
        ExtraService AddExtraService(ExtraServiceDTO extraServiceDTO);
        ExtraService UpdateExtraService(int id, ExtraServiceDTO extraServiceDTO);
        void DeleteExtraService(int id);
    }
}
