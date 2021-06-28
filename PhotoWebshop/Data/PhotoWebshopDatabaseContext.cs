using Microsoft.EntityFrameworkCore;
using PhotoWebshop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhotoWebshop.Data
{
    public class PhotoWebshopDatabaseContext : DbContext
    {
        public PhotoWebshopDatabaseContext(DbContextOptions options) : base(options)
        {
        }

        /// <summary>
        /// The list of products in the database.
        /// </summary>
        public DbSet<Product> Products { get; set; }


    }
}
