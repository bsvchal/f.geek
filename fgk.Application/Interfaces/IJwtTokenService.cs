using fgk.Core.Models;
using System.Security.Claims;

namespace fgk.Application.Interfaces
{
    public interface IJwtTokenService
    {
        string Generate(Account account);

        IEnumerable<Claim> Decode(string token);
    }
}