using HealthAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HealthAPI.Data
{
public class HealthContext : IdentityDbContext<IdentityUser>  {
    public HealthContext(DbContextOptions<HealthContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder) {
        base.OnModelCreating(builder);

        builder.Entity<Ailment>().Property(p => p.Name).HasMaxLength(40);
        builder.Entity<Medication>().Property(p => p.Name).HasMaxLength(40);
        builder.Entity<Patient>().Property(p => p.Name).HasMaxLength(40);

        builder.Entity<Ailment>().ToTable("Ailment");
        builder.Entity<Medication>().ToTable("Medication");
        builder.Entity<Patient>().ToTable("Patient");

        builder.Entity<IdentityRole>().HasData(
            new {Id = "1", Name = "Admin", NormalizedName = "ADMIN"},
            new { Id = "2", Name = "Customer", NormalizedName = "CUSTOMER" }
        );

    }

    public DbSet<Ailment> Ailments { get; set; }
    public DbSet<Medication> Medications { get; set; }
    public DbSet<Patient> Patients { get; set; }
}

}