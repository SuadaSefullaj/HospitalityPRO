using AutoMapper;
using Domain.ClientService;
using DTO;
using Entities.Models;
using Helpers;
using HumanResourceProject.Models;
using LamarCodeGeneration.Frames;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        public static Client client = new Client();
        private readonly IConfiguration _configuration; //it's used to retrieve the token secret key from the configuration, which is then used to generate JWT tokens for authentication purposes.
        private readonly IClientService _clientService;
        private readonly TokenService _tokenService;
        private readonly PasswordService _passwordService;
        private readonly IMapper _mapper;

        public AuthController(IConfiguration configuration, IClientService clientService, TokenService tokenService, PasswordService passwordService, IMapper mapper)
        {
            _configuration = configuration;
            _clientService = clientService;
            _tokenService = tokenService;
            _passwordService = passwordService;
            _mapper = mapper;
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
            var newRefreshToken = _tokenService.GenerateRefreshToken();

            // Set refresh token
            _tokenService.SetRefreshToken(HttpContext, client, newRefreshToken);

            return Ok(token);

        }

        //----------------------------------------------------------------------REFRESH_TOKEN---------------------------------------------------------------------------------

        [HttpPost("refresh-token")]
        public async Task<ActionResult<string>> RefreshToken()
        {
            var refreshToken = Request.Cookies["refreshToken"];

            if (!client.RefreshToken.Equals(refreshToken))
            {
                return Unauthorized("Invalid Refresh Token.");
            }
            else if (client.TokenExpires < DateTime.Now)
            {
                return Unauthorized("Token expired.");
            }

            string token = _tokenService.CreateToken(client);

            var newRefreshToken = _tokenService.GenerateRefreshToken();

            _tokenService.SetRefreshToken(HttpContext, client,newRefreshToken);

            return Ok(token);
        }

    }
}
