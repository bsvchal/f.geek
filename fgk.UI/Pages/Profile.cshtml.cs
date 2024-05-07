using fgk.Application.Interfaces;
using fgk.Core.Contracts;
using fgk.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace fgk.UI.Pages;
public class ProfileModel : PageModel
{
    private readonly IJwtTokenService _tokenService;
    private readonly IAccountService _accountService;
    private readonly IMovieService _movieService;

    public Account? Account { get; set; }
    public Account? Profile { get; set; }
    public IEnumerable<MovieDisplay> LikedMovies { get; set; } = null!;

    public ProfileModel(
        IJwtTokenService jwtTokenService,
        IAccountService accountService,
        IMovieService movieService)
    {
        _tokenService = jwtTokenService;
        _accountService = accountService;
        _movieService = movieService;
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
            Profile = await _accountService.GetByUsernameAsync(name);

            LikedMovies = Profile!.Likes is null ? [] : await _movieService.GetAllLikedMoviesAsync(Profile.Likes.AsEnumerable(), 5);
        }

        return Page();
    }

    public IActionResult OnPost(string? name)
    {
        HttpContext.Response.Cookies.Delete("gazz");

        return Redirect("/login");
    }
}
