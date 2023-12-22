using ESHOP.Models;

namespace ESHOP
{
    public interface IHomeRepository
    {
        Task<IEnumerable<Item>> GetProducts(string sterm, int categoryId, int manufacturerId);
        Task<IEnumerable<Category>> Categories();
        Task<IEnumerable<Manufacturer>> Manufacturers();
    }
}