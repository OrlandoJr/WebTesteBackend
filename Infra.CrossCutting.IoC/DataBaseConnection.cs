using Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;

namespace Infra.CrossCutting.IoC
{
    //public class DataBaseConnection
    //{

    //    public static void AddBaseDatabaseSetup(IServiceCollection services, IConfiguration configuration)
    //    {
    //        services = services.AddDbContext<BaseDBContext>(options =>
    //                        options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
    //    }
    //}
}
