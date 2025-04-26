using System.ComponentModel;

namespace Ecommerce.Models
{
    public class SliderImage
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public string Title { get; set; } //ملهاش لزمه
        [DisplayName("Sort Order")]        
        public int SortOrder { get; set; }
    }
}
