using SiteSights.Tracking.Common;
using SiteSights.Tracking.Extensions;
using SiteSights.Tracking.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Configure the SiteSightsTracking Options and register them to the service collection
// Note: You can also load the options from a configuration file or environment variables via IConfiguration
builder.Services.Configure<SiteSightsTrackingOptions>(options =>
{
    options.ApiKey = "YOUR_API_KEY"; // Required: Will be found on your sitesights.io dashboard under websites > edit website, do not share this anywhere in the frontend.
    // Optional: options.Url = "https://app.sitesights.io"; // Default value, currently SiteSights only supports this url
});

// Register the SiteSightsTracking service with the specified ServiceLifetime
// Note: You can also use the default ServiceLifetime.Scoped
builder.Services.AddSiteSightsTracking();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment()) {
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
