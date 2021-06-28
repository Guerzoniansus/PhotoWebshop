using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PhotoWebshop.Data;
using PhotoWebshop.Models;

namespace PhotoWebshop.Pages
{
    public class ProductModel : PageModel
    {
        private PhotoWebshopDatabaseContext db;

        public Product Product { get; set; }

        public ProductModel(PhotoWebshopDatabaseContext db)
        {
            this.db = db;
        }

        public void OnGet(string productTitle)
        {
            Console.WriteLine(productTitle);
            this.Product = db.Products.Find(productTitle);
        }
    }
}
