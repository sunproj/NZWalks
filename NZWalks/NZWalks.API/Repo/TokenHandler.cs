using Microsoft.IdentityModel.Tokens;
using NZWalks.API.Models.Domain;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace NZWalks.API.Repo
{
    public class TokenHandler : ITokenhandler
    {
        private readonly IConfiguration configuration;

        public TokenHandler(IConfiguration _configuration)
        {
            configuration = _configuration;
        }

        public Task<string> CreatTokenAsync(User user)
        {
            // Create a Claims

            var Claims = new List<Claim>();

            Claims.Add(new Claim(ClaimTypes.GivenName, user.FirstName));
            Claims.Add(new Claim(ClaimTypes.Surname, user.LastName));
            Claims.Add(new Claim(ClaimTypes.Email, user.Email));

            // Loops for Role
            user.Roles.ForEach((role) =>
            {
                Claims.Add(new Claim(ClaimTypes.Role, role));
            }
            );

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                configuration["Jwt:Issuer"],
                configuration["Jwt:Audience"],
                Claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: credentials);

            return Task.FromResult(new JwtSecurityTokenHandler().WriteToken(token));

        }
    }
}
