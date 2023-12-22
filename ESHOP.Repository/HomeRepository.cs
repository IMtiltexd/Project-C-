using ESHOP.Models;
using ESHOP.Repository;
using Microsoft.EntityFrameworkCore;

namespace ESHOP.Repositories
{
    public class HomeRepository : IHomeRepository
    {
        private readonly ApplicationDbContext _db;

        public HomeRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Category>> Categories()
        {
            return await _db.Categories.ToListAsync();
        }
        public async Task<IEnumerable<Manufacturer>> Manufacturers()
        {
            return await _db.Manufacturers.ToListAsync();
        }
        public async Task<IEnumerable<Item>> GetProducts(string sTerm, int categoryId, int manufacturerId)
        {
            // Проверяем, не является ли sTerm null перед вызовом ToLower()
            sTerm = sTerm?.ToLower() ?? "";

            var query = from product in _db.Items
                        join category in _db.Categories on product.CategoryId equals category.Id
                        join manufacturer in _db.Manufacturers on product.ManufacturerId equals manufacturer.Id
                        where string.IsNullOrWhiteSpace(sTerm) || (product != null && product.Title.ToLower().StartsWith(sTerm))
                        select new Item
                        {
                            Id = product.Id,
                            Image = product.Image,
                            Manufacturer = product.Manufacturer,
                            Title = product.Title,
                            CategoryId = product.CategoryId,
                            ManufacturerId = product.ManufacturerId, // Добавляем ManufacturerId
                            Price = product.Price,
                            Category = new Category { Title = category.Title },
                          
                        };

            if (categoryId > 0)
            {
                query = query.Where(a => a.CategoryId == categoryId);
            }

            if (manufacturerId > 0)
            {
                query = query.Where(a => a.ManufacturerId == manufacturerId);
            }

            return await query.ToListAsync();
        }
    }
}