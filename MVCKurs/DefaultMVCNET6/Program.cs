WebApplicationBuilder builder = WebApplication.CreateBuilder(args);


#region (Vergleich zu .NET 5) Startup ConfigureServices
// Add services to the container.
builder.Services.AddControllersWithViews(); //MVC wird verwendet (Orderstruktur -> Controllers /Views, Models) 
/*builder.Services.AddRazorPages();*/ //Razor Page UI Framework -> benötigt den Ordner -> Pages

/*builder.Services.AddMvc();*/ //AddControllersWithViews + AddRazorPages

builder.Services.AddFeature();
#endregion

WebApplication app = builder.Build();

#region (Vergleich zu .NET 5) Startup Configure
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
else if (app.Environment.IsDevelopment())
{
    //Tool oder Services für die Entwickler
}
else if (app.Environment.IsStaging())
{
    //z.B Support-Tools für Analysen
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
#endregion
app.Run();



public static class MySampleExtentionMethode
{
    public static void AddFeature(this IServiceCollection services)
    {
        //services.AddScoped<ITimeService, TimeService>();
    }
}