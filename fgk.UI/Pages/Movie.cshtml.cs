using fgk.Application.Interfaces;
using fgk.Application.Services;
using fgk.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace fgk.UI.Pages
{
    public class MovieModel : PageModel
    {
        private readonly IMovieService _movieService;
        private readonly IJwtTokenService _tokenService;
        private readonly IAccountService _accountService;

        public Account? Account { get; set; } 
        public Movie? Movie { get; set; }

        public MovieModel(
            IMovieService movieService, 
            IJwtTokenService tokenService,
            IAccountService accountService)
        {
            _movieService = movieService;
            _tokenService = tokenService;
            _accountService = accountService;
        }

        public async Task<IActionResult> OnGetAsync(string? name)
        {
            if (HttpContext.Request.Cookies.ContainsKey("gazz"))
            {
                var token = HttpContext.Request.Cookies["gazz"];
                var id = _tokenService.Decode(token!).FirstOrDefault(item => item.Type == "id")!.Value;

                Account = await _accountService.GetByIdAsync(id);
            }

            if (name is not null)
            {
                Movie = await _movieService.GetMovieByTitleQuery(name);
            }

            if (Movie is null)
            {
                return Page();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string? name)
        {
            if (HttpContext.Request.Cookies.ContainsKey("gazz"))
            {
                var token = HttpContext.Request.Cookies["gazz"];
                var id = _tokenService.Decode(token!).FirstOrDefault(item => item.Type == "id")!.Value;

                Account = await _accountService.GetByIdAsync(id);
            }

            if (name is not null)
            {
                Movie = await _movieService.GetMovieByTitleQuery(name);
            }

            if (Movie is null)
            {
                return Page();
            }
            Like();

            return Page();
        }

        public void Like()
        {
            if (Movie is not null &&
                Account is not null)
            {
                Account = _accountService.LikeMovieAsync(Account, Movie).Result;
                Movie = _movieService.LikeMovieAsync(Movie).Result;
            }
        }

        public bool Liked()
        {
            if (Movie is not null &&
                Account is not null)
            {
                return Account.Likes!.FirstOrDefault(lk => lk.TargetId == Movie.Id) is not null;
            }

            return false;
        }
    }
}
