using fgk.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace fgk.UI.Pages
{
    public class LoginModel : PageModel
    {
        private readonly IAccountService _accountService;
        public string RegistrationErrorMessage { get; private set; } = string.Empty;
        public string AuthorizationErrorMessage { get; private set; } = string.Empty;

        public LoginModel(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public async Task<IActionResult> OnPostAsync(
            string? registrationEmail,
            string? registrationUsername,
            string? registrationPassword,
            string? authorizationEmail,
            string? authorizationPassword)
        {
            string? token;

            if (authorizationEmail is null &&
                authorizationPassword is null) 
            {
                token = await _accountService.CreateAccountAsync
                    (registrationEmail, registrationUsername, registrationPassword);
            }
            else
            {
                token = await _accountService.LogInAsync
                    (authorizationEmail, authorizationPassword);
            }

            if (token is null)
            {
                return Page();
            }

            HttpContext.Response.Cookies.Append("gazz", token);

            return Redirect("/");
        }
        
    }
}
