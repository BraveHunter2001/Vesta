using Backend.DAL.Interfaces;
using Backend.DTO;
using Backend.Exceptions;
using Backend.Models;

namespace Backend.Services
{
    public class OrderService
    {

        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<ListOrders> GetAllOrdersAsync()
        {
            var orders = await _orderRepository.GetAllAsync();

            ListOrders ordersList = new ListOrders();
            ordersList.Orders = orders.ToList();
            return ordersList;
        }

        public async Task<Order> GetOrderByIdAsync(int id) 
        { 
            Order order = await _orderRepository.GetByIdAsync(id);
            if (order == null)
                throw new OrderNotFoundException($"Order with Id:{id} not found!");
            return order;
        }


        public async Task<Order> CreateOrderAsync(CreatedOrder createdOrder)
        {
            if (createdOrder.WeightCargo > 0)
                throw new OrderValidationException("WeightCargo shoud't less zero");
            if (createdOrder.PickupDate < DateTime.Now)
                throw new OrderValidationException("PickupDate shoud't less now day");



            Order order = new Order()
            {
                SenderAddres = createdOrder.SenderAddres,
                SenderСity = createdOrder.SenderСity,
                RecipientAddres = createdOrder.RecipientAddres,
                RecipientCity = createdOrder.RecipientCity,
                WeightCargo = createdOrder.WeightCargo,
                PickupDate = createdOrder.PickupDate,
            };

            await _orderRepository.AddOrderAsync(order);
            await _orderRepository.SaveAsync();

            return order;
        }

        public async Task DeleteOrderAsync(int id)
        {
            var order = await GetOrderByIdAsync(id);
            await _orderRepository.DeleteOrderAsync(order);
        }
      
    }
}
