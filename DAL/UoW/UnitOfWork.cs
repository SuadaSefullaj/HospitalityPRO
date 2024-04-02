using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;
using HumanResourceProject.Models;
using Lamar;

namespace DAL.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IContainer _container;

        private readonly HospitalityPRO_DbContext _dbContext;

        public UnitOfWork(IContainer container, HospitalityPRO_DbContext dbContext)
        {
            _container = container;
            _dbContext = dbContext;
        }

        public TRepository GetRepository<TRepository>() where TRepository : class
        {
            return _container.GetInstance<TRepository>();
        }

        public int Save()
        {
            return _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
            GC.SuppressFinalize(this);
        }
    }

}
