using Microsoft.EntityFrameworkCore;
using Task3Library.Data.Models;

namespace Task3Library.Data
{
    public class DataContext : DbContext
    {
        public DataContext(string connectionString) : base(GetOptions(connectionString))
        {

        }

        public DataContext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer();
        }

        private static DbContextOptions GetOptions(string connectionString)
        {
            return SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder(), connectionString).Options;
        }

        public DbSet<ContactDataModel> ContactData { get; set; }
        public DbSet<MessageDataModel> MessageData { get; set; }
        public DbSet<UserDataModel> UserData { get; set; }


        public async Task ApplyMigrations()
        {
            await Database.MigrateAsync();
        }
    }
}