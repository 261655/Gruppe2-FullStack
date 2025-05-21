
using Gruppe2.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient(); 
builder.Services.AddScoped<IPollenAPIService, PollenAPIService>();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=pollen.db"));


var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();
app.UseStaticFiles();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.MapDefaultControllerRoute();

app.Run();
