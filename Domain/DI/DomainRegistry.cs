using DAL.DI;
using Domain.Concrete;
using Domain.Contracts;
using Lamar;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DI
{
    public class DomainRegistry : ServiceRegistry
    {
        public DomainRegistry()
        {
            IncludeRegistry<DomainUnitOfWorkRegistry>();

            For<IUserDomain>().Use<UserDomain>();
            For<IExtraServiceDomain>().Use<ExtraServiceDomain>();


            AddRepositoryRegistries();
            AddHttpContextRegistries();
        }

        private void AddRepositoryRegistries()
        {
            IncludeRegistry<RepositoryRegistry>();
        }

        private void AddHttpContextRegistries()
        {
            For<IHttpContextAccessor>().Use<HttpContextAccessor>();
        }
    }
}
