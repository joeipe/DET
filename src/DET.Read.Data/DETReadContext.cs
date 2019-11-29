using DET.Read.Domain;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DET.Read.Data
{
    public class DETReadContext : DbContext
    {
        public DETReadContext(DbContextOptions<DETReadContext> options)
            : base(options)
        {

        }

        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }


        public DbQuery<UserRoleModel> UserRoleModels { get; set; }

        /*
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=DET_DB;Trusted_Connection=True;");
        }
        */

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var entities = modelBuilder.Model
                .GetEntityTypes()
                .Where(t => t.ClrType.IsSubclassOf(typeof(IEntity))); ;

            foreach (var entityType in entities)
            {
                modelBuilder.Entity(entityType.Name).Property<DateTime>("CreatedDate");
                modelBuilder.Entity(entityType.Name).Property<DateTime>("UpdatedDate");
            }

            base.OnModelCreating(modelBuilder);
        }
    }
}
