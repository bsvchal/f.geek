using System.Security.Cryptography;
using System.Text;

namespace fgk.Core.Models
{
    public class Account
    {
        private readonly List<MovieLike>? _likes = [];

        public int Id { get; private set; } = 0;
        public string Email { get; private set;  } = string.Empty;
        public string Username { get; private set; } = string.Empty;
        public string Password { get; private set; } = string.Empty;
        public IReadOnlyList<MovieLike>? Likes { get => _likes?.AsReadOnly(); }

        public Account(string email, string username)
        {
            Id = BitConverter.ToInt32(SHA256.HashData(Encoding.UTF8.GetBytes(username)));
            Email = email;
            Username = username;
            Password = string.Empty;
        }

        public Account(int id, string email, string username,
            string password, IEnumerable<MovieLike>? likes)
        {
            Id = id;
            Email = email;
            Username = username;
            Password = password;
            _likes = likes?.ToList();
        }

        public void ChangePassword(string password)
            => Password = password;
        public void Like(MovieLike entity) 
        {
            _likes?.Add(entity);
        }
        public void Unlike(MovieLike entity) 
        {
            _likes?.Remove(entity);
        }
    }
}
