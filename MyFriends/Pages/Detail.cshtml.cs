using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyFriends.Data;
using MyFriends.Models;
using System.Linq;

namespace MyFriends.Pages
{
    public class DetailModel : PageModel
    {
        private readonly AppDbContext context;

        public DetailModel(AppDbContext context) => this.context = context;
        [BindProperty(SupportsGet = true)]
        public Friend? Friend { get; set; }
       public async Task OnGetAsync(int Id)
        {
            Friend = await context.Friends.FindAsync(Id);
            if (Friend == null)
            {
                // if not found
                RedirectToPage("/Error");
            }
            
        }
    }
}
