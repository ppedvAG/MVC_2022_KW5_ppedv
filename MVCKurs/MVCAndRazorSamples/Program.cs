using Microsoft.EntityFrameworkCore;
using MVCAndRazorSamples.Data;
using MVCAndRazorSamples.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<ITimeService, TimeService>();

builder.Services.AddDbContext<MovieDbContext>(options => //MovieDbContext ist jetzt im IOC Container
{
    options.UseInMemoryDatabase("MovieDB");
});

var app = builder.Build();


//.NET 2.1 
using (IServiceScope scope = app.Services.CreateScope())
{
    DataSeed.Initialize(scope.ServiceProvider);
}

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


//https://localhost:1234/ [ENTER] -> HomeController -> Index
//https://localhost:1234/Movie/ [Enter] ->  MovieController -Index
//https://localhost:1234/Movie/Index [Enter] ->  MovieController -Index

//https://localhost:1234/Movie/Details/123 -> MovieController - Details (int id)
app.Run();
