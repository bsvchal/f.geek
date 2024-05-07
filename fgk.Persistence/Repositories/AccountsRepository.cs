using AutoMapper;
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
        private readonly AccountDbContext _dbContext;
        private readonly IMapper _mapper;

        public AccountsRepository(AccountDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<Account?> GetByIdAsync(int id)
        {
            var accountEntity = await _dbContext.Accounts
                .AsNoTracking()
                .Where(ac => ac.Id == id)
                .Include(ac => ac.Likes)
                .FirstOrDefaultAsync();

            return accountEntity is not null ? _mapper.Map<Account>(accountEntity) : null;
        }

        public async Task<List<Account>> GetAsync()
        {
            return await _dbContext.Accounts
                .AsNoTracking()
                .Select(ac => new Account(ac.Id, ac.Email, ac.Username, ac.Password, null))
                .ToListAsync();
        }

        public async Task<Account?> GetByEmailAsync(string email)
        {
            var accountEntity = await _dbContext.Accounts
                .AsNoTracking()
                .Where(ac => ac.Email == email)
                .Include(ac => ac.Likes)
                .FirstOrDefaultAsync();

            return accountEntity is not null ? _mapper.Map<Account>(accountEntity) : null;
        }
         
        public async Task<bool> ContainsThisEmailOrUsername(string email, string username)
        {
            return await _dbContext.Accounts
                .AsNoTracking()
                .FirstOrDefaultAsync(ac => ac.Email == email || ac.Username == username) is not null;
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

            await _dbContext.Accounts.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task AddLikeAsync(Account account, MovieLike newLike)
        {
            await _dbContext.MovieLikes.AddAsync(new()
            {
                Id = newLike.Id,
                LikedDateTime = newLike.LikedDateTime,
                TargetId = newLike.TargetId,
                AccountId = account.Id,
            });

            await _dbContext.SaveChangesAsync(); 
        }

        public async Task RemoveLikeAsync(Account account, MovieLike like)
        {
            _dbContext.MovieLikes.Remove(new()
            {
                Id = like.Id,
                LikedDateTime = like.LikedDateTime,
                TargetId = like.TargetId,
                AccountId = account.Id,
            });

            await _dbContext.SaveChangesAsync();
        }

        public async Task<Account?> GetByUsernameAsync(string username)
        {
            var accountEntity = await _dbContext.Accounts
                .AsNoTracking()
                .Where(ac => ac.Username == username)
                .Include(ac => ac.Likes)
                .FirstOrDefaultAsync();

            return accountEntity is not null ? _mapper.Map<Account>(accountEntity) : null;
        }
    }
}
