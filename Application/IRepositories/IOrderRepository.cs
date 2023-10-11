using Domain;
using Microsoft.AspNetCore.JsonPatch;

namespace Application.IRepositories;

public interface IOrderRepository
{
    Task AddOrderAsync(Order order);
    Task DeleteOrderAsync(int orderId);
    Task<Order?> GetOrderByIdAsync(int orderId);
    Task<List<Order>> GetAllOrdersAsync();
    Task UpdateOrderAsync(Order order);
    Task UpdatePatchOrderAsync(int orderId, JsonPatchDocument<Order> orderModel);

    List<string> GetAllPaymentMethods();
    List<string> GetAllStatus();
}
