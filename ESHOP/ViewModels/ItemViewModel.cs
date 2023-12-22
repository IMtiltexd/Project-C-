using ESHOP.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace ESHOP.ViewModels
{
    public class ItemViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Availability { get; set; }
        public int Price { get; set; }
        public int CategoryId { get; set; }
        public int ManufacturerId { get; set; }
        public IFormFile ImageFile { get; set; }
        public Category Category { get; internal set; }
        public Manufacturer Manufacturer { get; internal set; }
    }
}
