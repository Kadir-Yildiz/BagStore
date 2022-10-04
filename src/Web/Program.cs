global using Infrastructure.Identity;
global using Microsoft.AspNetCore.Identity;
global using Microsoft.EntityFrameworkCore;
global using Infrastructure.Data;
global using Web.Interfaces;
global using Web.Models;
global using ApplicationCore.Interfaces;
global using ApplicationCore.Entities;
global using Web.Extensions;
global using Web.Services;
global using ApplicationCore.Services;
global using Web.Middlewares;

var builder = WebApplication.CreateBuilder(args);
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true); // postgre datetimeoffset fix

// Add services to the container.
var csIdentity = builder.Configuration.GetConnectionString("AppIdentityDbContext");
var csBagStore = builder.Configuration.GetConnectionString("BagStoreContext");
builder.Services.AddDbContext<AppIdentityDbContext>(options =>
    options.UseNpgsql(csIdentity));
builder.Services.AddDbContext<BagStoreContext>(options =>
    options.UseNpgsql(csBagStore));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true).AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<AppIdentityDbContext>();

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IBasketService, BasketService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IHomeViewModelService, HomeViewModelService>();
builder.Services.AddScoped<IBasketViewModelService, BasketViewModelService>();

builder.Services.AddControllersWithViews();
builder.Services.AddHttpContextAccessor();

var app = builder.Build();
await app.SeedDataAsync();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseTransferBasket();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
