using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebFrontEnd.Models;

namespace DataConversrion
{
    internal class ConversionDatabaseContext : DbContext
    {
        private string connectionString = "DataSource=Converted.db;Cache=Shared";
        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(connectionString);
        }

        public DbSet<UserVcVehicle> UserVcVehicles { get; set; }
        public DbSet<VcCollection> VcCollections { get; set; }
        public DbSet<VcCollectionType> VcCollectionTypes { get; set; }
        public DbSet<VcPlate> VcPlates { get; set; }
        public DbSet<VcRangeType> VcRangeTypes { get; set; }
        public DbSet<VcVehicle> VcVehicles { get; set; }
    }
}
