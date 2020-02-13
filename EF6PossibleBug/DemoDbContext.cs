using System;
using System.Data.Entity;

namespace EF6PossibleBug
{
    public class DemoDbContext : DbContext
    {
        public DemoDbContext() : base(
            "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=EF6POC;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False")
        {
            Database.Log = Console.Write;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<First3>().ToTable("ZFirst3s");
            modelBuilder.Entity<ZLast3>().ToTable("AZLast3s");
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
