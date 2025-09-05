using Ecom.core.Interfaces;
using Ecom.Infrastructure.Data;
using Ecom.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
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

            return services;
        }
    }
}