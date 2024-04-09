using fgk.Core.Abstractions;
using fgk.Core.Models;
using fgk.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace fgk.Persistence.Repositories
{
    public class AccountsRepository : IAccountsRepository
    {
        private readonly AccountDbContext dbContext;

        public AccountsRepository(AccountDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Account?> GetByIdAsync(int id)
        {
            var accountEntity = await dbContext.Accounts
                .AsNoTracking()
                .Where(ac => ac.Id == id)
                .Include(ac => ac.Likes)
                .FirstOrDefaultAsync();

            return accountEntity is not null ?
                new Account(id, accountEntity.Email, accountEntity.Username, accountEntity.Password,
                accountEntity.Likes
                    .AsEnumerable()
                    .Select(lk => new MovieLike(lk.Id, lk.LikedDateTime, lk.TargetId, null)))
                : null;
        }

        public async Task<List<Account>> GetAsync()
        {
            return await dbContext.Accounts
                .AsNoTracking()
                .Select(ac => new Account(ac.Id, ac.Email, ac.Username, ac.Password, null))
                .ToListAsync();
        }

        public async Task<Account?> GetByEmailAsync(string email)
        {
            var accountEntity = await dbContext.Accounts
                .AsNoTracking()
                .Where(ac => ac.Email == email)
                .Include(ac => ac.Likes)
                .FirstOrDefaultAsync();

            return accountEntity is not null ?
                new Account(accountEntity.Id, accountEntity.Email, accountEntity.Username, accountEntity.Password,
                accountEntity.Likes
                    .AsEnumerable()
                    .Select(lk => new MovieLike(lk.Id, lk.LikedDateTime, lk.TargetId, null)))
                : null;
        }
         
        public async Task<bool> ContainsThisEmailOrUsername(string email, string username)
        {
            return await dbContext.Accounts
                .AsNoTracking()
                .FirstOrDefaultAsync(ac => ac.Email == email ||
                                           ac.Username == username)
                is not null;
        }

        public async Task AddAsync(Account account)
        {
            var entity = new AccountEntity
            {
                Id = account.Id,
                Email = account.Email,
                Username = account.Username,
                Password = account.Password
            };

            await dbContext.Accounts.AddAsync(entity);
            await dbContext.SaveChangesAsync();
        }

        public async Task AddLikeAsync(Account account, MovieLike newLike)
        {
            await dbContext.MovieLikes.AddAsync(new()
            {
                Id = newLike.Id,
                LikedDateTime = newLike.LikedDateTime,
                TargetId = newLike.TargetId,
                AccountId = account.Id,
            });

            await dbContext.SaveChangesAsync(); 
        }

        public async Task RemoveLikeAsync(Account account, MovieLike like)
        {
            dbContext.MovieLikes.Remove(new()
            {
                Id = like.Id,
                LikedDateTime = like.LikedDateTime,
                TargetId = like.TargetId,
                AccountId = account.Id,
            });

            await dbContext.SaveChangesAsync();
        }
    }
}
