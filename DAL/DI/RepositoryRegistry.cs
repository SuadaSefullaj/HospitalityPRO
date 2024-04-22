using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Concrete;
using DAL.Contracts;
using HumanResourceProject.Models;
using Lamar;
using Microsoft.EntityFrameworkCore;

namespace DAL.DI
{
    public class RepositoryRegistry : ServiceRegistry
    {
        public RepositoryRegistry()
        {
            IncludeRegistry<UnitOfWorkRegistry>();

            For<IUserRepository>().Use<UserRepository>();
            For<IClientRepository>().Use<ClientRepository>();
            For<IRoomTypeRepository>().Use<RoomTypeRepository>();
        }


    }
}
