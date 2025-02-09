using LineConstruction.BLa.Profiles;
using LineConstruction.BLa.Services.Abstractions;
using LineConstruction.BLa.Services.Implementations;
using LineConstruction.DAL.ConfigrationsManager;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IOurServiceService, OurServiceService>();
builder.Services.AddScoped<IOurTeamService, OurTeamService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<ICatagoryService, CatagoryService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IVacancyService, VacancyService>();
builder.Services.AddScoped<IAddedCVService, AddedCVService>();
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
