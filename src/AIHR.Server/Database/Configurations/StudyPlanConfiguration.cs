using AIHR.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AIHR.Server.Database.Configurations;

public class StudyPlanConfiguration : IEntityTypeConfiguration<StudyPlan>
{
    public void Configure(EntityTypeBuilder<StudyPlan> builder)
    {
        builder.ToTable("StudyPlans");
        
        builder.HasKey(studyPlan => studyPlan.Id);
        
        builder
            .Property(studyPlan => studyPlan.TotalWeeksInSelectedDateRange)
            .UsePropertyAccessMode(PropertyAccessMode.Property);
        
        builder
            .Property(studyPlan => studyPlan.LearningHoursPerWeek)
            .UsePropertyAccessMode(PropertyAccessMode.Property);

        builder
            .HasOne(studyPlan => studyPlan.Student)
            .WithMany(student => student.StudyPlans)
            .HasForeignKey(student => student.StudentId);

        builder
            .HasMany(studyPlan => studyPlan.StudyPlanCourses)
            .WithOne(studyPlanCourse => studyPlanCourse.StudyPlan)
            .HasForeignKey(studyPlanCourse => studyPlanCourse.StudyPlanId);
    }
}