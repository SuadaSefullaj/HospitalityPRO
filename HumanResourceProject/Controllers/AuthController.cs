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

        public AuthController(IConfiguration configuration, IClientService clientService, TokenService tokenService)
        {
            _configuration = configuration;
            _clientService = clientService;
            _tokenService = tokenService;
        }

        [HttpGet, Authorize(Roles ="Admin")]
        public ActionResult<string> GetMe()
        {
            var Email = _clientService.GetMyName();
            return Ok(Email);
        }


        //----------------------------------------------------------------------REGISTER---------------------------------------------------------------------------------

        [HttpPost("register")]
        public async Task<ActionResult<Client>> Register(ClientRegistrationDTO request)
        {
            // Input validation
            if (string.IsNullOrWhiteSpace(request.Password))
            {
                return BadRequest("Password is required.");
            }

            // Call the client service to register the client
            var client = await _clientService.RegisterClientAsync(request);
            string token = _tokenService.CreateToken(client);
            return Ok(client); //or token Im not sure
        }

        //-------------------------------------------------------------------END-----------------------------------------------------------------------------------------------------

        [HttpPost("register-admin"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<Client>> RegisterAdmin(ClientRegistrationDTO request)
        {
            // Check if the current user is an admin
            var currentUser = HttpContext.User;
            if (currentUser == null || !currentUser.IsInRole("Admin"))
            {
                return Forbid(); // User is not authorized to register an admin
            }

            // Mock registration for admin (without updating the database)
            var admin = new Client
            {
                Name = request.Name,
                Surname = request.Surname,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
               Role="Admin"
            };

            // Return the mocked admin data
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

            _tokenService.SetRefreshToken(HttpContext, client, newRefreshToken);

            return Ok(token);
        }


    }
}
