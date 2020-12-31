using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WebFrontEnd.Models;

namespace WebFrontEnd.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<UserVcVehicle> UserVcVehicles { get; set; }
        public DbSet<VcCollection> VcCollections { get; set; }
        public DbSet<VcCollectionType> VcCollectionTypes { get; set; }
        public DbSet<VcPlate> VcPlates { get; set; }
        public DbSet<VcRangeType> VcRangeTypes { get; set; }
        public DbSet<VcVehicle> VcVehicles { get; set; }
    }
}
