using Microsoft.EntityFrameworkCore;
using webbutveckling_labb2_phuusie.Api.Endpoints;
using webbutveckling_labb2_phuusie.DataAccess;
using webbutveckling_labb2_phuusie.DataAccess.Repositories;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("StoreDb");

builder.Services.AddDbContext<StoreDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddScoped<ProductRepository>();
builder.Services.AddScoped<CustomerRepository>();
builder.Services.AddScoped<OrderRepository>();
builder.Services.AddScoped<ProductCategoryRepository>();
builder.Services.AddScoped<OrderProductRepository>();

var app = builder.Build();

app.MapProductEndpoints();
app.MapCustomerEndpoints();
app.MapOrderEndpoints();
app.MapProductCategoryEndpoints();
app.MapOrderProductEndpoints();

app.Run();
