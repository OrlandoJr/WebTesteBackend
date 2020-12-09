using Microsoft.Extensions.DependencyInjection;
using Infra.Data.Context;
using System;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

namespace WebTest.Configurations
{
    public static class DatabaseSetup
    {
        public static void AddDatabaseSetup(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddDbContextPool<BaseDBContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        }
    }
}
