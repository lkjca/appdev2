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

        public async Task<IActionResult> OnPostUpdateAsync([FromBody] Friend updatedFriend)
        {
            if (updatedFriend == null)
            {
                return new JsonResult(new { success = false, error = "Invalid data" });
            }

            var friend = await context.Friends.FindAsync(updatedFriend.Id);
            if (friend == null)
            {
                return new JsonResult(new { success = false, error = "Friend not found" });
            }

            // Only update if the new values are provided
            if (!string.IsNullOrEmpty(updatedFriend.Name))
                friend.Name = updatedFriend.Name;

            if (updatedFriend.Age > 0)
                friend.Age = updatedFriend.Age;

            context.Friends.Update(friend);
            await context.SaveChangesAsync();

            return new JsonResult(new { success = true });
        }
    }
}