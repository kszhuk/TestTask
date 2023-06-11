using Microsoft.EntityFrameworkCore;
using TestTask.Infrastructure.DataModels;

namespace TestTask.Infrastructure
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
            SQLitePCL.Batteries_V2.Init();

            //this.Database.EnsureDeleted();
            this.Database.Migrate();
        }

        public DbSet<Order> Orders { get; set; }
    }
}
