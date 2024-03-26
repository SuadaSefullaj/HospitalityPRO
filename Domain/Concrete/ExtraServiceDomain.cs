using Domain.Contracts;
using HospitabilityPro.Model;
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
        public IEnumerable<ExtraService> GetAllServices()
        {
            return new List<ExtraService>();
        }

        public ExtraService GetExtraServiceById(int serviceId)
        {
            throw new NotImplementedException();
        }
    }
}
