using MembershipMVC.Data;
using MembershipMVC.Helpers;
using MembershipMVC.Models;
using MembershipMVC.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
//using MembershipMVC.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using NuGet.Protocol.Core.Types;
using System.Text;
using IEmailSender = Microsoft.AspNetCore.Identity.UI.Services.IEmailSender;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// register with identity
builder.Services.AddIdentity<ApplicationUser, IdentityRole >( options =>
{
    options.Password.RequiredUniqueChars = 0;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequiredLength = 8;
    options.Password.RequireUppercase = false;
    options.Password.RequireLowercase = false;
    options.User.RequireUniqueEmail = true;
}).AddEntityFrameworkStores<ApplicationDBContext>().AddDefaultTokenProviders();
//builder.Services.AddScoped<IEmailSender,MessageService>();
//builder.Services.AddScoped<IMessageSender, MessageService>();
builder.Services.AddScoped<IEmailSender, EmailSender>();

builder.Services.Configure<CloudinarySettings>(builder.Configuration.GetSection("CloudinarySettings"));
builder.Services.AddScoped<IPhotoService, PhotoService>();
builder.Services.AddScoped<IPhotosDataRepo, PhotosDataRepo>();
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<ICustomer, CustomerService>();

builder.Services.AddRazorPages().AddRazorRuntimeCompilation();


//  configure to EMail
//builder.Services.Configure<IdentityOptions>(options => options.SignIn.RequireConfirmedEmail = true);

// add token life span

//builder.Services.Configure<DataProtectionTokenProviderOptions>(opts => opts.TokenLifespan = TimeSpan.FromHours(10));



// JWT TOKEN START
//var jwtIssuer = builder.Configuration.GetSection("Jwt:Issuer").Get<string>();
//var jwtKey = builder.Configuration.GetSection("Jwt:Key").Get<string>();
var issuerSignInKey = Encoding.ASCII.GetBytes(builder.Configuration.GetSection("Keys")["TokenSigningKey"]);
builder.Services.AddAuthentication()
        .AddJwtBearer(
            options =>

            {
                options.Events = new JwtBearerEvents
                {
                    OnTokenValidated = context =>
                    {
                        var userManager = context.HttpContext.RequestServices.GetRequiredService<UserManager<ApplicationUser>>();
                        var user = userManager.GetUserAsync(context.HttpContext.User);
                        if (user == null) context.Fail("Unauthorized");
                        return Task.CompletedTask;
                    }
                };
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;

                options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    // ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    //ValidIssuer = builder.Configuration["Jwt:Issuer"],
                    // ValidAudience = builder.Configuration["Jwt:Audience"],
                    //IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!))
                    IssuerSigningKey = new SymmetricSecurityKey(issuerSignInKey)
                };
            }
    );
// JWT TOKEN END


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
// add authentication 
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
