using HospitabilityPro.Model;
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
        ExtraService GetExtraServiceById(int serviceId);
    }
}