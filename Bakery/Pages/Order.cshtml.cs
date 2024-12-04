using System.ComponentModel.DataAnnotations;
using Bakery.Data;
using Bakery.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;
namespace Bakery.Pages;
public class OrderModel : PageModel
{
    private BakeryContext context;
    public OrderModel(BakeryContext context) => 
        this.context = context;
    [BindProperty(SupportsGet = true)]
    public int Id { get; set; }
    public Product? Product { get; set;}

    [BindProperty, Range(1, int.MaxValue, ErrorMessage = "You must order at least one item")]
    public int Quantity { get; set; } = 1;
   // [BindProperty, Required, EmailAddress, Display(Name ="Your Email Address")]
   // public string OrderEmail {get;set;}= string.Empty;
   // [BindProperty, Required, Display(Name ="Shipping Address")]
   // public string ShippingAddress { get; set; }= string.Empty;
    [BindProperty]
    public decimal UnitPrice { get; set; }
    [TempData]
    public string Confirmation { get; set; }= string.Empty;
    public async Task OnGetAsync()   
    {
        Product = await context.Products.FindAsync(Id);
        if (Product != null)
        {
            Product = Product;
        }
    }
    public async Task<IActionResult> OnPostAsync()
    {
    if(ModelState.IsValid)
    {
        /*Basket basket = new ();
        if(Request.Cookies[nameof(Basket)] is not null)
        {
            basket = JsonSerializer.Deserialize<Basket>(Request.Cookies[nameof(Basket)]);
        }
        basket.Items.Add(new OrderItem{
            ProductId = Id, 
            UnitPrice = UnitPrice, 
            Quantity = Quantity
        });
        var json = JsonSerializer.Serialize(basket);*/ /*from tutorial, but has null problem*/

        // initiate a new basket
        Basket basket;
        // check if cookie exists
        var basketCookie = Request.Cookies[nameof(Basket)];
        if (!string.IsNullOrEmpty(basketCookie))
        {
            // if not null, try deserialize
            basket = JsonSerializer.Deserialize<Basket>(basketCookie) ?? new Basket();
        }
        else
        {
            // if null, create new basket
            basket = new Basket();
        }
        // add new order item to basket
        basket.Items.Add(new OrderItem { 
            ProductId = Id, 
            UnitPrice = UnitPrice, 
            Quantity = Quantity
        });
        // serialize updated basket data to json
        var json = JsonSerializer.Serialize(basket);
        // save serialized data to cookie
        Response.Cookies.Append(nameof(Basket), json);
        
        // set expiry time for basket cookie
        var cookieOptions = new CookieOptions
        {
            Expires = DateTime.Now.AddDays(30)
        };
        Response.Cookies.Append(nameof(Basket), json, cookieOptions);
        return RedirectToPage("/Index");
    }
    // if model validation failed, reload product info and return to current page
    Product = await context.Products.FindAsync(Id);
    return Page();
}
}

