using fgk.Application.Interfaces;
using fgk.Core.Models;
using fgk.Infrastructure.Options;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace fgk.Infrastructure
{
    public class JwtTokenService : IJwtTokenService
    {
        private readonly JwtOptions options;

        public JwtTokenService(JwtOptions options)
        {
            this.options = options;
        }

        public string Generate(Account account)
        {
            Claim[] claims = [new Claim("id", account.Id.ToString())];

            var token = new JwtSecurityToken
                (claims: claims,
                 signingCredentials: new(
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(options.Key)),
                    SecurityAlgorithms.HmacSha256),
                 expires: DateTime.UtcNow.AddHours(options.HoursBeforeExpire));

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public IEnumerable<Claim> Decode(string token)
        {
            return new JwtSecurityTokenHandler().ReadJwtToken(token).Claims;
        }
    }
}
