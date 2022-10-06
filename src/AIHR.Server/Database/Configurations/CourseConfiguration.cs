using AIHR.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AIHR.Server.Database.Configurations;

public class CourseConfiguration : IEntityTypeConfiguration<Course>
{
    public void Configure(EntityTypeBuilder<Course> builder)
    {
        builder.ToTable("Courses");
        
        builder.HasKey(course => course.Id);
        builder.HasIndex(course => course.Name);
        
        builder
            .Property(course => course.Name)
            .HasMaxLength(255)
            .IsRequired();
        
        builder
            .HasMany(course => course.StudyPlanCourses)
            .WithOne(studyPlanCourse => studyPlanCourse.Course)
            .HasForeignKey(studyPlanCourse => studyPlanCourse.CourseId);
    }
}