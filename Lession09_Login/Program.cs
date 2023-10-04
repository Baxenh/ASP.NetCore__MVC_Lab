using Lesson09_Login.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
// builder
var connectionString = builder.Configuration.GetConnectionString("AppDbContextString");
builder.Services.AddDbContext<DevXuongMocContext>(x => x.UseSqlServer(connectionString));

// cấu hình sử dụng Session
builder.Services.AddDistributedMemoryCache();
//Đăng ký dịch vụ cho HttpContextAccessor
builder.Services.AddHttpContextAccessor();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(60);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
    options.Cookie.Name = ".Devmaster.Session";
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// sử dụng Sesion đã khai báo ở trên
app.UseSession();


app.MapControllerRoute(
           name: "areas",
           pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}"
         );

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
