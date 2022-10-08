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
    
    public DbSet<UsageHistory> UsageHistories { get; set; } = default!;
    
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
                new(Guid.Parse("925A6B16-F1D9-459C-9500-5873F8B0B445"), "Blockchain and HR", TimeSpan.FromHours(8)),
                new(Guid.Parse("97DCC28D-4A7C-48A2-99C6-361747536033"), "Compensation & Benefits", TimeSpan.FromHours(32)),
                new(Guid.Parse("0E2AC2B9-813D-4D54-B79F-084C30924FFA"), "Digital HR", TimeSpan.FromHours(40)),
                new(Guid.Parse("180C1524-5D87-4EAC-B71B-3A090F4207E7"), "Digital HR Strategy", TimeSpan.FromHours(10)),
                new(Guid.Parse("C4C1C37B-1C33-4AE1-B322-A540856463C3"), "Digital HR Transformation", TimeSpan.FromHours(8)),
                new(Guid.Parse("EB4DA35D-A6FE-4598-9191-DD2D5F4CDEDA"), "Diversity & Inclusion", TimeSpan.FromHours(20)),
                new(Guid.Parse("827D591C-FAF8-4C7F-99E5-28C5AB4A373A"), "Employee Experience & Design Thinking", TimeSpan.FromHours(12)),
                new(Guid.Parse("62812FED-121E-42BA-8342-B939FB558567"), "Employer Branding", TimeSpan.FromHours(6)),
                new(Guid.Parse("9B6274AC-3303-4AED-A35F-D2B54A2211A0"), "Global Data Integrity", TimeSpan.FromHours(12)),
                new(Guid.Parse("78DE8BA8-C50C-4892-8D32-7C2887899F97"), "Hiring & Recruitment Strategy", TimeSpan.FromHours(15)),
                new(Guid.Parse("CC46A407-BA94-4795-9A38-8F6233F86DE6"), "HR Analytics Leader", TimeSpan.FromHours(21)),
                new(Guid.Parse("EBCE7A27-444C-440D-95FE-2481AF72D0FD"), "HR Business Partner 2.0", TimeSpan.FromHours(40)),
                new(Guid.Parse("33CF8E2C-EEB1-447C-ABE2-291EB909DBFE"), "HR Data Analyst", TimeSpan.FromHours(18)),
                new(Guid.Parse("255F1B74-1D31-4C43-83FC-1F0D96B4C05D"), "HR Data Science in R", TimeSpan.FromHours(12)),
                new(Guid.Parse("25C270DA-D99D-4F11-9F4C-3CA1F03F340A"), "HR Data Visualization", TimeSpan.FromHours(12)),
                new(Guid.Parse("D14ABD2D-1E80-4527-9266-352247744A05"), "HR Metrics & Reporting", TimeSpan.FromHours(40)),
                new(Guid.Parse("245469D3-1FD8-4EBE-B0E5-71022B814A4A"), "Learning & Development", TimeSpan.FromHours(30)),
                new(Guid.Parse("8D5DAC51-EB56-4D42-A343-DA17F9FD44EB"), "Organizational Development", TimeSpan.FromHours(30)),
                new(Guid.Parse("5F186006-20F4-4BC3-9A23-3267F6B621DC"), "People Analytics", TimeSpan.FromHours(40)),
                new(Guid.Parse("8F34D31A-C8FC-40A8-9109-FEE5C12BD83A"), "Statistics in HR", TimeSpan.FromHours(15)),
                new(Guid.Parse("22B89828-4BAF-4C70-BBD1-9E13BE5CBFA3"), "Strategic HR Leadership", TimeSpan.FromHours(34)),
                new(Guid.Parse("F6140D82-87FA-4FBE-A06E-B6100D701772"), "Strategic HR Metrics", TimeSpan.FromHours(17)),
                new(Guid.Parse("DED090BE-5C43-4540-BC99-D156AD2BE997"), "Talent Acquisition", TimeSpan.FromHours(40))
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