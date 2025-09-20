using Ecom.core.Interfaces;
using Ecom.core.Services;
using Ecom.Infrastructure.Data;
using Ecom.Infrastructure.Repository;
using Ecom.Infrastructure.Repository.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.Infrastructure
{
    public static class InfrastructureRegistration
    {
        public static IServiceCollection InfrastructureConfiguration(this IServiceCollection services,IConfiguration configuration)
        {

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            //apply unit of work
            services.AddScoped<IUnitOfWork, UnitOfWork>();

         
            //apply DBcontext
            services.AddDbContext<AppDbContext>(options => {
                options.UseSqlServer(configuration.GetConnectionString("EcomDatabase"));
                }
                );

            services.AddSingleton<IFileProvider>(
                  new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot")));

            services.AddSingleton<IImageManagementalService, ImageManagementalService>();
            return services;
        }
    }
}