using Microsoft.EntityFrameworkCore;
using MVCAndRazorSamples.Data;
using MVCAndRazorSamples.Services;
using Microsoft.AspNetCore.Identity;
using System.Globalization;
using Microsoft.Extensions.Options;
using MVCAndRazorSamples.Middleware;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("MovieStoreIdentityContextConnection");builder.Services.AddDbContext<MovieStoreIdentityContext>(options =>
    options.UseSqlServer(connectionString));builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<MovieStoreIdentityContext>();
// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddAuthentication();

builder.Services.AddSession();
builder.Services.AddScoped<ITimeService, TimeService>();

builder.Services.AddDbContext<MovieDbContext>(options => //MovieDbContext ist jetzt im IOC Container
{
    options.UseInMemoryDatabase("MovieDB");
});


builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    CultureInfo[] supportedCultures = new[]
    {
        new CultureInfo("en"),
        new CultureInfo("de"),
        new CultureInfo("fr"),
    };

    options.DefaultRequestCulture = new Microsoft.AspNetCore.Localization.RequestCulture("de");
    options.SupportedCultures = supportedCultures;
    options.SupportedUICultures = supportedCultures;
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

AppDomain.CurrentDomain.SetData("BildVerzeichnis", app.Environment.WebRootPath);
//AppDomain.CurrentDomain.SetData("BildVerzeichnis", env.WebRootPath);




app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

//in NET 5 -> app.UseRequestLocalization(app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>().Value);

using (IServiceScope scope = app.Services.CreateScope())
{
    IOptions<RequestLocalizationOptions> requestLocalizationOptions =  scope.ServiceProvider.GetService<IOptions<RequestLocalizationOptions>>();

    app.UseRequestLocalization(requestLocalizationOptions.Value);
};


//Sehr sehr wichtig! Authentification muss vor Authorization stehen 
app.UseAuthentication();
app.UseAuthorization();

app.UseSession();


app.MapWhen(context => context.Request.Path.ToString().Contains("imagegen"), subapp =>
{
    subapp.UseThumbnailGen();
});


app.MapControllerRoute(
                     name: "movie",
                     pattern: "movie/{*movie}", defaults: new { controller = "Movie", action = "Index" });

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

//https://localhost:1234/ [ENTER] -> HomeController -> Index
//https://localhost:1234/Movie/ [Enter] ->  MovieController -Index
//https://localhost:1234/Movie/Index [Enter] ->  MovieController -Index

//https://localhost:1234/Movie/Details/123 -> MovieController - Details (int id)
app.Run();
