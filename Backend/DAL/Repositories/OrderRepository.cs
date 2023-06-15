using Backend.DAL.Interfaces;
using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.DAL.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public OrderRepository(ApplicationDbContext dbContext) => _dbContext = dbContext;

        public async Task<IEnumerable<Order>> GetAllAsync() => await _dbContext.Orders.ToListAsync();

        public async Task<Order> GetByIdAsync(int id)
        {
            var order = await _dbContext.Orders.FindAsync(new object[] { id });
            return order;
        }

        public async Task AddOrderAsync(Order order) => await _dbContext.Orders.AddAsync(order);


        public async Task DeleteOrderAsync(Order order)
        {
           await Task.Run(()=>_dbContext.Orders.Remove(order));
        }

        public async Task UpdateOrderAsync(Order order)
        {
            Order oldOrder = await GetByIdAsync(order.Id);
            oldOrder.SenderСity = order.SenderСity;
            oldOrder.SenderAddres = order.SenderAddres;
            oldOrder.RecipientCity = order.RecipientCity;
            oldOrder.RecipientAddres = order.RecipientAddres;
            oldOrder.WeightCargo = order.WeightCargo;
            oldOrder.PickupDate = order.PickupDate;
        }


        public async Task SaveAsync() => await _dbContext.SaveChangesAsync();
        private bool _disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }
            _disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }


    }
}
