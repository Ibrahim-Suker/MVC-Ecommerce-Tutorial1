using Ecommerce.Data;
using Ecommerce.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Ecommerce.Controllers
{
    public class CheckoutController : Controller
    {
        public readonly ApplicationDbContext _context;
        public readonly UserManager<ApplicationUser> _userManager;
        public CheckoutController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var currentuser = await _userManager.GetUserAsync(HttpContext.User);

            var addresses = await _context.Addresses
                .Include(a => a.User)
                .Where(a => a.UserId == currentuser.Id)
                .ToListAsync();

            ViewBag.Addresses = addresses; 
            return View();
        }

        public async Task<IActionResult> Confirm(int addressId)
        {
            var address = await _context.Addresses
                .Where(a => a.Id == addressId)
                .FirstOrDefaultAsync();
            if (address == null)
            {
                return BadRequest();
            }

            var currentuser = await _userManager.GetUserAsync(HttpContext.User);

            double orderCost = 0;

            var carts = await _context.Carts
                .Include(c => c.Product)
                .Where(c => c.UserId == currentuser.Id)
                .ToListAsync();

            foreach (var cart in carts)
            {
                orderCost += cart.Product.Price * cart.Qty;
            }

                var order = new Order
            {
                AddressId = address.Id,
                CreatedAt = DateTime.Now,
                status = "Order Placed",
                UserId = address.UserId,
                Amount = orderCost // Set the amount based on your logic
            };

            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            foreach (var cart in carts)
            {
                var orderProduct = new OrderProduct
                {
                    OrderId = order.Id,
                    ProductId = cart.ProductId,
                    Price = cart.Product.Price,
                    Qty = cart.Qty
                };
                _context.Add(orderProduct);
            }
            await _context.SaveChangesAsync();

            return RedirectToAction("ThankYou");
        }

        [HttpPost]
        public async Task<IActionResult> Index(Address address)
        {
            if (ModelState.IsValid)
            {
                var currentuser = await _userManager.GetUserAsync(HttpContext.User);

                address.UserId = currentuser.Id;
                _context.Addresses.Add(address);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            return View(address);
        }


    }
}
