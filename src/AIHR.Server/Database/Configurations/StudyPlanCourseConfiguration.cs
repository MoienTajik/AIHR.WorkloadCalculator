using AIHR.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AIHR.Server.Database.Configurations;

public class StudyPlanCourseConfiguration : IEntityTypeConfiguration<StudyPlanCourse>
{
    public void Configure(EntityTypeBuilder<StudyPlanCourse> builder)
    {
        builder.ToTable("StudyPlanCourses");
        
        builder.HasKey(studyPlanCourse => new { studyPlanCourse.CourseId, studyPlanCourse.StudyPlanId });

        builder
            .HasOne(studyPlanCourse => studyPlanCourse.Course)
            .WithMany(course => course.StudyPlanCourses)
            .HasForeignKey(studyPlanCourse => studyPlanCourse.CourseId);
        
        builder
            .HasOne(studyPlanCourse => studyPlanCourse.StudyPlan)
            .WithMany(course => course.StudyPlanCourses)
            .HasForeignKey(studyPlanCourse => studyPlanCourse.StudyPlanId);
    }
}