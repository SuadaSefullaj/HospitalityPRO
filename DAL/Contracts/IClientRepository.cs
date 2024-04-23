using HumanResourceProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Contracts
{
    public interface IClientRepository 
    {
        IEnumerable<Client> GetAllClients();
        Client GetClientById(int id);
    }
}
