using fgk.Application.Interfaces;
using fgk.Core.Abstractions;
using fgk.Core.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Cryptography;
using System.Text;

namespace fgk.Application.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountsRepository _accountsRepository;
        private readonly IPasswordHasher<Account> _passwordHasher;
        private readonly IJwtTokenService _tokenService;

        public AccountService
            (IAccountsRepository accountsRepository,
             IPasswordHasher<Account> passwordHasher,
             IJwtTokenService tokenService)
        {   
            _accountsRepository = accountsRepository;
            _passwordHasher = passwordHasher;
            _tokenService = tokenService;
        }

        public async Task<string?> LogInAsync(string? email, string? password)
        {
            if (email is null || password is null)
            {
                return null;
            }

            var account = await _accountsRepository.GetByEmailAsync(email);

            if (account is null)
            {
                return null;
            }

            return _passwordHasher.VerifyHashedPassword(account, account.Password, password)
                is PasswordVerificationResult.Failed ? null :
                _tokenService.Generate(account);
        }

        public async Task<string?> CreateAccountAsync(string? email, string? username, string? password)
        {
            if (email is null ||
                username is null ||
                password is null) 
            {
                return null;    
            }

            if (await _accountsRepository.ContainsThisEmailOrUsername(email, username))
            {
                return null;
            }

            var account = new Account(email, username);
            var hashed = _passwordHasher.HashPassword(account, password);
            account.ChangePassword(hashed);

            await _accountsRepository.AddAsync(account);
            return _tokenService.Generate(account);
        }

        public async Task<Account?> GetByIdAsync(string id)
        {
            return await _accountsRepository.GetByIdAsync(Convert.ToInt32(id));
        }

        public async Task<Account?> LikeMovieAsync(Account account, Movie movie)
        {
            var id = BitConverter.ToInt32(SHA256.HashData(
                Encoding.UTF8.GetBytes(
                    new StringBuilder()
                        .Append(account.Username)
                        .Append(movie.Title)
                        .ToString())));

            var like = new MovieLike(id, DateTime.UtcNow, movie.Id, account);
            account.Like(like);

            await _accountsRepository.AddLikeAsync(account, like);

            return await _accountsRepository.GetByIdAsync(account.Id);
        }

        public async Task<Account?> UnlikeMovieAsync(Account account, Movie movie)
        {
            var id = BitConverter.ToInt32(SHA256.HashData(
                Encoding.UTF8.GetBytes(
                    new StringBuilder()
                        .Append(account.Username)
                        .Append(movie.Title)
                        .ToString())));

            var like = account.Likes?
                .FirstOrDefault(lk => lk.TargetId == movie.Id);

            if (like is null)
            {
                Console.WriteLine("Something Went Wrong");
                return account;
            }

            account.Unlike(like);
            await _accountsRepository.RemoveLikeAsync(account, like);

            return await _accountsRepository.GetByIdAsync(account.Id);
        }
    }
}
