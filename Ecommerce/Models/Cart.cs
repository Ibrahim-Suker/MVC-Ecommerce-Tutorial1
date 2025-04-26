using Microsoft.AspNetCore.Identity;

namespace Ecommerce.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int Qty { get; set; } // Quantity of the product in the cart

        public string UserId { get; set; } // User ID to associate the cart with a specific user
        public ApplicationUser User { get; set; } // Navigation property to the user
    }
}
