using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using UCSC.SWFS.SRV.Entity.Entities;
using UCSC.SWFS.SRV.Entity.Entities.UserManagemen;
using Task = UCSC.SWFS.SRV.Entity.Entities.UserManagemen.Task;

namespace UCSC.SWFS.SRV.Entity.Context
{
    public class SWFSDbContext : DbContext
    {
        protected readonly IConfiguration _configuration;
        public SWFSDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Device> Devices { get; set; }
        public DbSet<Schedule> Schedule { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_configuration.GetConnectionString("PostgreSQL"));
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            //converting all table names to lowercase
            builder.Model.GetEntityTypes()
             .ToList()
            .ForEach(t => t.SetTableName(t.GetTableName().ToLower()));

            //converting tables columns to lowercase
            builder.Model.GetEntityTypes()
               .SelectMany(e => e.GetProperties())
               .ToList()
               .ForEach(p => p.SetColumnName(
                     p.GetColumnName(StoreObjectIdentifier.Table(
                         p.DeclaringEntityType.GetTableName()!, p.DeclaringEntityType.GetSchema()!)).ToLower()));

            builder.Entity<Task>()
                .HasOne(e => e.Device)
                .WithMany(e => e.Tasks)
                .HasForeignKey(e => e.DeviceId)
                .IsRequired();

            builder.Entity<Schedule>()
                .HasMany(e => e.Tasks)
                .WithOne()
                .IsRequired();
        }
    }
}
