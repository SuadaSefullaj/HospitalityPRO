using HumanResourceProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Contracts
{
    public interface IExtraServiceRepository
    {

        IEnumerable<ExtraService> GetAllExtraServices();
        ExtraService GetExtraService(int id);
        ExtraService AddExtraService(ExtraService extraService);
        ExtraService UpdateExtraService(ExtraService extraService);
        void DeleteExtraService(int id);
    }
}
