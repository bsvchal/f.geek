using fgk.Core.Models;

namespace fgk.Core.Abstractions
{
    public interface IAccountsRepository
    {
        Task AddAsync(Account account);
        Task<List<Account>> GetAsync();
        Task<Account?> GetByEmailAsync(string email);
        Task<Account?> GetByUsernameAsync(string username);
        Task<Account?> GetByIdAsync(int id);
        Task<bool> ContainsThisEmailOrUsername(string email, string username);
        Task AddLikeAsync(Account account, MovieLike newLike);
        Task RemoveLikeAsync(Account account, MovieLike like);
    }
}