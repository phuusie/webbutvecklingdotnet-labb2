using webbutveckling_labb2_phuusie.DataAccess.Repositories;
using webbutveckling_labb2_phuusie.Shared.Entities;

namespace webbutveckling_labb2_phuusie.Api.Endpoints;

public static class OrderEndpointExtensions
{
    public static IEndpointRouteBuilder MapOrderEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/orders");

        group.MapGet("", GetAllOrders);
        group.MapGet("/id={id}", GetOrderById);
        group.MapGet("/customer={id}", GetOrderByCustomerId);
        group.MapPost("", AddOrder);
        group.MapPut("/id={id}", UpdateOrder);
        group.MapDelete("/id={id}", DeleteOrder);
        return app;
    }

    private static async Task<IEnumerable<Order>> GetAllOrders(OrderRepository repo)
    {
        return await repo.GetAll();
    }

    private static async Task<Order?> GetOrderById(OrderRepository repo, int id)
    {
        return await repo.GetById(id);
    }

    private static async Task<IEnumerable<Order>> GetOrderByCustomerId(OrderRepository repo, int id)
    {
        return await repo.GetOrderByCustomerId(id);
    }

    private static async Task<Order> AddOrder(OrderRepository repo, Order order)
    {
        return await repo.Add(order);
    }

    private static async Task<Order> UpdateOrder(OrderRepository repo, Order order, int id)
    {
        var existingOrder = await repo.GetById(id);

        existingOrder.CustomerId = order.CustomerId;

        return await repo.Update(existingOrder);
    }

    private static async Task<Order> DeleteOrder(OrderRepository repo, int id)
    {
        return await repo.Delete(id);
    }
}