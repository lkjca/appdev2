using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using MyFriends.Data;
using MyFriends.Models;

namespace MyFriends.Pages
{
    public class AddModel : PageModel
    {
        private readonly AppDbContext context;//readonly is similar to final, assign to it once and then can't change it 

        public AddModel(AppDbContext context) => this.context = context;//lamda same as: { this.context = context;}

        [BindProperty]
        public Friend NewFriend { get; set; } = new();

        public void OnGet()
        {
            // Initialize the form when the page is loaded.
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page(); // return to list and show errors
            }
             // check if already exists
            bool exists = context.Friends.Any(f => f.Name == NewFriend.Name && f.Age == NewFriend.Age);

            if (exists)
            {
                ModelState.AddModelError(string.Empty, "A friend with the same name and age already exists.");
                return Page();
            }
            // Add to database
            context.Friends.Add(NewFriend);
            await context.SaveChangesAsync();

            // Redirect to the home page
            return RedirectToPage("/Index");
        }
    }
}
