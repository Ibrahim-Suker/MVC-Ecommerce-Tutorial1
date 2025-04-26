using Ecommerce.Models;

namespace Ecommerce.ViewModels
{
    public class HomeViewModel
    {
        public List<Product> Products { get; set; }
        public List<SliderImage> SliderImages { get; set; }

        public List<Category> Categories { get; set; }
    }
}
