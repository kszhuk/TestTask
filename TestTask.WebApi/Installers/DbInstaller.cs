using Microsoft.EntityFrameworkCore;
using TestTask.Infrastructure;

namespace TestTask.WebApi.Installers
{
    public class DbInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<DataContext>(options =>
                options.UseSqlite(connectionString));
            //services.AddDbContext<DataContext>(options =>
            //    options.UseSqlite(connectionString,
            //    x => x.MigrationsAssembly("TestTask.Infrastructure")));
            services.AddDatabaseDeveloperPageExceptionFilter();
        }
    }
}
