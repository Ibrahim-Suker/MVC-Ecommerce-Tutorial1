using Microsoft.AspNetCore.Identity;

namespace Ecommerce.Models
{
    public class Order
    {
        public int Id { get; set; }

        public string UserId { get; set; } // User ID to associate the order with a specific user
        public ApplicationUser User { get; set; } // Navigation property to the user

        public int AddressId { get; set; } // Address ID to associate the order with a specific address
        public Address Address { get; set; } // Navigation property to the address

        public double Amount { get; set; } // Total amount of the order
        public string status { get; set; } // Status of the order (e.g., Pending, Completed, Cancelled)
        public DateTime CreatedAt { get; set; } 

        public List<OrderProduct> OrderProducts { get; set; } // List of products in the order
    }
}
