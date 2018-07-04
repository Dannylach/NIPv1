using System.Data.Entity;
using NIPv1.Entities;

namespace NIPv1.DAL
{
    public class DataContext : DbContext
    {
        public DataContext() : base("DataContext") {}

        public DbSet<CompanyEntity> Companies { get; set; }

        public DbSet<LogEntity> Logs { get; set; }
    }
}