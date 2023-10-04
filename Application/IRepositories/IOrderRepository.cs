using Domain;

namespace Application.IRepositories;

public interface IOrderRepository
{
    Task AddOrderAsync(Order order);
    Task DeleteOrderAsync(int orderId);
    Task<Order?> GetOrderByIdAsync(int orderId);
    Task<List<Order>> GetAllOrdersAsync();
    Task UpdateOrderAsync(Order order);
}
