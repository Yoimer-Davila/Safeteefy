using Safeteefy.API.Shared.Extensions;
using Microsoft.EntityFrameworkCore;
using Safeteefy.API.Safeteefy.Domain.Models;

namespace Safeteefy.API.Shared.Persistence.Contexts;

public class AppDbContext : DbContext
{
    public DbSet<Guardian> Guardians { get; set; }
    public DbSet<Urgency> Urgencies { get; set; }

    public AppDbContext(DbContextOptions options) : base(options)
    {
    }


    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        //Guardians
        builder.Entity<Guardian>().ToTable("Guardians");
        builder.Entity<Guardian>().HasKey(g => g.Id);
        builder.Entity<Guardian>().Property(g => g.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Guardian>().Property(g => g.Username)
            .IsRequired().HasMaxLength(30);
        builder.Entity<Guardian>().Property(g => g.Email)
            .IsRequired().HasMaxLength(30);
        builder.Entity<Guardian>().Property(g => g.Firstname)
            .IsRequired().HasMaxLength(60);
        builder.Entity<Guardian>().Property(g => g.Lastname)
            .IsRequired().HasMaxLength(60);
        builder.Entity<Guardian>().Property(g => g.Gender)
            .IsRequired();
        builder.Entity<Guardian>().Property(g => g.Address);
        //Urgencies
        builder.Entity<Urgency>().ToTable("Urgencies");
        builder.Entity<Urgency>().HasKey(u => u.Id);
        builder.Entity<Urgency>().Property(u => u.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Urgency>().Property(u => u.Summary);
        builder.Entity<Urgency>().Property(u => u.Latitude).IsRequired();
        builder.Entity<Urgency>().Property(u => u.Longitude).IsRequired();
        builder.Entity<Urgency>().Property(u => u.ReportedAt).ValueGeneratedOnAdd();

        //Relationships
        builder.Entity<Guardian>()
            .HasMany<Urgency>()
            .WithOne(u => u.Guardian)
            .HasForeignKey(u => u.GuardianId)
            .OnDelete(DeleteBehavior.Cascade);


        // Apply Snake Case Naming Convention
        builder.UseSnakeCaseNamingConvention();
    }
}