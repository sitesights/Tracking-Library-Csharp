using SiteSights.Tracking.Common;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// You should only use one instance for all of your application, due to httpclient being used internally
builder.Services.AddSingleton<ISiteSightsTracking>(x => new SiteSightsTracking(
    new SiteSightsTrackingOptions() {
        ApiKey = "MWBRfBhiwU2Srav4A_4Iog2oncYSt6mEWhkEXeMRp0_w",
    }));



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
