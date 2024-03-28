using AutoMapper;
using DTO;
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
        private readonly IMapper _mapper;

        public ClientService(IHttpContextAccessor httpContextAccessor, HospitalityPRO_DbContext dbContext, PasswordService passwordService, IMapper mapper)
        {
            _httpContextAccessor = httpContextAccessor;
            _dbContext = dbContext;
            _passwordService = passwordService;
            _mapper = mapper;
        }
        //----------------------------------------------------------------------REGISTER CLIENT-----------------------------------------------------------------------------
        public async Task<Client> RegisterClientAsync(ClientRegistrationDTO request)
        {
            if (_dbContext.Clients.Any(c => c.Email == request.Email))
            {
                throw new InvalidOperationException("An account with this email already exists.");
              
            }
            // Check if the user is under 18
            var underage = DateTime.Today.AddYears(-18);
            if (request.Birth > underage)
            {
                throw new InvalidOperationException("You must be at least 18 years old to create an account.");
            }


            var client = _mapper.Map<Client>(request);
            _passwordService.CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);

            client.PasswordHash = passwordHash;
            client.PasswordSalt = passwordSalt;

            // Add the new client to the database
            _dbContext.Clients.Add(client);
            await _dbContext.SaveChangesAsync();

            return client;
        }

        //---------------------------------------------------------------------------REGISER_ADMIN-----------------------------------------------------------------------------------
        public async Task<Client> RegisterAdminAsync(ClientRegistrationDTO request)
        {
            if (await IsEmailRegisteredAsync(request.Email))
            {
                throw new Exception("Email is already registered.");
            }
            var admin = _mapper.Map<Client>(request);
            admin.Role = "Admin";
            _passwordService.CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);
            admin.PasswordHash = passwordHash;
            admin.PasswordSalt = passwordSalt;

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
          
            var client = await _dbContext.Clients.FirstOrDefaultAsync(c => c.Email == email);

            if (client == null)
            {
                return null; // Client with the provided email does not exist
            }

            // Verify the password using PasswordService
            if (!_passwordService.VerifyPasswordHash(password, client.PasswordHash, client.PasswordSalt))
            {
                return null; // Password doesn't match
            }

            // Update the LastLogin attribute
            client.LastLogin = DateTime.Now;
            await _dbContext.SaveChangesAsync();

            return client;
        }

    }
}