using ESHOP.Models;

namespace ESHOP.Repositories
{
    public interface IUserOrderRepository
    {
        Task<IEnumerable<Order>> UserOrders();
        Task<IEnumerable<Order>> AllUserOrders(); 
    }
}