using Application.IRepositories;
using Domain;
using Domain.Enums;
using Infrastructure.Daos;

namespace Application.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly OrderDao _orderDao;

    public OrderRepository(OrderDao orderDao)
    {
        _orderDao = orderDao;
    }

    public async Task AddOrderAsync(Order order)
    {
        var existingOrder = await GetOrderByIdAsync(order.Id);
        if (existingOrder != null)
        {
            throw new ArgumentException($"Order with Id {order.Id} already exists!");
        }
        await _orderDao.AddAsync(order);
    }

    public async Task DeleteOrderAsync(int orderId)
    {
        var order = await GetOrderByIdAsync(orderId);
        if (order == null)
        {
            throw new ArgumentException($"Order with Id {orderId} does not exist.");
        }
        await _orderDao.SoftDeleteAsync(order);
    }

    public async Task<Order?> GetOrderByIdAsync(int orderId)
    {
        return await _orderDao.GetByIdAsync(orderId);
    }

    public async Task<List<Order>> GetAllOrdersAsync()
    {
        return await _orderDao.GetAllAsync();
    }

    public async Task UpdateOrderAsync(Order order)
    {
        var existingOrder = await GetOrderByIdAsync(order.Id);
        if (existingOrder == null)
        {
            throw new ArgumentException($"Order with Id {order.Id} does not exist.");
        }
        await _orderDao.UpdateAsync(order);
    }

    public List<string> GetAllPaymentMethods()
    {
        var categories = Enum.GetNames(typeof(PaymentEnum));
        return categories.ToList();
    }

    public List<string> GetAllStatus()
    {
        var categories = Enum.GetNames(typeof(OrderStatusEnum));
        return categories.ToList();
    }
}

