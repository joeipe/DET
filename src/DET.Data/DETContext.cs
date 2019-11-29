using DET.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace DET.Data
{
    public class DETContext : DbContext
    {
        public DETContext(DbContextOptions<DETContext> options)
            :base(options)
        {

        }

        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }

        /*
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=DET_DB;Trusted_Connection=True;");
        }
        */

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                modelBuilder.Entity(entityType.Name).Property<DateTime>("CreatedDate");
                modelBuilder.Entity(entityType.Name).Property<DateTime>("UpdatedDate");
                modelBuilder.Entity(entityType.Name).Ignore("IsDirty");
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
