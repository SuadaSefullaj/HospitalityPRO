﻿using DTO;
using HumanResourceProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts
{
    public interface IClientService
    {
        Task<Client> RegisterClientAsync(ClientRegistrationDTO request);
        Task<Client> AuthenticateClientAsync(string email, string password);
        Task<Client> RegisterAdminAsync(ClientRegistrationDTO request);

    }
}
