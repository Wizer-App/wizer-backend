
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
    public DbSet<Document> Documents { get; set; } = null!;
    public DbSet<InfoUser> InfoUsers { get; set; } = null!;

    public DbSet<Message> Messages { get; set; } = null!;


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Relación uno a muchos: SchoolClass → Teacher
        modelBuilder.Entity<SchoolClass>()
            .HasOne(s => s.Teacher) // Una clase tiene un Teacher
            .WithMany() // Un teacher puede tener muchas clases
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

        modelBuilder.Entity<Team>()
            .HasOne(t => t.Creator)
            .WithMany()
            .HasForeignKey(t => t.CreatorId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Team>()
            .HasMany(t => t.Members)
            .WithMany(u => u.Teams);

        modelBuilder.Entity<Team>()
            .HasMany(t => t.Activities)
            .WithOne(a => a.Team)
            .HasForeignKey(a => a.TeamId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Document>()
            .HasOne(d => d.Creator)
            .WithMany()
            .HasForeignKey(d => d.CreatorId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Document>()
            .HasOne(d => d.Activity)
            .WithMany()
            .HasForeignKey(d => d.ActivityId)
            .OnDelete(DeleteBehavior.Cascade);

        // Relación uno a muchos: User → Activities (CreateBy)
        modelBuilder.Entity<Activity>()
            .HasOne(a => a.CreatedBy)
            .WithMany(u => u.Activities)
            .HasForeignKey(a => a.CreatedById)
            .OnDelete(DeleteBehavior.Restrict);

        // Relación uno a muchos: Activity → Documents
        modelBuilder.Entity<Activity>()
            .HasMany(a => a.Documents)
            .WithOne(d => d.Activity)
            .HasForeignKey(d => d.ActivityId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<User>()
            .HasMany(u => u.Activities)
            .WithOne(a => a.CreatedBy)
            .HasForeignKey(a => a.CreatedById)
            .OnDelete(DeleteBehavior.Restrict);
        
        modelBuilder.Entity<Message>()
            .HasOne(m => m.Sender)
            .WithMany()
            .HasForeignKey(m => m.SenderId)
            .OnDelete(DeleteBehavior.Restrict);
        
        modelBuilder.Entity<Message>()
            .HasOne(m => m.SchoolClass)
            .WithMany(sc => sc.Messages)
            .HasForeignKey(m => m.SchoolClassId)
            .OnDelete(DeleteBehavior.Restrict);
        
        modelBuilder.Entity<Message>()
            .HasOne(m=> m.Team)
            .WithMany(t => t.Messages)
            .HasForeignKey(m => m.TeamId)
            .OnDelete(DeleteBehavior.Restrict);
    }

}