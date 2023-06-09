using Backend.Models;

namespace Backend.DAL.Interfaces
{
    public interface IOrderRepository: IDisposable
    {
        Task<IEnumerable<Order>> GetAllAsync();
        Task<Order> GetByIdAsync(int id);
        Task AddOrderAsync(Order order);
        Task DeleteOrderAsync(int id);
        Task UpdateOrderAsync(Order order);
        Task SaveAsync();

    }
}
