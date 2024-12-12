using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace TodoApp.Pages.Account
{
    public class RegisterModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public RegisterModel(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [BindProperty]
        [StringLength(30, MinimumLength = 5, ErrorMessage = "Username must be between 5 and 30 characters long.")]
        [RegularExpression(@"^[a-zA-Z0-9_]+$", ErrorMessage = "Username can only contain letters, numbers, and underscores.")]
        public string Username { get; set; }= string.Empty;

        [BindProperty]
        [EmailAddress]
        [Required]
        public string Email { get; set; }= string.Empty;

        [BindProperty]
        [Required]
        [DataType(DataType.Password)]
        [StringLength(100, MinimumLength = 8, ErrorMessage = "Password must be at least 8 characters long.")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[\W_]).+$", ErrorMessage = "Password must contain at least one uppercase letter, one lowercase letter, one number, and one non-alphanumeric character.")]
        public string? Password { get; set; }

        [BindProperty]
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; } = string.Empty;

        public async Task<IActionResult> OnPostAsync()
        {
            // check if they match
            if (Password != ConfirmPassword)
            {
                ModelState.AddModelError(string.Empty, "Passwords do not match.");
                return Page();
            }

            // check validation
            if (Password == null || !IsPasswordStrong(Password))
            {
                ModelState.AddModelError(string.Empty, "Password must contain at least one uppercase letter, one lowercase letter, one digit, and one special character.");
                return Page();
            }

            // create user
            var user = new IdentityUser { UserName = Username, Email = Email };
            var result = await _userManager.CreateAsync(user, Password);

            if (result.Succeeded)
            {
                // sign in user
                await _signInManager.SignInAsync(user, isPersistent: false);
                return RedirectToPage("/Index"); // redirect to home page
            }

            // if failed, show errors
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            return Page();
        }

        // check if password is strong
        private bool IsPasswordStrong(string password)
        {
            var hasUpperCase = false;
            var hasLowerCase = false;
            var hasDigit = false;
            var hasSpecialChar = false;

            if (password.Length >= 8)
            {
                foreach (var c in password)
                {
                    if (char.IsUpper(c)) hasUpperCase = true;
                    else if (char.IsLower(c)) hasLowerCase = true;
                    else if (char.IsDigit(c)) hasDigit = true;
                    else if (!char.IsLetterOrDigit(c)) hasSpecialChar = true;
                }
            }

            return hasUpperCase && hasLowerCase && hasDigit && hasSpecialChar;
        }
    }
}