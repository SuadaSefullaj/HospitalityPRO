using DAL.Contracts;
using HumanResourceProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Concrete
{
    internal class ExtraServiceRepository : BaseRepository<ExtraService, int>, IExtraServiceRepository
    {
        public ExtraServiceRepository(HospitalityPRO_DbContext dbContext) : base(dbContext)
        {
        }

    public ExtraService GetExtraService(int id)
        {
            return GetById(id);
        }

        public IEnumerable<ExtraService> GetAllExtraServices()
        {
            return GetAll();
        }

        public ExtraService AddExtraService(ExtraService request)
        {
            Add(request);
            PersistChangesToTrackedEntities();
            return request;
        }

        public ExtraService UpdateExtraService(ExtraService request)
        {
            Update(request);
            PersistChangesToTrackedEntities();
            return request;
        }

        public void DeleteExtraService(int id)
        {
            Remove(id);
            PersistChangesToTrackedEntities();
        }
    }
 }

   
