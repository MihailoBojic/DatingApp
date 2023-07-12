using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.interfaces;
using API.Services;
using Microsoft.EntityFrameworkCore;

namespace API.extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<DataContext>(opt =>
          {
             opt.UseSqlite(config.GetConnectionString("DefaultConnection"));
          });

            services.AddCors();
            services.AddScoped<ITokenService, TokenService>();

            return services;
        }
    }
}