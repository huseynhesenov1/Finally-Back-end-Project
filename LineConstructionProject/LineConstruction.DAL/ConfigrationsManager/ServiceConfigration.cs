using LineConstruction.DAL.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using LineConstruction.DAL.Helpers;
using LineConstruction.DAL.Repositories.Abstractions;
using LineConstruction.DAL.Repositories.Implementations;
namespace LineConstruction.DAL.ConfigrationsManager
{
    public static class ServiceConfigration 
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(Configurations.GetConnectionStr()) );
            services.AddScoped<IOurServiceReadRepository, OurServiceReadRepository>();
            services.AddScoped<IOurServiceWriteRepository, OurServiceWriteRepository>();
            services.AddScoped<IOurTeamReadRepository, OurTeamReadRepository>();
            services.AddScoped<IOurTeamWriteRepository, OurTeamWriteRepository>();
            services.AddScoped<IOrderReadRepository, OrderReadRepository>();
            services.AddScoped<IOrderWriteRepository, OrderWriteRepository>();
            services.AddScoped<ICatagoryWriteRepository, CatagoryWriteRepository>();
            services.AddScoped<ICatagoryReadRepository, CatagoryReadRepository>();
            services.AddScoped<IProductReadRepository, ProductReadRepository>();
            services.AddScoped<IProductWriteRepository, ProductWriteRepository>();
            services.AddScoped<IVacancyWriteRepository, VacancyWriteRepository>();
            services.AddScoped<IVacancyReadRepository, VacancyReadRepository>();
            services.AddScoped<IAddedCVReadRepository, AddedCVReadRepository>();
            services.AddScoped<IAddedCVWriteRepository, AddedCVWriteRepository>();
        }
    }
}
