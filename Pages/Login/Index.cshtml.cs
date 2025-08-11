using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;
using LojistaPro.Models.Domain;

namespace LojistaPro.Pages.Login;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly SignInManager<AuthUser> _signInManager;

    public IndexModel(SignInManager<AuthUser> signInManager, ILogger<IndexModel> logger)
    {
        _signInManager = signInManager;
        _logger = logger;
    }

    [BindProperty]
    public InputModel Input { get; set; } = new();

    public class InputModel
    {
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        var result = await _signInManager.PasswordSignInAsync(Input.UserName, Input.Password, false, false);

        if (result.Succeeded)
        {
            return RedirectToPage("/Index");
        }
        else
        {
            ModelState.AddModelError(string.Empty, "Tentativa de login inválida.");
            return Page();
        }
    }
}
