using Microsoft.EntityFrameworkCore;
using SGE.Application;
namespace SGE.Repositories;

public class FmsContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Application.File> Files { get; set; }
    public DbSet<Procedure> Procedures { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("data source=Database.sqlite");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Application.File>(entity =>
        {
            entity.HasKey(f => f.Id);

            entity.HasOne(f => f.LastEditor)
                .WithMany(u => u.Files)
                .HasForeignKey(f => f.UserId)
                .OnDelete(DeleteBehavior.NoAction);
        });

        modelBuilder.Entity<Procedure>(entity =>
        {
            entity.HasKey(p => p.Id);

            entity.HasOne(p => p.File)
                .WithMany(f => f.Procedures)
                .HasForeignKey(p => p.FileId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(p => p.LastEditor)
                .WithMany(u => u.Procedures)
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.NoAction);
        });

        modelBuilder.Entity<User>().HasKey(u => u.Id);
    }
}