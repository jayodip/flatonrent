using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RentFlats.Domain.Interfaces;
using RentFlats.Infrastructure.Persistance;
using RentFlats.Infrastructure.Repositories;
using RentFlats.Infrastructure.Seeders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentFlats.Infrastructure.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<RentFlatsDbContext>(options => options.UseSqlServer(
            configuration.GetConnectionString("RentFlats")));

            services.AddDefaultIdentity<IdentityUser>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<RentFlatsDbContext>();

            services.AddScoped<FlatSeeder>();
            services.AddScoped<IFlatRepository, FlatRepository>();
        }
    }
}
