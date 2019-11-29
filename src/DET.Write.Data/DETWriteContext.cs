using DET.Write.Domain;
using Microsoft.EntityFrameworkCore;
using SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DET.Write.Data
{
    public class DETWriteContext : DbContext
    {
        public DETWriteContext(DbContextOptions<DETWriteContext> options)
            : base(options)
        {

        }
        public DbSet<RoleCommand> Roles { get; set; }
        public DbSet<UserCommand> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RoleCommand>().ToTable("Roles");
            modelBuilder.Entity<UserCommand>().ToTable("Users");

            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                modelBuilder.Entity(entityType.Name).Property<DateTime>("CreatedDate");
                modelBuilder.Entity(entityType.Name).Property<DateTime>("UpdatedDate");
            }

            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            var now = DateTime.Now;

            foreach (var changedEntity in ChangeTracker.Entries()
            .Where(e => e.State == EntityState.Added ||
                        e.State == EntityState.Modified))
            {
                switch (changedEntity.State)
                {
                    case EntityState.Added:
                        changedEntity.Property("CreatedDate").CurrentValue = now;
                        changedEntity.Property("UpdatedDate").CurrentValue = now;
                        break;

                    case EntityState.Modified:
                        changedEntity.Property("UpdatedDate").CurrentValue = now;
                        break;
                }
            }

            return base.SaveChanges();
        }
    }
}
