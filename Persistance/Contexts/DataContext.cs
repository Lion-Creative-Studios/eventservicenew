using Microsoft.EntityFrameworkCore;
using Persistance.Entities;

namespace Persistance.Contexts;

/* Updateded by chatgpt 4o generated code to correctly map data between tables */
public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{
    public DbSet<EventEntity> Events { get; set; }
    public DbSet<PackageEntity> Packages { get; set; }
    public DbSet<EventPackageEntity> EventPackages { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Event - EventPackage: One-to-many
        modelBuilder.Entity<EventPackageEntity>()
            .HasOne(ep => ep.Event)
            .WithMany(e => e.Packages)
            .HasForeignKey(ep => ep.EventId)
            .OnDelete(DeleteBehavior.Cascade);

        // EventPackage - Package: One-to-one (or many-to-one if Package is reused)
        modelBuilder.Entity<EventPackageEntity>()
            .HasOne(ep => ep.Package)
            .WithMany()
            .OnDelete(DeleteBehavior.Cascade); // or Restrict/SetNull depending on business logic
    }
}

/* Updateded by chatgpt 4o generated code to correctly map data between tables */

