using Microsoft.EntityFrameworkCore;
using MiniStore.Components;
using MiniStore.Data;
using MiniStore.Services;

var builder = WebApplication.CreateBuilder(args);

// DbContext ме PostgreSQL
builder.Services.AddDbContext<MiniStoreDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("MiniStoreConnection")));

// Razor Components + global interactive mode
builder.Services.AddRazorComponents()
       .AddInteractiveServerComponents();

builder.Services.AddScoped<CartService>();



var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

// Root component
app.MapRazorComponents<App>()
 .AddInteractiveServerRenderMode();
app.UseAntiforgery();

app.Run();
