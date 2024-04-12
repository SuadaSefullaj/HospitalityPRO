using AutoMapper;
using Domain.Contracts;
using DTO;
using Helpers;
using HumanResourceProject.Models;
using LamarCodeGeneration.Frames;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;


namespace HumanResourceProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public static Client client = new();
        private readonly IClientService _clientService;
        private readonly TokenService _tokenService;
        private readonly IMapper _mapper;
        private readonly HospitalityPRO_DbContext _dbContext;


        public AuthController(IClientService clientService, TokenService tokenService, IMapper mapper, HospitalityPRO_DbContext dbContext)
        {
            _clientService = clientService;
            _tokenService = tokenService;
            _mapper = mapper;
            _dbContext = dbContext;
        }

        //----------------------------------------------------------------------REGISTER---------------------------------------------------------------------------------

        [HttpPost("register")]
        public async Task<ActionResult<Client>> Register(ClientRegistrationDTO request)
        {
            var client = await _clientService.RegisterClientAsync(_mapper.Map<ClientRegistrationDTO>(request));
            return Ok(client); 
        }

        //-------------------------------------------------------------------REGISTER_ADMIN-----------------------------------------------------------------------------------------------------

        [HttpPost("register-admin")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<Client>> RegisterAdmin(ClientRegistrationDTO request)
        {
            var admin = await _clientService.RegisterAdminAsync(_mapper.Map<ClientRegistrationDTO>(request));
            return Ok(admin);
        }

        //----------------------------------------------------------------------LOGIN---------------------------------------------------------------------------------

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(ClientLoginDTO request)
        {

            // Authenticated client
   
            var client = await _clientService.AuthenticateClientAsync(request.Email, request.Password);

            if (client == null)
            {
                return Unauthorized("Invalid email or password.");
            }


            // Generate token
            string token = _tokenService.CreateToken(client);

            // Generate refresh token
            var newRefreshToken = TokenService.GenerateRefreshToken();

            // Set the client's ID on the refresh token
            newRefreshToken.ClientId = client.ClientId;

            // Set refresh token
            _tokenService.SetRefreshToken(HttpContext, client, newRefreshToken);

            return Ok(new
            {
                AccessToken = token,
                RefreshToken = newRefreshToken.Token
            });
        }

        //----------------------------------------------------------------------REFRESH_TOKEN---------------------------------------------------------------------------------
        [HttpPost("refresh-token")]
        public async Task<ActionResult<string>> RefreshToken()
        {
            var refreshToken = Request.Cookies["refreshToken"];

            var refreshTokenEntity = await _dbContext.RefreshTokens.FirstOrDefaultAsync(rt => rt.Token == refreshToken);

            if (refreshTokenEntity == null)
            {
                return Unauthorized("Invalid Refresh Token.");
            }
            else if (refreshTokenEntity.Expires < DateTime.Now)
            {
                return Unauthorized("Refresh token expired.");
            }

            var client = await _dbContext.Clients.FindAsync(refreshTokenEntity.ClientId);
            if (client == null)
            {
                return Unauthorized("Client not found.");
            }

            string token = _tokenService.CreateToken(client);

            return Ok(token);
        }

    }
}
