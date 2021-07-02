using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using talycapglobalPrueba.Core.DTO;
using talycapglobalPrueba.Core.Interfaces.Services;
using talycapglobalPrueba.Infraestructure.Model;

namespace talycapglobalPrueba.Infraestructure.Services
{
    public class TokenService : ITokenService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IConfiguration _configuration;
        public TokenService(UserManager<ApplicationUser> userManager,
                           SignInManager<ApplicationUser> signInManager,
                           IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }
        public async Task<bool> IsValidUser(string userName, string password)
        {
            ApplicationUser user = await _userManager.FindByEmailAsync(userName);
            if (user == null)
            {
                return false;
            }

            var singIdentity = await _signInManager.PasswordSignInAsync(userName, password, true, false);
            return singIdentity.Succeeded;
        }
        public async Task<string> Authenticate(TokenAuthDTO toeknCredential)
        {
            if (await IsValidUser(toeknCredential.UserName, toeknCredential.Password))
            {
                ApplicationUser user = await _userManager.FindByEmailAsync(toeknCredential.UserName);
                var secretKey = _configuration["token:secret"];
                var key = Encoding.ASCII.GetBytes(secretKey);

                var claims = new ClaimsIdentity();
                claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.Id));
                claims.AddClaim(new Claim(ClaimTypes.Email, user.Email));

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = claims,
                    Expires = DateTime.UtcNow.AddDays(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var tokenHandler = new JwtSecurityTokenHandler();
                var createdToken = tokenHandler.CreateToken(tokenDescriptor);
                return tokenHandler.WriteToken(createdToken);
            }
            else
                return null;
        }
    }
}
