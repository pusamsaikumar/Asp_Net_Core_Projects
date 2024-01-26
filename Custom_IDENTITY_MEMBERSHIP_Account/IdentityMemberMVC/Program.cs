using IdentityMemberMVC.Data;
using IdentityMemberMVC.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
// DECLARE CONNECTION STRING 
var connectionString = builder.Configuration.GetConnectionString("default");
// Add services to the container.
builder.Services.AddControllersWithViews();


// add dbcontext 
builder.Services.AddDbContext<ApplicationDBContext>(options => options.UseSqlServer(connectionString));

// REGISTER Identity
builder.Services.AddIdentity<ApplicationUser, IdentityRole>
   (
    options => {

        options.Password.RequiredUniqueChars = 0;
        options.Password.RequireUppercase = false;
        options.Password.RequireLowercase = false;
        options.Password.RequireNonAlphanumeric = false;
        options.Password.RequiredLength = 8;
    }


).AddEntityFrameworkStores<ApplicationDBContext>().AddDefaultTokenProviders();

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
