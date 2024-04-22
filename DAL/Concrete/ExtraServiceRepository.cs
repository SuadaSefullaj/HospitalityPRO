using DAL.Contracts;
using HumanResourceProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Concrete
{
    public class ExtraServiceRepository : IExtraServiceRepository
    {
        private readonly HospitalityPRO_DbContext _dbContext;

        public ExtraServiceRepository(HospitalityPRO_DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<ExtraService> GetAllExtraServices()
        {
            return _dbContext.ExtraServices.ToList();
        }

        public ExtraService GetExtraService(int id)
        {
            return _dbContext.ExtraServices.Find(id);
        }

        public ExtraService AddExtraService(ExtraService request)
        {
            _dbContext.ExtraServices.Add(request);
            _dbContext.SaveChanges();
            return request;
        }

        public ExtraService UpdateExtraService(ExtraService request)
        {
            _dbContext.SaveChanges();
            return request;
        }

        public void DeleteExtraService(int id)
        {
            var extraService = _dbContext.ExtraServices.Find(id);
            if (extraService != null)
            {
                _dbContext.ExtraServices.Remove(extraService);
                _dbContext.SaveChanges();
            }
        }
    }
}
   
