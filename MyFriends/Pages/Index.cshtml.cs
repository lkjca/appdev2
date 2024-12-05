using MyFriends.Data;
using MyFriends.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
namespace MyFriends.Pages;
public class IndexModel : PageModel
{
    private readonly AppDbContext context;
    public IndexModel(AppDbContext context) =>
        this.context = context;
    
    public List<Friend> Friends { get; set; } = new ();
    public async Task OnGetAsync(int Id) =>
        Friends = await context.Friends.ToListAsync();
}
