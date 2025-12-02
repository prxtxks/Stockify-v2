using Microsoft.EntityFrameworkCore;
using Stockify.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<OrganisationDbContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("MySqlConnection"), new MySqlServerVersion(new Version(8, 0, 29))));

builder.Services.AddDbContext<ProductDbContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("MySqlConnection"), new MySqlServerVersion(new Version(8, 0, 29))));

builder.Services.AddDbContext<LoadDbContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("MySqlConnection"), new MySqlServerVersion(new Version(8, 0, 29))));

builder.Services.AddDbContext<LoadEntryDbContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("MySqlConnection"), new MySqlServerVersion(new Version(8, 0, 29))));

builder.Services.AddDbContext<JobWorkDbContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("MySqlConnection"), new MySqlServerVersion(new Version(8, 0, 29))));

builder.Services.AddDbContext<JobWorkEntryDbContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("MySqlConnection"), new MySqlServerVersion(new Version(8, 0, 29))));

builder.Services.AddDbContext<StockDbContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("MySqlConnection"), new MySqlServerVersion(new Version(8, 0, 29))));


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

app.Run();

