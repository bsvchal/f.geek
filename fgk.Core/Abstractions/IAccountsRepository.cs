using fgk.Core.Models;

namespace fgk.Core.Abstractions
{
    public interface IAccountsRepository
    {
        Task AddAsync(Account account);
        Task<List<Account>> GetAsync();
        Task<Account?> GetByEmailAsync(string email);
        Task<Account?> GetByIdAsync(int id);
        Task<bool> ContainsThisEmailOrUsername(string email, string username);
        Task UpdateAccountAndLikesAsync(Account account, MovieLike newLike);
    }
}