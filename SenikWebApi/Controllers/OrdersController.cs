﻿using Application.IRepositories;
using AutoMapper;
using Domain;
using Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SenikWebApi.Models;

namespace SenikWebApi.Controllers;

[Route("api/[controller]")]
[ApiController]

public class OrdersController : ControllerBase
{
    private readonly IOrderRepository _orderRepository;
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public OrdersController(IOrderRepository orderRepository, 
                                IMapper mapper,
                                IProductRepository productRepository)
    {
        _orderRepository = orderRepository;
        _mapper = mapper;
        _productRepository = productRepository; 
    }

    // GET: api/Orders
    [HttpGet]
    [Authorize(Roles = "Staff")]
    public async Task<ActionResult<IEnumerable<OrderVM>>> GetOrders()
    {
        try
        {
            var orders = await _orderRepository.GetAllOrdersAsync();
            return Ok(_mapper.Map<List<OrderVM>>(orders));
        }
        catch (Exception ex)
        {
            return BadRequest(new { ErrorMessage = ex.Message });
        }
    }

    // GET: api/Orders/5
    [HttpGet("{id}")]
    [Authorize]
    public async Task<ActionResult<OrderVM>> GetOrder(int id)
    {
        var order = await _orderRepository.GetOrderByIdAsync(id);

        if (order == null)
        {
            return NotFound();
        }

        return Ok(_mapper.Map<OrderVM>(order));
    }

    // PUT: api/Orders/5    
    [HttpPut("{id}")]
    [Authorize(Roles = "Staff")]
    public async Task<IActionResult> PutOrder(int id, OrderModel model)
    {
        if (!Enum.IsDefined(typeof(PaymentEnum), model.PaymentMethod))
        {
            return BadRequest(new { ErrorMessage = $"Invalid payment method {model.PaymentMethod}!" });
        }
        try
        {
            var order = _mapper.Map<Order>(model);
            order.Id = id;
            await _orderRepository.UpdateOrderAsync(order);

        }
        catch (ArgumentException ex)
        {
            return NotFound(new { ErrorMessage = ex.Message });
        }
        catch (Exception ex)
        {
            return BadRequest(new { ErrorMessage = ex.Message });
        }

        return NoContent();
    }

    // POST: api/Orders    
    [HttpPost]
    public async Task<ActionResult<Order>> PostOrder(OrderModel model)
    {
        if (!Enum.IsDefined(typeof(PaymentEnum), model.PaymentMethod))
        {
            return BadRequest(new { ErrorMessage = $"Invalid payment method {model.PaymentMethod}!" });
        }
        // Create ticket order
        var lastestOrder = (await _orderRepository.GetAllOrdersAsync()).OrderBy(x => x.Id).LastOrDefault();
        var order = _mapper.Map<Order>(model);
        order.Id = lastestOrder == null ? 1 : lastestOrder.Id + 1;
        try
        {
            // Create Order detail
            var details = new List<OrderDetail>();
            foreach (var item in model.Products)
            {
                var product = await _productRepository.GetProductByIdAsync(item.ProductId);
                if (product == null)
                {
                    throw new Exception($"Invalid product with Id {item.ProductId}.");
                }
                var detail = new OrderDetail
                {
                    ProductId = product.Id,
                    OrderId = order.Id,
                    Quantity = item.Quantity,
                    UnitPrice = product.Price
                };
                details.Add(detail);
                order.TotalQuantity += detail.Quantity;
                order.TotalMoney += detail.UnitPrice * detail.Quantity;
            }
            // Save in database
            order.OrderDetails = details;
            await _orderRepository.AddOrderAsync(order);
        }
        catch (Exception ex)
        {
            return BadRequest(new { ErrorMessage = ex.Message});
        }

        return CreatedAtAction("GetOrder", new { id = order.Id }, _mapper.Map<OrderVM>(order));
    }

    // DELETE: api/Orders/5
    [HttpDelete("{id}")]
    [Authorize(Roles = "Staff")]
    public async Task<IActionResult> DeleteOrder(int id)
    {
        try
        {
            await _orderRepository.DeleteOrderAsync(id);

        }
        catch (ArgumentException ex)
        {
            return NotFound(new { ErrorMessage = ex.Message });
        }
        catch (Exception ex)
        {
            return BadRequest(new { ErrorMessage = ex.Message });
        }

        return NoContent();
    }

    // GET: api/products/payments
    [HttpGet("payments")]
    public ActionResult<IEnumerable<CategoryVM>> GetPaymentMethods()
    {
        try
        {
            var payments = new List<CategoryVM>();
            int i = 0;
            foreach (var payment in _orderRepository.GetAllPaymentMethods())
            {
                payments.Add(new CategoryVM { Id = i++, Name = payment });
            }
            return Ok(payments);
        }
        catch (Exception ex)
        {
            return BadRequest(new { ErrorMessage = ex.Message });
        }
    }

    // GET: api/products/status
    [HttpGet("status")]
    public ActionResult<IEnumerable<CategoryVM>> GetProductStatus()
    {
        try
        {
            var status = new List<CategoryVM>();
            int i = 0;
            foreach (var s in _orderRepository.GetAllStatus())
            {
                status.Add(new CategoryVM { Id = i++, Name = s });
            }
            return Ok(status);
        }
        catch (Exception ex)
        {
            return BadRequest(new { ErrorMessage = ex.Message });
        }
    }
}