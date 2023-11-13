using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RegisterLoginJWT.Data.Repositories.Interfaces;
using RegisterLoginJWT.Model;
using RegisterLoginJWT.Model.DTOs;
using RegisterLoginJWT.Service.Interfaces;
using RegisterLoginJWT.Util;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace RegisterLoginJWT.Service
{
    public class LoginServices : ILoginServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public LoginServices(IUnitOfWork unitOfWork, IMapper mapper, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _configuration = configuration;
        }

        public async Task<LoginResultDTO> Execute(string userName, string password)
        {
            var passwordEncrypted = Encrypt.GetSHA256(password);
            var user = await _unitOfWork.UserRepository.Get(userName, passwordEncrypted);
            var token = GenerateJwtToken(user);
            var loginResultDTO = new LoginResultDTO()
            {
                Id = user.Id,
                Username = user.UserName,
                Password = user.Password,
                Token = token
            };

            return loginResultDTO;    
        }
        private string GenerateJwtToken(User user)
        {
            var key = Encoding.UTF8.GetBytes(_configuration["Jwt:Secret"]);
            var securityKey = new SymmetricSecurityKey(key);
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: null,
                audience: null,
                claims: new List<Claim>
                {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UserName),
                },
                expires: DateTime.UtcNow.AddMinutes(1),  
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}