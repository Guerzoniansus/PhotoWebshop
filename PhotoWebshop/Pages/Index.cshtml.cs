using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PhotoWebshop.Data;
using PhotoWebshop.Models;
using PhotoWebshop.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhotoWebshop.Pages
{
    public class IndexModel : PageModel
    {
        private PhotoWebshopDatabaseContext db;
        public CartService CartService { get; }

        // TODO: Change this to using the configuration file, I couldn't get it to work in a fast time
        public readonly string ImagePath = "images/";

        public List<Product> Products { get; set; }

        public IndexModel(PhotoWebshopDatabaseContext db, CartService cartService)
        {
            this.db = db;
            this.CartService = cartService;
        }

        public async Task OnGetAsync()
        {
            Products = await db.Products.ToListAsync();
        }

        public void UpdateCart(string productTitle)
        {
            Console.WriteLine("hey");
            CartService.AddToCart(HttpContext, productTitle);
            Response.Redirect(this.Url.ToString());
        }
    }
}
