using Microsoft.EntityFrameworkCore;
using SqlLiteInNET6.Entities;

namespace SqlLiteInNET6.DbContexts
{
    public class OrderSystemContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source=OrderSystemConsole.db");
        }
    }
}
