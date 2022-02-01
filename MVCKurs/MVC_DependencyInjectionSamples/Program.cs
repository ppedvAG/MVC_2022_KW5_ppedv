using MVC_DependencyInjectionSamples.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<ITimeService, TimeService>();
var app = builder.Build();

//Warum ist es gut, hier auf den IOC Container schon zugreifen zu können?
//Use Case -> Bei Verwendung von EFCore können wir Testdaten z.b vorab einspielen

//.NET 2.1 
using (IServiceScope scope = app.Services.CreateScope())
{
    ITimeService? myTimeService = scope.ServiceProvider.GetService<ITimeService>();

    Console.WriteLine(myTimeService.GetCurrentTime());
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

app.Run();
