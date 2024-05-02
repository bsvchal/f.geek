using fgk.Application.Interfaces;
using fgk.Application.Services;
using fgk.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Xml.Linq;

namespace fgk.UI.Pages
{
    public class SearchModel : PageModel
    {
        private readonly IMovieService _movieService;
        private readonly IJwtTokenService _tokenService;
        private readonly IAccountService _accountService;

        public string? Username { get; private set; } = string.Empty;
        public List<Movie> SearchingResult { get; private set; } = [];

        public SearchModel(
            IMovieService movieService,
            IJwtTokenService tokenService,
            IAccountService accountService)
        {
            _movieService = movieService;
            _tokenService = tokenService;
            _accountService = accountService;
        }

        public async Task<IActionResult> OnGetAsync(string? q)
        {
            if (HttpContext.Request.Cookies.ContainsKey("gazz"))
            {
                var token = HttpContext.Request.Cookies["gazz"];
                var id = _tokenService.Decode(token!).FirstOrDefault(item => item.Type == "id")!.Value;

                Username = (await _accountService.GetByIdAsync(id))?.Username;
            }
            
            if (q is not null)
            {
                SearchingResult = (await _movieService.GetMoviesByTitle(q))
                    .OrderBy(item => item.LikesAmount)
                    .Reverse()
                    .ToList();
            }

            return Page();
        }
    }
}
