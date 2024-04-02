using DTO.ExtraServiceDTO;
using Entities.Models;
using HumanResourceProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Contracts
{
    public interface IExtraServicesRepository : IRepository<ExtraService, Guid>
    {
    ExtraService GetExtraServicesById(int serviceId); 

    }
}
