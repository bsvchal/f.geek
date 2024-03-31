using fgk.Application.Interfaces;
using fgk.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace fgk.UI.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IJwtTokenService _tokenService;
        private readonly IAccountService _accountService;

        public Account? Account { get; set; }
        public IndexModel(ILogger<IndexModel> logger, IJwtTokenService tokenService, IAccountService accountService)
        {
            _logger = logger;
            _tokenService = tokenService;
            _accountService = accountService;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            if (HttpContext.Request.Cookies.ContainsKey("gazz"))
            {
                var token = HttpContext.Request.Cookies["gazz"];
                var id = _tokenService.Decode(token!).FirstOrDefault(item => item.Type == "id")!.Value;

                Account = await _accountService.GetByIdAsync(id);
            }

            return Page();
        }
    }
}
