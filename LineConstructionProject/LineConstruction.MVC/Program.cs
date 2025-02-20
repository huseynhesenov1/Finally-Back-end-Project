using LineConstruction.BLa.DTOs;
using LineConstruction.BLa.Profiles;
using LineConstruction.BLa.Services.Abstractions;
using LineConstruction.BLa.Services.Implementations;
using LineConstruction.Core.Entities;
using LineConstruction.DAL.ConfigrationsManager;
using LineConstruction.DAL.Contexts;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IOurServiceService, OurServiceService>();
builder.Services.AddScoped<IOurTeamService, OurTeamService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<ICatagoryService, CatagoryService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IVacancyService, VacancyService>();
builder.Services.AddScoped<IAddedCVService, AddedCVService>();
builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddAutoMapper(typeof(OurServiceProfile).Assembly);
builder.Services.AddIdentity<AppUser, IdentityRole>(opt=>opt.Password.RequiredLength = 8).AddDefaultTokenProviders().AddEntityFrameworkStores<AppDbContext>();
builder.Services.AddControllersWithViews();
builder.Services.AddServices();
string? chatId = builder.Configuration.GetSection("TelegramLog")["ChatId"];  
string? botToken = builder.Configuration.GetSection("TelegramLog")["BotToken"];
if (chatId == null || botToken == null)
{
    throw new Exception("Bot has problem");
}
builder.Services.AddSingleton(new TelegramLogService(chatId, botToken, new HttpClient()));
var app = builder.Build();
app.UseStaticFiles();
app.UseExceptionHandler("/Home/ErrorPage"); 
app.UseStatusCodePagesWithRedirects("/Home/ErrorPage?code={0}"); 
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.Run();
