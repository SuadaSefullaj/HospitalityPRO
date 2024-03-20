using DTO;
using HumanResourceProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ClientService
{
    public interface IClientService
    {
        Task<Client> RegisterClientAsync(ClientRegistrationDTO request);

        Task<Client> AuthenticateClientAsync(string email, string password);

        string GetMyName();
        Task<IEnumerable<Client>> GetClientsAsync();
        Task<Client> GetClientByIdAsync(int id);
        Task<Client> AddClientAsync(Client client);
        Task DeleteClientAsync(int id);

    }
}
