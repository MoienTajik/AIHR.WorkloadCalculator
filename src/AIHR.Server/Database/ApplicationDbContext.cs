using AIHR.Domain;
using Microsoft.EntityFrameworkCore;

namespace AIHR.Server.Database;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options)
        : base(options)
    {
    }

    public DbSet<Student> Students { get; set; } = default!;
    
    public DbSet<Course> Courses { get; set; } = default!;
    
    public DbSet<StudyPlan> StudyPlans { get; set; } = default!;
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

        SeedCourses(modelBuilder);
        SeedStudents(modelBuilder);
    }
    
    private static void SeedCourses(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Course>()
            .HasData(new List<Course>
            {
                new("Blockchain and HR", TimeSpan.FromHours(8)),
                new("Compensation & Benefits", TimeSpan.FromHours(32)),
                new("Digital HR", TimeSpan.FromHours(40)),
                new("Digital HR Strategy", TimeSpan.FromHours(10)),
                new("Digital HR Transformation", TimeSpan.FromHours(8)),
                new("Diversity & Inclusion", TimeSpan.FromHours(20)),
                new("Employee Experience & Design Thinking", TimeSpan.FromHours(12)),
                new("Employer Branding", TimeSpan.FromHours(6)),
                new("Global Data Integrity", TimeSpan.FromHours(12)),
                new("Hiring & Recruitment Strategy", TimeSpan.FromHours(15)),
                new("HR Analytics Leader", TimeSpan.FromHours(21)),
                new("HR Business Partner 2.0", TimeSpan.FromHours(40)),
                new("HR Data Analyst", TimeSpan.FromHours(18)),
                new("HR Data Science in R", TimeSpan.FromHours(12)),
                new("HR Data Visualization", TimeSpan.FromHours(12)),
                new("HR Metrics & Reporting", TimeSpan.FromHours(40)),
                new("Learning & Development", TimeSpan.FromHours(30)),
                new("Organizational Development", TimeSpan.FromHours(30)),
                new("People Analytics", TimeSpan.FromHours(40)),
                new("Statistics in HR", TimeSpan.FromHours(15)),
                new("Strategic HR Leadership", TimeSpan.FromHours(34)),
                new("Strategic HR Metrics", TimeSpan.FromHours(17)),
                new("Talent Acquisition", TimeSpan.FromHours(40))
            });
    }
    
    private static void SeedStudents(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Student>()
            .HasData(new List<Student>
            {
                new(Guid.Parse("f99e35a2-42a2-4b93-a0de-c194165121d2"), "Marijn"),
                new(Guid.Parse("ab3ed2ad-ff11-42dd-88c6-ce1ca99ebb11"), "Moien")
            });
    }
}