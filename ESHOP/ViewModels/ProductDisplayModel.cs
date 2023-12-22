using ESHOP.Models;

namespace ESHOP.ViewModels
{
    public class ProductDisplayModel
    {
        public IEnumerable<Item> Items { get; set; }
        public IEnumerable<Category> Categories  { get; set; }
        public IEnumerable<Manufacturer> Manufacturers { get; set; }
        public string STerm { get; set; } = "";
        public int CategoryId { get; set; } = 0;
        public int ManufacturerId { get; set; }= 0;
    }
}
