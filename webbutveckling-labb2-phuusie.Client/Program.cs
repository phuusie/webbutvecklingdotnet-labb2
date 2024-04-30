using webbutveckling_labb2_phuusie.Client.Components;
using webbutveckling_labb2_phuusie.Client.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddHttpClient("storeApi", client =>
{
    client.BaseAddress = new Uri("http://localhost:5001");
});

builder.Services.AddBlazorBootstrap();

builder.Services.AddScoped<CartService>();
//Temporär lösning for AccountService - Ska vara Scoped men det fungerade inte helt som det ska. Därför används Singleton.
builder.Services.AddSingleton<AccountService>(); 
builder.Services.AddScoped<CustomerService>();
builder.Services.AddScoped<ProductService>();
builder.Services.AddScoped<OrderService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
