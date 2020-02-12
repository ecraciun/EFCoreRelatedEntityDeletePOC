using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace EFCorePossibleBugPOC
{
    public class DemoDbContext : DbContext
    {
        private static readonly ILoggerFactory ConsoleLoggerFactory = new ServiceCollection()
            .AddLogging(b => b.AddConsole()
                .AddFilter(DbLoggerCategory.Database.Command.Name, LogLevel.Information)
                .AddFilter(DbLoggerCategory.ChangeTracking.Name, level => level == LogLevel.Information)
            )
            .BuildServiceProvider().GetService<ILoggerFactory>();

        public DemoDbContext() : base(GetOptions())
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<First3>().ToTable("ZFirst3s");
            modelBuilder.Entity<ZLast3>().ToTable("AZLast3s");
        }

        public static DbContextOptions GetOptions()
        {
            // TODO: modify this
            var connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=EFCPOC;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            var optionsBuilder = new DbContextOptionsBuilder()
                .UseSqlServer(connectionString)
                .UseLoggerFactory(ConsoleLoggerFactory)
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors();

            return optionsBuilder.Options;
        }

        public DbSet<First> Firsts { get; set; }
        public DbSet<Middle> Middles { get; set; }
        public DbSet<ZLast> ZLasts { get; set; }


        public DbSet<First2> ZFirst2s { get; set; }
        public DbSet<ZLast2> AZLast2s { get; set; }

        public DbSet<First3> First3s { get; set; }
        public DbSet<ZLast3> ZLast3s { get; set; }
    }
}
