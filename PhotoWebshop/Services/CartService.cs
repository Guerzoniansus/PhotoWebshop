using Microsoft.AspNetCore.Http;
using PhotoWebshop.Data;
using PhotoWebshop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace PhotoWebshop.Services
{
    public class CartService
    {
        private PhotoWebshopDatabaseContext db;

        // Not using comma's becausde titles might include titles
        // This is still a bad solution but I dont have much time
        private const string SplitCharacter = ">";

        public CartService(PhotoWebshopDatabaseContext db)
        {
            this.db = db;
        }

        /// <summary>
        /// Add a product to the cart. Does not currently automatically refresh the HTML.
        /// </summary>
        /// <param name="context">The HttpContext object to use for session management.</param>
        /// <param name="productTitle">The title of the product to add to the cart.</param>
        public void AddToCart(HttpContext context, string productTitle)
        {    

            // Validation to check if some kind of hackerman used inspect element to add a non-existent product
            if (db.Products.Any(product => product.Title == productTitle) == false)
            {
                return;
            }

            if (string.IsNullOrEmpty(context.Session.GetString("cart"))) {
                context.Session.SetString("cart", "");
            }

            string newCart = GetCartAsString(context) + SplitCharacter + productTitle;
            context.Session.SetString("cart", newCart);
        }

        /// <summary>
        /// Get a specific product.
        /// </summary>
        /// <param name="productTitle">The name of the product to get from the database.</param>
        /// <returns>The product, or null if the product does not exist.</returns>
        public Product GetProduct(string productTitle)
        {
           
            return db.Products.Find(productTitle);
        }

        /// <summary>
        /// Get all products currently in the shopping cart.
        /// </summary>
        /// <param name="context">The HttpContext object to use to read session management from.</param>
        /// <returns>A list of all products in the cart. Returns an empty list if the cart is empty or if the cart is filled with objects that do not exist in the database.</returns>
        public List<Product> GetProducts(HttpContext context)
        {
            List<Product> products = new List<Product>();

            if (!string.IsNullOrEmpty(context.Session.GetString("cart")))
            {
                // The cart is a single string of products, separated by SplitCharacter
                string[] productNames = GetCartAsString(context).Split(SplitCharacter);

                return db.Products.Where(p => productNames.Contains(p.Title)).ToList();
            }

            return products;
        }

        /// <summary>
        /// Gets the products currently in the card.
        /// </summary>
        /// <param name="context">The HttpContext object to use for session management.</param>
        /// <returns>All products as a single string, separated by commma's. Returns an empty string if the cart is empty.</returns>
        public string GetCartAsString(HttpContext context)
        {
            string cartString = context.Session.GetString("cart");

            if (cartString != null)
            {
                return cartString;
            }

            else return "";
        }

        /// <summary>
        /// Returns the amount of items in the cart. 
        /// </summary>
        /// <param name="context">The HttpContext to use to access essoin management.</param>
        /// <returns>The amount of items in the cart. </returns>
        public int GetCartCount(HttpContext context)
        {
            // No need to do database lookup for this
            return GetCartAsString(context).Split(SplitCharacter).Length;
        }


    }
}
