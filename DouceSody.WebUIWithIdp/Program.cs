using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using DouceSody.WebUIWithIdp.Data;
using DouceSody.WebUIWithIdp.Areas.Identity.Data;
using DouceSody.Domain;
using System.Reflection;
using DouceSody.Application;
using DouceSody.Infrastructure;
using DouceSody.Application.Common.Interfaces;
using DouceSody.WebUI.Services;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddApplication();
//var configuration = new ConfigurationBuilder().Build();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddSingleton<ICurrentUserService, CurrentUserService>();
builder.Services.AddHttpContextAccessor();

builder.Services.AddHealthChecks()
         .AddDbContextCheck<ApplicationDbContext>();

//var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
//builder.Services.AddDbContext<IdentityDataContext>(options =>
//options.UseSqlServer(connectionString));
//builder.Services.AddDbContext<ApplicationDbContext>(options =>
//options.UseSqlite(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

//builder.Services.AddDefaultIdentity<ApplicationUser>(options =>
//{
//    options.SignIn.RequireConfirmedAccount = true;
//    options.User.RequireUniqueEmail = true;
//})
//.AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

var app = builder.Build();

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

app.UseHealthChecks("/health");
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseIdentityServer();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller}/{action=Index}/{id?}");
    endpoints.MapRazorPages();
});

//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Home}/{action=Index}/{id?}");
//app.MapRazorPages();

app.Run();

