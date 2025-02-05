using LineConstruction.BLa.Profiles;
using LineConstruction.BLa.Services.Abstractions;
using LineConstruction.BLa.Services.Implementations;
using LineConstruction.DAL.ConfigrationsManager;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IOurServiceService, OurServiceService>();
builder.Services.AddAutoMapper(typeof(OurServiceProfile).Assembly);

builder.Services.AddControllersWithViews();
builder.Services.AddServices();
var app = builder.Build();
app.UseStaticFiles();




app.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.Run();
