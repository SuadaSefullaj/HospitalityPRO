using DTO;
using Hangfire;
using HumanResourceProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ClientService
{
    public class ClientService : IClientService
    {

        private readonly HospitalityPRO_DbContext _dbContext;
        private readonly PasswordService _passwordService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ClientService(IHttpContextAccessor httpContextAccessor, HospitalityPRO_DbContext dbContext, PasswordService passwordService)
        {
            _httpContextAccessor = httpContextAccessor;
            _dbContext = dbContext;
            _passwordService = passwordService;
        }
        public string GetMyName()
        {
            var result = string.Empty;
            if (_httpContextAccessor.HttpContext != null)
            {
                result = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Email);
            }
            return result;
        }


        //----------------------------------------------------------------------REGISTER CLIENT-----------------------------------------------------------------------------
        public async Task<Client> RegisterClientAsync(ClientRegistrationDTO request)
        {

            // Create password hash
            _passwordService.CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);

            // Create a new Client instance
            var client = new Client
            {
                Name = request.Name,
                Surname = request.Surname,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt
            };

            // Add the new client to the database
            _dbContext.Clients.Add(client);
            await _dbContext.SaveChangesAsync();

            return client;
        }

        //---------------------------------------------------------------------------REGISER_ADMIN-----------------------------------------------------------------------------------
        public async Task<Client> RegisterAdminAsync(ClientRegistrationDTO request)
        {
            // Check if the email is already registered
            if (await IsEmailRegisteredAsync(request.Email))
            {
                throw new Exception("Email is already registered.");
            }
            _passwordService.CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);
           
            var admin = new Client
            {
                Name = request.Name,
                Surname = request.Surname,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
                Role = "Admin", 
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt
            };

            // Add the new admin to the database
            _dbContext.Clients.Add(admin);
            await _dbContext.SaveChangesAsync();

            return admin;
        }
        private async Task<bool> IsEmailRegisteredAsync(string email)
        {
            return await _dbContext.Clients.AnyAsync(c => c.Email == email);
        }
        //----------------------------------------------------------------------------LOGIN-------------------------------------------------------------------------------------

        public async Task<Client> AuthenticateClientAsync(string email, string password)
        {
            // Retrieve client from database by email
            var client = await _dbContext.Clients.FirstOrDefaultAsync(c => c.Email == email);

            if (client == null)
            {
                // Client with the provided email doesn't exist
                return null;
            }

            // Verify the password using PasswordService
            if (!_passwordService.VerifyPasswordHash(password, client.PasswordHash, client.PasswordSalt))
            {
                // Password doesn't match
                return null;
            }

            // Update the LastLogin attribute
            client.LastLogin = DateTime.Now;
            await _dbContext.SaveChangesAsync();

            // Authentication successful
            return client;
        }

       //---------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        public async Task<IEnumerable<Client>> GetClientsAsync()
        {
            return await _dbContext.Clients.ToListAsync();
        }



        public async Task<Client> GetClientByIdAsync(int id)
        {
            return await _dbContext.Clients.FindAsync(id);
        }

        public async Task<Client> AddClientAsync(Client client)
        {
            _dbContext.Clients.Add(client);
            await _dbContext.SaveChangesAsync();
            return client;
        }

        public async Task DeleteClientAsync(int id)
        {
            var client = await _dbContext.Clients.FindAsync(id);
            if (client != null)
            {
                _dbContext.Clients.Remove(client);
                await _dbContext.SaveChangesAsync();
            }
        }

      
    }
}