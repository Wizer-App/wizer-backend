
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}
    
    public DbSet<SchoolClass> SchoolClasses { get; set; } = null!;
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Team> Teams { get; set; } = null!;
    public DbSet<Activity> Activities { get; set; } = null!;
    
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Relación uno a muchos: SchoolClass → Teacher
        modelBuilder.Entity<SchoolClass>()
            .HasOne(s => s.Teacher)       // Una clase tiene un Teacher
            .WithMany()                   // Un teacher puede tener muchas clases
            .HasForeignKey(s => s.TeacherId)
            .OnDelete(DeleteBehavior.Restrict); // Evita que borrar un teacher borre clases

        // Relación muchos a muchos: SchoolClass ↔ Students
        modelBuilder.Entity<SchoolClass>()
            .HasMany(s => s.Students)
            .WithMany(u => u.SchoolClasses); 

        // Relación uno a muchos: SchoolClass → Teams
        modelBuilder.Entity<SchoolClass>()
            .HasMany(s => s.Teams)
            .WithOne(t => t.SchoolClass) 
            .HasForeignKey(t => t.SchoolClassId)
            .OnDelete(DeleteBehavior.Cascade);

        // Relación uno a muchos: SchoolClass → Activities
        modelBuilder.Entity<SchoolClass>()
            .HasMany(s => s.Activities)
            .WithOne(a => a.SchoolClass)  
            .HasForeignKey(a => a.SchoolClassId)
            .OnDelete(DeleteBehavior.Cascade);
    }

}