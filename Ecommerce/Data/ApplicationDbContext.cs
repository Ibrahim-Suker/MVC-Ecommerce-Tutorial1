using Ecommerce.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Cart> Carts { get; set; } // Cart table
        public DbSet<Address> Addresses { get; set; } // Address table
        public DbSet<Order> Orders { get; set; } // Order table
        public DbSet<OrderProduct> OrderProducts { get; set; } // OrderProduct table
        public DbSet<Category> Categories { get; set; } // Wishlist table
        public DbSet<SliderImage> SliderImageS { get; set; } // Wishlist table

    }
}
