using AutoMapper;
using DAL.Contracts;
using DAL.UoW;
using Domain.Contracts;
using DTO;
using DTO.UserDTO;
using Entities.Models;
using Helpers;
using HumanResourceProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Concrete
{
    public class ClientService : DomainBase, IClientService
    {
        private readonly HospitalityPRO_DbContext _dbContext;
        private IClientRepository clientRepository => _unitOfWork.GetRepository<IClientRepository>();
        protected readonly PasswordService _passwordService;

        public ClientService(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor, PasswordService passwordService, HospitalityPRO_DbContext dbContext) : base(unitOfWork, mapper, httpContextAccessor)
        {
            _passwordService = passwordService;
            _dbContext = dbContext;
        }

     
  //----------------------------------------------------------------------REGISTER CLIENT-----------------------------------------------------------------------------
            public async Task<Client> RegisterClientAsync(ClientRegistrationDTO request)
        {
            if (_dbContext.Clients.Any(c => c.Email == request.Email))
            {
                throw new InvalidOperationException("An account with this email already exists.");

            }

            var client = _mapper.Map<Client>(request);
            _passwordService.CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);

            client.PasswordHash = passwordHash;
            client.PasswordSalt = passwordSalt;

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
            if (request.Password.Length < 8)
            {
                throw new InvalidOperationException("Password must be at least 8 characters long.");
            }
            var admin = _mapper.Map<Client>(request);
            admin.Role = "Admin";
            _passwordService.CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);
            admin.PasswordHash = passwordHash;
            admin.PasswordSalt = passwordSalt;

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
                throw new Exception("Client with the provided email does not exist");
            }

   
            if (!_passwordService.VerifyPasswordHash(password, client.PasswordHash, client.PasswordSalt))
            {
                throw new Exception("Password doesn't match");
            }

            client.LastLogin = DateTime.Now;
            await _dbContext.SaveChangesAsync();

            return client;
        }


    }
}
