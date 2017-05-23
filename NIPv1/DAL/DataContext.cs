using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using NIPv1.Models;

namespace NIPv1.DAL
{
    public class DataContext : DbContext
    {
        public DataContext() : base("DataContext") {}

        public DbSet<Data> Datas { get; set; }
        public DbSet<Statistics> Statistics { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}