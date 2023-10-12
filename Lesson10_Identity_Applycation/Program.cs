using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Lesson10_Identity_Applycation.Areas.Identity.Data;
var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("Lesson10_ApplycationContextConnection") ?? throw new InvalidOperationException("Connection string 'Lesson10_ApplycationContextConnection' not found.");

builder.Services.AddDbContext<Lesson10_ApplycationContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<ApplycationUser>(options => options.SignIn.RequireConfirmedAccount = false).AddEntityFrameworkStores<Lesson10_ApplycationContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();

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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();
app.Run();
