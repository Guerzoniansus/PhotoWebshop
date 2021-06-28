using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PhotoWebshop.Models;
using PhotoWebshop.Services;

namespace PhotoWebshop.Pages
{
    public class CartModel : PageModel
    {
        // Using a list for support for multiple products in the future
        public List<Product> Products { get; }

        public CartService CartService { get; }

        public CartModel(CartService cartService)
        {
            this.CartService = cartService;
            this.Products = new List<Product>();
        }

        public void OnGet(string productTitle)
        {
            Product product = CartService.GetProduct(productTitle);

            if (product != null)
            {
                Products.Add(product);
            }
        }

        /// <summary>
        /// Returns the only product currently on the page (assuming the product is valid), otherwise it returns null.
        /// </summary>
        /// <returns>The only product currently on the page (assuming the product is valid), otherwise null.</returns>
        public Product GetProduct()
        {
            // This function is only used right now because I couldn't get a multi-product card working, it's pretty stupid
            // That's why it just returns the first element of a list. There's a list to support multiple products in the future.
            return Products.Count > 0 ? Products.ElementAt(0) : null;
        }
    }
}
