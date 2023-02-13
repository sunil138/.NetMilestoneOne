using Microsoft.EntityFrameworkCore;
using MilestoneOneLibraryWithMVC_Feb13.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
//It is Connection String that we pass into program.cs to connect with the Database. So, A data base connection is created between sql server database and asp.net mvc.
builder.Services.AddDbContext<LibraryContext>(options=>options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConn"))); 
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

app.Run();
