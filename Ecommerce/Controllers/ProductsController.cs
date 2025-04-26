using Ecommerce.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Ecommerce.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index(int? categoryid)
        {

            var title = "All Products";

            var products =  _context.Products.AsQueryable();

            if(categoryid != null)
            {
                products = products
                    .Where(p => p.CategoryId == categoryid);

                var cateegory = await _context.Categories.FirstOrDefaultAsync(x => x.Id == categoryid);
                if(cateegory != null)
                {
                    title = $"{cateegory.Name}s";
                }
            }

            var categories = await _context.Categories.ToListAsync();
            ViewBag.Categories = new SelectList(categories,"Id","Name",categoryid);


            ViewBag.Title = title;

            var data = await products
                .ToListAsync();



            return View(data);
        }
        public async Task<IActionResult> Details(int id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }
    }
}
