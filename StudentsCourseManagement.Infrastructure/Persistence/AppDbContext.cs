using Microsoft.EntityFrameworkCore;
using StudentsCourseManagementSystem.Entities;

namespace StudentsCourseManagement.Infrastructure.Persistence;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Student> Students => Set<Student>();
    public DbSet<Course> Courses => Set<Course>();
    public DbSet<User> Users => Set<User>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Course>()
            .HasMany(c => c.Students)
            .WithMany(s => s.Courses)
            .UsingEntity<Dictionary<string, object>>(
                "StudentCourses",
                j => j
                    .HasOne<Student>()
                    .WithMany()
                    .HasForeignKey("StudentId")
                    .OnDelete(DeleteBehavior.Cascade),
                j => j
                    .HasOne<Course>()
                    .WithMany()
                    .HasForeignKey("CourseId")
                    .OnDelete(DeleteBehavior.Cascade)
            );

        modelBuilder.Entity<Course>()
            .Navigation(c => c.Students)
            .UsePropertyAccessMode(PropertyAccessMode.Field);

        modelBuilder.Entity<Student>()
            .Navigation(s => s.Courses)
            .UsePropertyAccessMode(PropertyAccessMode.Field);
    }
}
