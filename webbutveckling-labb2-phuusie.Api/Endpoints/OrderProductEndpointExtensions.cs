using webbutveckling_labb2_phuusie.DataAccess.Repositories;
using webbutveckling_labb2_phuusie.Shared.Entities;

namespace webbutveckling_labb2_phuusie.Api.Endpoints;

public static class OrderProductEndpointExtensions
{
    public static IEndpointRouteBuilder MapOrderProductEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/orders");

        group.MapGet("/products", GetAllOrderProducts);
        group.MapGet("/id={id}/products", GetOrderProductsByOrderId);
        group.MapPost("/products", AddOrderProduct);
        return app;
    }

    private static async Task<IQueryable<OrderProduct>> GetAllOrderProducts(OrderProductRepository repo)
    {
        return await repo.GetAll();
    }

    private static async Task<OrderProduct?> GetOrderProductsByOrderId(OrderProductRepository repo, int id)
    {
        return await repo.GetById(id);
    }

    private static async Task<OrderProduct> AddOrderProduct(OrderProductRepository service, OrderProduct orderProduct)
    {
        return await service.Add(orderProduct);
    }


}